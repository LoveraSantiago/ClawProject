using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class BoardAssemblerV2 : EditorWindow
{
    [MenuItem("Window/BoardAssemblerV2")]
    public static void ShowExample()
    {
        BoardAssemblerV2 wnd = GetWindow<BoardAssemblerV2>();
        wnd.titleContent = new GUIContent("BoardAssemblerV2");
    }

    private Sprite sprVazio;
    private Sprite sprRandom;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BoardAssemblerV2.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        //var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BoardAssemblerV2.uss");
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);

        
        //ObjectField objField = root.Q<ObjectField>();
        //Debug.Log("Obj: " + objField);
        //Debug.Log("Nome: " + objField.name);
        //Debug.Log("Tipo:" + objField.GetType());
        //Debug.Log("Tipo Nome: " + objField.GetType().Name);
        //Debug.Log("ObjTipo: " + objField.objectType);
        //configurarSpritesDefaults();
        //configurarComponentes();

        ObjectField objNovo = new ObjectField();
        objNovo.label = "Tile Imagem";
        objNovo.objectType = typeof(Sprite);
        objNovo.allowSceneObjects = false;
        objNovo.RegisterCallback<ChangeEvent<UnityEngine.Object>>( e => {
            Debug.Log(e.newValue);
        });


        root.Q<VisualElement>("containerListSprites")
            .Add(objNovo);

        root.Q<Button>("botaoMais").clicked += () =>
        {
            Debug.Log("Fui Acionado");
            criarSpriteXXXX();
        };                     
    }

    private void criarSpriteXXXX()
    {
        ObjectField objNovo = new ObjectField();
        objNovo.label = "Tile Imagem";
        objNovo.objectType = typeof(Sprite);
        objNovo.allowSceneObjects = false;
        objNovo.RegisterCallback<ChangeEvent<UnityEngine.Object>>(e => {
            Debug.Log(e.newValue);
        });

        rootVisualElement.Q<VisualElement>("containerListSprites")
           .Add(objNovo);
    }

    private void configurarComponentes()
    {
        ReferenciasDoBoardAssembler referenciasDoBoard = new ReferenciasDoBoardAssembler();
        referenciasDoBoard.configurarReferenciasComBoard();

        NavegacaoPeloBoard navegacao = new NavegacaoPeloBoard(referenciasDoBoard.goMira, referenciasDoBoard.dicionarioGosBoard);
        navegacao.configurarBotoes(rootVisualElement);
        navegacao.resetMira();
    }

    private void configurarSpritesDefaults()
    {
        sprVazio = Resources.Load<Sprite>("Sprites/collectables/tile-vazio");
        sprRandom = Resources.Load<Sprite>("Sprites/collectables/tile-random");
    }

    private void colocarSprite(GameObject go, Sprite sprite)
    {
        go.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}