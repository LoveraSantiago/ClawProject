using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoardAssemblerV2 : EditorWindow
{
    private int contadorTeste;

    [MenuItem("Window/BoardAssemblerV2")]
    public static void ShowExample()
    {
        BoardAssemblerV2 wnd = GetWindow<BoardAssemblerV2>();
        wnd.titleContent = new GUIContent("BoardAssemblerV2");
    }

    private int contadorSpriteBinding;
    private Sprite sprVazio;
    private Sprite sprRandom;

        List<ObjectField> items = new List<ObjectField>(10);

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

        contadorSpriteBinding = 0;
        criarSpriteBinding();        

        root.Q<Button>("botaoMais").clicked += () =>
        {            
            criarSpriteBinding();
        };

        root.Q<Button>("botaoMenos").clicked += () =>
        {
            removerUltimoSpriteBinding();
        };

        const int itemCount = 1;
        for (int i = 1; i <= itemCount; i++)
        {
            ObjectField objFieldSprite = new ObjectField();
            objFieldSprite.label = "Coletavel:";
            objFieldSprite.objectType = typeof(Sprite);
            objFieldSprite.allowSceneObjects = false;

            items.Add(objFieldSprite);
        }

        Func<VisualElement> makeItem = () => new ObjectField();
        Action<VisualElement, int> bindItem = (e, i) => { };
        int itemHeight = 16;

        var listView = new ListView(items, itemHeight, makeItem, bindItem);

        //listView.itemsSource = items;
        //listView.itemHeight = itemHeight;
        //listView.makeItem = makeItem;
        //listView.bindItem = bindItem;
        listView.selectionType = SelectionType.Single;
        listView.onItemsChosen += objects => Debug.Log(objects);
        listView.onSelectionChange += objects => Debug.Log(objects);

        listView.style.flexGrow = 1.0f;
        rootVisualElement.Add(listView);
    }

    private void criarSpriteBinding()
    {
        ObjectField objFieldSprite = new ObjectField();
        objFieldSprite.label = "Coletavel:";
        objFieldSprite.objectType = typeof(Sprite);
        objFieldSprite.allowSceneObjects = false;
        objFieldSprite.name = (++contadorSpriteBinding).ToString();

        items.Add(new ObjectField());

        objFieldSprite.RegisterCallback<ChangeEvent<UnityEngine.Object>>(e => {
            Debug.Log(e.newValue);
            Debug.Log(e.currentTarget);
            ObjectField current = (ObjectField)e.currentTarget;
            Debug.Log("Lancado por: " + current.name);            
        });

        rootVisualElement.Q<VisualElement>("containerListSprites")
           .Add(objFieldSprite);        
    }

    private void removerUltimoSpriteBinding()
    {
        Debug.Log("Qtd: " + contadorSpriteBinding);
        if(contadorSpriteBinding > 1)
        {
            ObjectField objFieldSprite = rootVisualElement.Q<ObjectField>(contadorSpriteBinding.ToString());
            rootVisualElement.Q<VisualElement>("containerListSprites")
                .Remove(objFieldSprite);

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