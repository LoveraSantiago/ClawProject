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
        ReferenciasDoBoardObstaculo referenciasDoBoard = new ReferenciasDoBoardObstaculo();
        NavegacaoPeloBoardObstaculos navegacao = new NavegacaoPeloBoardObstaculos(root, referenciasDoBoard);
        ProcessadorDeColetaveis processadorColetaveis = new ProcessadorDeColetaveis(referenciasDoBoard);        
        BoardCleanerObstaculos cleaner = new BoardCleanerObstaculos(referenciasDoBoard, navegacao, () => spriteVazio);
        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => Preenchedor.colocarSprite(navegacao.getGoDaMira(), spr));
        RemontadorBoard remontador = new RemontadorBoard(referenciasDoBoard, listaDeSprites);
        DropDownLevels dropoDownLevels = new DropDownLevels(LevelHelper.getObstaculoLevelsAlias());
        dropoDownLevels.criarComponentDropDownField(root, cleaner, remontador);

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });

        root.Q<Button>("botaoMenosTodos")   .clicked += () => listaDeSprites.limparTodaLista();
        root.Q<Button>("botaoMenos")        .clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<Button>("botaoClean")        .clicked += () => cleaner.clean();
        root.Q<Button>("botaoProcessar")    .clicked += () => processadorColetaveis.processar();
        root.Q<Button>("botaoCimaAll")      .clicked += () => navegacao.navegarCimaTotal();
        root.Q<Button>("botaoBaixoAll")     .clicked += () => navegacao.navegarBaixoTotal();
        root.Q<Button>("botaoEsquerdaAll")  .clicked += () => navegacao.navegarTrasTotal();
        root.Q<Button>("botaoDireitaAll")   .clicked += () => navegacao.navegarFrenteTotal();
        root.Q<Button>("botaoAddObstaculos").clicked += () => { };

        spriteVazio = listaDeSprites.getSpriteVazio();
        cleaner.clean();
    }
}