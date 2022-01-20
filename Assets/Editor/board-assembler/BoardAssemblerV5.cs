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

        HelperColetavelEntidade.configurar();
        ReferenciasDoBoardPositivo referenciasDoBoard = new ReferenciasDoBoardPositivo();
        NavegacaoPeloBoardPositivo navegacao  = new NavegacaoPeloBoardPositivo(root, referenciasDoBoard);        
        ProcessadorDeColetaveis processadorColetaveis = new ProcessadorDeColetaveis(referenciasDoBoard);
        ProcessadorDeOrdem processadorDeOrdem = new ProcessadorDeOrdem(referenciasDoBoard);

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => {
                PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
                referenciasDoBoard.updateElementoGo(posicaoMira.linha, posicaoMira.coluna, spr);            
            });

        BoardCleanerPositivo cleaner = new BoardCleanerPositivo(referenciasDoBoard, navegacao, () => listaDeSprites.getSpriteVazio());

        navegacao.resetMira();

        RemontadorBoard remontadorObj         = new RemontadorBoard(referenciasDoBoard, listaDeSprites);
        RemontadorLabelsBoard remontadorLbls  = new RemontadorLabelsBoard(referenciasDoBoard, listaDeSprites);
        DropDownLevelsPositivo dropDownLevels = new DropDownLevelsPositivo(LevelHelper.getNormalLevelsAlias(), remontadorLbls);
        dropDownLevels.criarComponentDropDownField(root, cleaner, remontadorObj);

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });

        root.Q<Button>("botaoMenosTodos")    .clicked += () => listaDeSprites.limparTodaLista();
        root.Q<Button>("botaoMenos")         .clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<Button>("botaoClean")         .clicked += () => cleaner.clean();
        root.Q<Button>("botaoProcessar")     .clicked += () => processadorColetaveis.processar();
        root.Q<Button>("botaoProcessarOrdem").clicked += () => processadorDeOrdem.processar();
        root.Q<Button>("botaoCimaAll")       .clicked += () => navegacao.navegarCimaTotal();
        root.Q<Button>("botaoBaixoAll")      .clicked += () => navegacao.navegarBaixoTotal();
        root.Q<Button>("botaoEsquerdaAll")   .clicked += () => navegacao.navegarTrasTotal();
        root.Q<Button>("botaoDireitaAll")    .clicked += () => navegacao.navegarFrenteTotal();
        root.Q<IntegerField>("ordem").RegisterValueChangedCallback((evento) => 
            {
                PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
                referenciasDoBoard.updateElementoTexto(posicaoMira.linha, posicaoMira.coluna, evento.newValue);                
            });

        cleaner.clean();
    }               
}