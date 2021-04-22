using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoardAssemblerV3 : EditorWindow
{
    private int contadorTeste;

    [MenuItem("Window/BoardAssemblerV3")]
    public static void ShowExample()
    {
        BoardAssemblerV3 wnd = GetWindow<BoardAssemblerV3>();
        wnd.titleContent = new GUIContent("BoardAssemblerV3");
    }

    private int contadorSpriteBinding;
    private Sprite sprVazio;
    private Sprite sprRandom;

    private List<VisualElement> listaDeVisualElements;
    private List<ObjectField> listaDeLinhas;
    private List<Button> listaDeBotoes;

    private ListView listView;

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
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);        

        contadorSpriteBinding = 0;

        root.Q<Button>("botaoMais").clicked += () =>
        {
            criarSpriteBinding();
        };

        //root.Q<Button>("botaoMenos").clicked += () =>
        //{
        //    removerUltimoSpriteBinding();
        //};       

        listaDeLinhas = new List<ObjectField>();
        listaDeVisualElements = new List<VisualElement>();
        listaDeBotoes = new List<Button>();

        //Func<VisualElement> makeItem = () => { return new ObjectField(); };
        Func<VisualElement> makeItem = () =>
        {
            ObjectField objFieldSprite = new ObjectField();
            objFieldSprite.label = "Coletavel:";
            objFieldSprite.objectType = typeof(Sprite);
            objFieldSprite.allowSceneObjects = false;
            objFieldSprite.name = (++contadorSpriteBinding).ToString();

            Button btn = new Button();
            btn.text = "btn";

            VisualElement visualElement = new VisualElement();
            visualElement.name = "visualElementLinha";
            visualElement.AddToClassList("custom");
            visualElement.Add(objFieldSprite);
            visualElement.Add(btn);
            return visualElement;
        };


        Action<VisualElement, int> bindItem = (e, i) =>
        {
            e = listaDeVisualElements[i];

            e.name = "visualElementLinha";
            e.AddToClassList("custom");

            //ObjectField objF = (ObjectField) e;
            ObjectField objF = e.Q<ObjectField>();
            objF.objectType = listaDeLinhas[i].objectType;
            objF.label = listaDeLinhas[i].label;
            objF.allowSceneObjects = listaDeLinhas[i].allowSceneObjects;
            objF.name = listaDeLinhas[i].name;
            //objF.RegisterCallback = listaDeLinhas[i].RegisterCallback;

            objF.RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
            {
                Debug.Log(e1.newValue);
                Debug.Log(e1.currentTarget);
                ObjectField current = (ObjectField)e1.currentTarget;
                Debug.Log("Lancado por: " + current.name);
            });

            Button btn = e.Q<Button>();
            btn.text = "btn";
            btn = listaDeBotoes[i];
        };
        //int itemHeight = 50;

        //listview listview = root.q<listview>("listview");
        //listview.itemssource = listadelinhas;


        listView = new ListView();
        listView.name = "listViewSprites";
        listView.itemsSource = listaDeVisualElements;
        //listView.itemHeight = itemHeight;
        listView.makeItem = makeItem;
        listView.bindItem = bindItem;
        listView.selectionType = SelectionType.Single;
        listView.onItemsChosen += objects => Debug.Log(objects);
        listView.onSelectionChange += objects => Debug.Log(objects);
        listView.styleSheets.Add(styleSheet);

        //listView.style.flexGrow = 1.0f;

        //VisualElement container = root.Q<VisualElement>("containerListSprites");
        //container.Add(listView);

        //rootVisualElement.Add(container);
        //rootVisualElement.Add(listView);


        root.Add(listView);
        criarSpriteBinding();
    }

    private void criarSpriteBinding()
    {
        ObjectField objFieldSprite = new ObjectField();
        objFieldSprite.label = "Coletavel:";
        objFieldSprite.objectType = typeof(Sprite);
        objFieldSprite.allowSceneObjects = false;
        objFieldSprite.name = (++contadorSpriteBinding).ToString();

        VisualElement visualElement = new VisualElement();
        visualElement.name = "visualElementLinha";
        visualElement.AddToClassList("custom");
        visualElement.Add(objFieldSprite);
        //visualElement.style.flexDirection = FlexDirection.Row;

        Button btn = new Button();
        btn.text = "btn";

        listaDeVisualElements.Add(visualElement);
        listaDeLinhas.Add(objFieldSprite);
        listaDeBotoes.Add(btn);

        visualElement.Add(btn);

        listView.Refresh();
        //ListView listView = rootVisualElement.Q<ListView>("listView");        
        //listView.Refresh();          
    }

    private void removerUltimoSpriteBinding()
    {
        //Debug.Log("Qtd: " + contadorSpriteBinding);
        //if (contadorSpriteBinding > 1)
        //{
        //    listaDeLinhas.RemoveAt(contadorSpriteBinding - 1);
        //    listaDeVisualElements.RemoveAt(contadorSpriteBinding - 1);
        //    ListView listView = rootVisualElement.Q<ListView>("listView");
        //    listView.Refresh();

        //    contadorSpriteBinding--;
        //}
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