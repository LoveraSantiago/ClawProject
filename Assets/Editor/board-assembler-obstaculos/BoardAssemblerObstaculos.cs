using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class BoardAssemblerObstaculos : EditorWindow
{
    [MenuItem("Window/assemblers/BoardAssemblerObstaculos")]
    public static void ShowExample()
    {
        BoardAssemblerObstaculos wnd = GetWindow<BoardAssemblerObstaculos>();
        wnd.titleContent = new GUIContent("BoardAssemblerObstaculos");
    }

    private Sprite spriteVazio;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler-obstaculos/BoardAssemblerObstaculos.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler-obstaculos/BoardAssemblerObstaculos.uss");

        HelperColetavelEntidade.configurar();
        ReferenciasDoBoardAssemblerObstaculo referenciasDoBoard = new ReferenciasDoBoardAssemblerObstaculo();
        NavegacaoPeloBoardObstaculos navegacao = new NavegacaoPeloBoardObstaculos(root, referenciasDoBoard);
        ProcessadorDeColetaveis processaodrColetaveis = new ProcessadorDeColetaveis(referenciasDoBoard);
        Preenchedor preenchedor = new Preenchedor();
        BoardCleanerObstaculos cleaner = new BoardCleanerObstaculos(referenciasDoBoard, navegacao, () => spriteVazio);
        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => preenchedor.colocarSprite(navegacao.getGoDaMira(), spr));
        RemontadorBoard remontador = new RemontadorBoard(referenciasDoBoard, listaDeSprites);
        DropDownLevels dropoDownLevels = new DropDownLevels(LevelHelper.getObstaculoLevelsAlias());
        dropoDownLevels.criarComponentDropDownField(root, cleaner, remontador);
    }
}