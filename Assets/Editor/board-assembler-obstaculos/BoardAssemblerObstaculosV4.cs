using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class BoardAssemblerObstaculosV4 : EditorWindow
{
    [MenuItem("Window/assemblers/BoardAssemblerObstaculosV4")]
    public static void ShowExample()
    {
        BoardAssemblerObstaculosV4 wnd = GetWindow<BoardAssemblerObstaculosV4>();
        wnd.titleContent = new GUIContent("BoardAssemblerObstaculosV4");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler-obstaculos/BoardAssemblerObstaculosV4.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler-obstaculos/BoardAssemblerObstaculosV4.uss");

        GameObject goPrefabsLevelsDto = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/levels/LevelsPrefabDto.prefab");
        PrefabLevelsDto prefabLevelsDto = goPrefabsLevelsDto.GetComponent<PrefabLevelsDto>();

        HelperMapaEntidade.configurar(prefabLevelsDto);
        EditorLevelHelper.inicializar();
        
        ReferenciasDoBoardObstaculo referenciasDoBoard = new ReferenciasDoBoardObstaculo();
        NavegacaoPeloBoardObstaculos navegacao = new NavegacaoPeloBoardObstaculos(root, referenciasDoBoard);

        Action<Sprite> onItemSelecionado = (spr) =>
        {
            PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
            referenciasDoBoard.updateElementoGo(posicaoMira.linha, posicaoMira.coluna, spr);
        };

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, onItemSelecionado);
        ControleObstaculos controleObstaculos = new ControleObstaculos(referenciasDoBoard, listaDeSprites);
        ProcessadorDeObstaculos processador = new ProcessadorDeObstaculos(referenciasDoBoard, controleObstaculos);

        BoardCleanerObstaculos cleaner = new BoardCleanerObstaculos(referenciasDoBoard, navegacao, () => listaDeSprites.getSpriteVazio(), controleObstaculos);
        navegacao.resetMira();

        DropDownLevels dropDownLevels = new DropDownLevelsObstaculo(listaDeSprites);
        dropDownLevels.criarComponentesDropDowns(root, cleaner, controleObstaculos);

        root.Q<Button>("botaoClean").clicked += () => {
            cleaner.clean();
            dropDownLevels.resetDropDowns();
        };
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