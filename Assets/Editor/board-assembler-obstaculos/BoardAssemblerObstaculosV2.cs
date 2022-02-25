using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;

public class BoardAssemblerObstaculosV2 : EditorWindow
{
    [MenuItem("Window/assemblers/BoardAssemblerObstaculosV2")]
    public static void ShowExample()
    {
        BoardAssemblerObstaculosV2 wnd = GetWindow<BoardAssemblerObstaculosV2>();
        wnd.titleContent = new GUIContent("BoardAssemblerObstaculos");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler-obstaculos/BoardAssemblerObstaculosV2.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler-obstaculos/BoardAssemblerObstaculosV2.uss");

        HelperColetavelEntidade.configurar();
        ReferenciasDoBoardObstaculo referenciasDoBoard = new ReferenciasDoBoardObstaculo();
        NavegacaoPeloBoardObstaculos navegacao = new NavegacaoPeloBoardObstaculos(root, referenciasDoBoard);
        ControleObstaculos controleObstaculos = new ControleObstaculos(referenciasDoBoard);
        ProcessadorDeObstaculos processador = new ProcessadorDeObstaculos(referenciasDoBoard, controleObstaculos);

        Action<Sprite> onItemSelecionado = (spr) =>
        {
            PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
            referenciasDoBoard.updateElementoGo(posicaoMira.linha, posicaoMira.coluna, spr);
        };
        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, onItemSelecionado);

        BoardCleanerObstaculos cleaner = new BoardCleanerObstaculos(referenciasDoBoard, navegacao, () => listaDeSprites.getSpriteVazio(), controleObstaculos);
        navegacao.resetMira();

        RemontadorBoard remontador = new RemontadorBoardDeObstaculos(referenciasDoBoard, listaDeSprites);
        DropDownLevels dropoDownLevels = new DropDownLevelsObstaculo(LevelHelper.getObstaculoLevelsAlias());
        dropoDownLevels.criarComponentDropDownField(root, cleaner, remontador);

        EventCallback<ChangeEvent<UnityEngine.Object>> onSpriteAdicionado = (e1) =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        };
        root.Q<ObjectField>("objectFieldSprite").RegisterCallback(onSpriteAdicionado);

        root.Q<Button>("botaoMenosTodos").clicked += () => listaDeSprites.limparTodaLista();
        root.Q<Button>("botaoMenos").clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<Button>("botaoClean").clicked += () => cleaner.clean();
        root.Q<Button>("botaoProcessar").clicked += () => processador.processar();
        root.Q<Button>("botaoCimaAll").clicked += () => navegacao.navegarCimaTotal();
        root.Q<Button>("botaoBaixoAll").clicked += () => navegacao.navegarBaixoTotal();
        root.Q<Button>("botaoEsquerdaAll").clicked += () => navegacao.navegarTrasTotal();
        root.Q<Button>("botaoDireitaAll").clicked += () => navegacao.navegarFrenteTotal();
        root.Q<Button>("botaoProcessarObstaculos").clicked += () => processador.processarObstaculos();
        root.Q<Button>("botaoAddObstaculos").clicked += () => {
            PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
            controleObstaculos.processarObstaculo(posicaoMira);
        };

        cleaner.clean();
    }
}