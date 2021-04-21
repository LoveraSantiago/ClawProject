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


        //configurarSpritesDefaults();        
        //posicionarMira(0,0);
        //configurarBotoes();        

        ReferenciasDoBoardAssembler referenciasDoBoard = new ReferenciasDoBoardAssembler();
        referenciasDoBoard.configurarReferenciasComBoard();
    }

    private void configurarSpritesDefaults()
    {
        sprVazio = Resources.Load<Sprite>("Sprites/collectables/tile-vazio");
        sprRandom = Resources.Load<Sprite>("Sprites/collectables/tile-random");
    }

    public void posicionarMira(int linha, int coluna)
    {
        GameObject go00 = dicionarioGosBoard[linha][coluna];
        goMira.transform.position = go00.transform.position;
    }

    private void colocarSprite(GameObject go, Sprite sprite)
    {
        go.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void configurarBotoes()
    {
        Button btnCima = rootVisualElement.Q<Button>("botaoCima");
        btnCima.clickable.clicked += () =>
        {
            if (podeDescerUmaLinha())
            {
                linhaInicial++;
            }
            posicionarMira(linhaInicial, colunaInicial);
        };

        Button btnEsquerda = rootVisualElement.Q<Button>("botaoEsquerda");
        btnEsquerda.clickable.clicked += () =>
        {
            if (podeVoltarUmaColuna())
            {
                colunaInicial--;
            }

            posicionarMira(linhaInicial, colunaInicial);
        };

        Button btnDireita = rootVisualElement.Q<Button>("botaoDireita");
        btnDireita.clickable.clicked += () =>
        {
            if (podeAndarUmaColuna())
            {
                colunaInicial++;
            }
            posicionarMira(linhaInicial, colunaInicial);
        };

        Button btnBaixo = rootVisualElement.Q<Button>("botaoBaixo");
        btnBaixo.clickable.clicked += () =>
        {
            if (podeAndarUmaLinha())
            {
                linhaInicial--;
            }
            posicionarMira(linhaInicial, colunaInicial);
        };
    }

    private bool podeAndarUmaColuna()
    {
        return colunaInicial + 1 < dicionarioGosBoard[linhaInicial].Count;
    }

    private bool podeVoltarUmaColuna()
    {
        return colunaInicial - 1 >= 0;
    }

    private bool podeAndarUmaLinha()
    {
        return linhaInicial - 1 >= 0; 
    }

    private bool podeDescerUmaLinha()
    {
        return linhaInicial + 1 < dicionarioGosBoard.Count;
    }
}