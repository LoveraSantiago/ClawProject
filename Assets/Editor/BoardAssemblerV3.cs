using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoardAssemblerV3 : EditorWindow
{

    [MenuItem("Window/BoardAssemblerV3")]
    public static void ShowExample()
    {
        BoardAssemblerV3 wnd = GetWindow<BoardAssemblerV3>();
        wnd.titleContent = new GUIContent("BoardAssemblerV3");
    }   
    
    
    //private ListView listView;
    //private List<Sprite> listaDeSprites;
    private NavegacaoPeloBoard navegacao;
    private ListaDeSprites listaDeSpritesObj;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BoardAssemblerV3.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BoardAssemblerV3.uss");
        listaDeSpritesObj = new ListaDeSprites(root, styleSheet, (spr)=> colocarSprite(navegacao.getGoDaMira(), spr));
        //listaDeSprites   = new List<Sprite>();
        //listaDeSprites.Add(Resources.Load<Sprite>("Sprites/collectables/tile-vazio"));
        //listaDeSprites.Add(Resources.Load<Sprite>("Sprites/collectables/tile-random"));

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSpritesObj.receberSprite((Sprite)e1.newValue);
            //listaDeSprites.Add((Sprite) e1.newValue);
            //Debug.Log("Lista De Sprites size: " +  listaDeSprites.Count);            
            //listView.Refresh();
        });
        //root.Q<Button>("botaoMais").clicked += () => criarItemLinha();
        root.Q<Button>("botaoMenos").clicked += () => removerUltimoItemLinha();        

        //listView = new ListView();
        //listView.name = "listViewSprites";
        //listView.itemsSource = listaDeSprites;        
        //listView.makeItem = () => funcMakeItem();
        //listView.bindItem = (e, i) => actionBindItem(e, i);
        //listView.selectionType = SelectionType.Single;
        //listView.onItemsChosen += objects => {            
        //    Debug.Log("onItemsChosen: " + objects);
            
        //};


                                    
        //listView.onSelectionChange += objects => {
        //    Debug.Log("onSelectionChange: " + objects);
        //    Debug.Log("onSelectionChange: " + objects.GetEnumerator());
        //    //objects[0]//PEGA o SPRITE    

        //    //IEnumerator<object> enumerator = objects.GetEnumerator();
        //    Sprite spr = (Sprite) ((List<System.Object>)objects)[0];

        //    colocarSprite(navegacao.getGoDaMira(), spr);
        //};
        //listView.styleSheets.Add(styleSheet);
        //root.Add(listView);

        configurarComponentes();
    }    

    private void removerUltimoItemLinha()
    {
        listaDeSpritesObj.removerUltimaLinha();
    }       

    //private VisualElement funcMakeItem()
    //{
    //    Image image = new Image();
    //    Label label = new Label();

    //    VisualElement visualElement = new VisualElement();
    //    visualElement.AddToClassList("veLinha");
    //    visualElement.Add(image);
    //    visualElement.Add(label);
    //    return visualElement;
    //}

    //private void actionBindItem(VisualElement e, int i)
    //{
    //    VisualElement visualElement = e;
    //    Image image = visualElement.Q<Image>();
    //    image.style.backgroundImage = new StyleBackground(listaDeSprites[i].texture);
    //    Label label = visualElement.Q<Label>();
    //    label.text = listaDeSprites[i].name;
    //}

    private void configurarComponentes()
    {
        ReferenciasDoBoardAssembler referenciasDoBoard = new ReferenciasDoBoardAssembler();
        referenciasDoBoard.configurarReferenciasComBoard();

        navegacao = new NavegacaoPeloBoard(referenciasDoBoard.goMira, referenciasDoBoard.dicionarioGosBoard);
        navegacao.configurarBotoes(rootVisualElement);
        navegacao.resetMira();
    }    

    private void colocarSprite(GameObject go, Sprite sprite)
    {
        Debug.Log(sprite);
        go.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}