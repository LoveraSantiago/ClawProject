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

    private int contadorSpriteBinding;
    private Sprite sprVazio;
    private Sprite sprRandom;

    private List<VisualElement> listaDeVELinha;
    private List<ObjectField> listaDeOFSprites;
    private List<Button> listaDeBotoes;
    private List<Sprite> listaDeSprites;

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
        listaDeOFSprites = new List<ObjectField>();
        listaDeVELinha   = new List<VisualElement>();
        listaDeBotoes    = new List<Button>();
        listaDeSprites   = new List<Sprite>();

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {            
            listaDeSprites.Add((Sprite) e1.newValue);
            Debug.Log("Lista De Sprites size: " +  listaDeSprites.Count);

            //Image image = new Image();
            //image.image = ((Sprite)e1.newValue).texture;
            //image.style.backgroundImage = new StyleBackground(((Sprite)e1.newValue).texture);
            //image.style.backgroundColor = Color.blue;
            //image.sp = e1.newValue;
            //root.Add(image);
        });
        root.Q<Button>("botaoMais").clicked += () => criarItemLinha();
        root.Q<Button>("botaoMenos").clicked += () => removerUltimoItemLinha();        

        listView = new ListView();
        listView.name = "listViewSprites";
        listView.itemsSource = listaDeVELinha;        
        listView.makeItem = () => funcMakeItem();
        listView.bindItem = (e, i) => actionBindItem(e, i);
        listView.selectionType = SelectionType.Single;
        listView.onItemsChosen += objects => Debug.Log(objects);
        listView.onSelectionChange += objects => Debug.Log(objects);
        listView.styleSheets.Add(styleSheet);

        //root.Add(listView);
        criarItemLinha();
    }

    private void criarItemLinha()
    {
        contadorSpriteBinding = 0;

        ObjectField objFieldSprite = criarObjectFieldSprite();        
        Button btn = criarBotao();
        VisualElement visualElement = criarVELinha();

        visualElement.Add(objFieldSprite);
        visualElement.Add(btn);

        listaDeVELinha.Add(visualElement);
        listaDeOFSprites.Add(objFieldSprite);
        listaDeBotoes.Add(btn);

        listView.Refresh();        
    }

    private void removerUltimoItemLinha()
    {
        Debug.Log("Qtd: " + contadorSpriteBinding);
        if (listaDeVELinha.Count > 1)
        {
            listaDeVELinha.RemoveAt(listaDeVELinha.Count - 1);            
            listaDeOFSprites.RemoveAt(listaDeOFSprites.Count - 1);
            listaDeBotoes.RemoveAt(listaDeBotoes.Count - 1);           

            listView.Refresh();
            contadorSpriteBinding--;
        }
    }

    private ObjectField criarObjectFieldSprite()
    {
        ObjectField objFieldSprite = new ObjectField();
        objFieldSprite.label = "Coletavel:";
        objFieldSprite.objectType = typeof(Sprite);
        objFieldSprite.allowSceneObjects = false;
        objFieldSprite.name = "objectFieldSprite_";
        return objFieldSprite;
    }

    private Button criarBotao()
    {
        Button btn = new Button();
        btn.text = "add";
        btn.name = "button_";
        return btn;
    }

    private VisualElement criarVELinha()
    {
        VisualElement visualElement = new VisualElement();
        visualElement.name = "visualElementLinha_";
        visualElement.AddToClassList("veLinha");
        return visualElement;
    }

    private VisualElement funcMakeItem()
    {
        Debug.Log("Make Item Chamado");

        //string nome = (++contadorSpriteBinding).ToString();

        //ObjectField objFieldSprite = criarObjectFieldSprite();
        //objFieldSprite.name += nome;

        //Button btn = criarBotao();
        //btn.name += nome;

        //VisualElement visualElement = criarVELinha();
        //visualElement.name += nome;

        //visualElement.Add(objFieldSprite);
        //visualElement.Add(btn);

        VisualElement visualElement = listaDeVELinha[contadorSpriteBinding];
        contadorSpriteBinding++;
        return visualElement;
    }

    private void actionBindItem(VisualElement e, int i)
    {
        Debug.Log("Binding chamado indice: " + i);
        VisualElement veDaLista = listaDeVELinha[i];        
        e.name = veDaLista.name;        
        e.AddToClassList("veLinha");

        ObjectField objFDaLista = listaDeOFSprites[i];
        ObjectField eObF = e.Q<ObjectField>();
        eObF.objectType = objFDaLista.objectType;
        eObF.label = objFDaLista.label;
        eObF.allowSceneObjects = objFDaLista.allowSceneObjects;
        eObF.name = objFDaLista.name;

        eObF.RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            Debug.Log(e1.newValue);
            Debug.Log(e1.currentTarget);
            ObjectField current = (ObjectField)e1.currentTarget;
            Debug.Log("Lancado por: " + current.name);
        });

        Button btnDaLista = listaDeBotoes[i];
        Button eBtn = e.Q<Button>();
        eBtn.text = btnDaLista.text;
        eBtn.name = btnDaLista.name;        
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