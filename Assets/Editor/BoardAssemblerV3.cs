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

        contadorSpriteBinding = 0;
        listaDeLinhas = new List<ObjectField>();
        listaDeVisualElements = new List<VisualElement>();
        listaDeBotoes = new List<Button>();

        root.Q<Button>("botaoMais").clicked += () =>
        {
            criarSpriteBinding();
        };

        root.Q<Button>("botaoMenos").clicked += () =>
        {
            removerUltimoSpriteBinding();
        };       

        //Func<VisualElement> makeItem = () => { return new ObjectField(); };
        Func<VisualElement> makeItem = () =>
        {
            Debug.Log("Make Item Chamado");
            ObjectField objFieldSprite = new ObjectField();
            objFieldSprite.label = "Coletavel:";
            objFieldSprite.objectType = typeof(Sprite);
            objFieldSprite.allowSceneObjects = false;
            objFieldSprite.name = (++contadorSpriteBinding).ToString();//PROBLEMAS COM NOME

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

        listView = new ListView();
        listView.name = "listViewSprites";
        listView.itemsSource = listaDeVisualElements;        
        listView.makeItem = makeItem;
        listView.bindItem = bindItem;
        listView.selectionType = SelectionType.Single;
        listView.onItemsChosen += objects => Debug.Log(objects);
        listView.onSelectionChange += objects => Debug.Log(objects);
        listView.styleSheets.Add(styleSheet);

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

        Button btn = new Button();
        btn.text = "btn";

        listaDeVisualElements.Add(visualElement);
        listaDeLinhas.Add(objFieldSprite);
        listaDeBotoes.Add(btn);

        visualElement.Add(btn);

        listView.Refresh();        
    }

    private void removerUltimoSpriteBinding()
    {
        Debug.Log("Qtd: " + contadorSpriteBinding);
        if (listaDeVisualElements.Count > 1)
        {
            listaDeVisualElements.RemoveAt(listaDeVisualElements.Count - 1);            
            listaDeLinhas.RemoveAt(listaDeLinhas.Count - 1);
            listaDeBotoes.RemoveAt(listaDeBotoes.Count - 1);           

            listView.Refresh();
            contadorSpriteBinding--;
        }
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