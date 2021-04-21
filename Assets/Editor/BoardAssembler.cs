using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;


public class BoardAssembler : EditorWindow
{
    [MenuItem("Window/BoardAssembler")]
    public static void ShowExample()
    {
        BoardAssembler wnd = GetWindow<BoardAssembler>();
        wnd.titleContent = new GUIContent("BoardAssembler");
    }

    private int linhaInicial;
    private int colunaInicial;

    private Sprite sprVazio;
    private Sprite sprRandom;

    //private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;
    //private GameObject goMira;
    //private List<Sprite> listOf = new List<Sprite>();

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BoardAssembler.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        List<ObjectField> listaDeObjectField = new List<ObjectField>();
        listaDeObjectField.Add(new ObjectField("Hum"));
        listaDeObjectField.Add(new ObjectField("Dois"));
        listaDeObjectField.Add(new ObjectField("Tres"));

        Func<VisualElement> makeItem = () => new ObjectField();

        ListView listView = root.Q<ListView>();
        //listView.itemsSource = listaDeObjectField;
        //listView.makeItem = makeItem;
        //listView.binding = listaDeObjectField;


        configurarSpritesDefaults();
        configurarComponentes();
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