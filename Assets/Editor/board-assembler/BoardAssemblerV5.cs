using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardAssemblerV5 : EditorWindow
{
    [MenuItem("Window/assemblers/BoardAssemblerV5")]
    public static void ShowExample()
    {
        BoardAssemblerV5 wnd = GetWindow<BoardAssemblerV5>();
        wnd.titleContent = new GUIContent("BoardAssemblerV5");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler/BoardAssemblerV5.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);
        
        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler/BoardAssemblerV5.uss");

        EditorLevelHelper.inicializar();
        HelperColetavelEntidade.configurar();
        ReferenciasDoBoardPositivo referenciasDoBoard = new ReferenciasDoBoardPositivo();
        NavegacaoPeloBoardPositivo navegacao  = new NavegacaoPeloBoardPositivo(root, referenciasDoBoard);        
        ProcessadorDeOrdem processador = new ProcessadorDeOrdem(referenciasDoBoard);

        Action<Sprite> onItemSelecionado = (spr) =>
        {
            PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
            referenciasDoBoard.updateElementoGo(posicaoMira.linha, posicaoMira.coluna, spr);
        };
        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, onItemSelecionado);

        BoardCleanerPositivo cleaner = new BoardCleanerPositivo(referenciasDoBoard, navegacao, () => listaDeSprites.getSpriteVazio());
        navegacao.resetMira();

        RemontadorBoard remontadorLbls  = new RemontadorLabelsBoard(referenciasDoBoard, listaDeSprites);
        DropDownLevelsPositivo dropDownLevels = new DropDownLevelsPositivo(EditorLevelHelper.listaDeNomesLevelsNaoObstaculos, listaDeSprites);
        dropDownLevels.criarComponentesDropDowns(root, cleaner, remontadorLbls);


        root.Q<Button>("botaoClean").clicked += () => {
            cleaner.clean();
            dropDownLevels.resetDropDowns();
        };
        root.Q<Button>("botaoProcessar")     .clicked += () => processador.processar();
        root.Q<Button>("botaoProcessarOrdem").clicked += () => processador.processarOrdem();
        root.Q<Button>("botaoCimaAll")       .clicked += () => navegacao.navegarCimaTotal();
        root.Q<Button>("botaoBaixoAll")      .clicked += () => navegacao.navegarBaixoTotal();
        root.Q<Button>("botaoEsquerdaAll")   .clicked += () => navegacao.navegarTrasTotal();
        root.Q<Button>("botaoDireitaAll")    .clicked += () => navegacao.navegarFrenteTotal();

        EventCallback<ChangeEvent<int>> onOrdemAcionado = (evento) =>
        {
            PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
            bool isGoComSpriteVazio = referenciasDoBoard.isElementoGoComSprite(posicaoMira.linha, posicaoMira.coluna, listaDeSprites.getSpriteVazio());
            if (!isGoComSpriteVazio)
            {
                referenciasDoBoard.updateElementoTexto(posicaoMira.linha, posicaoMira.coluna, evento.newValue);
            }
        };
        root.Q<IntegerField>("ordem").RegisterValueChangedCallback(onOrdemAcionado);

        cleaner.clean();
    }               
}