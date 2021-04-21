using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


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

    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;
    private GameObject goMira;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BoardAssembler.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        configurarSpritesDefaults();        
        configurarReferenciasComBoard();
        posicionarMira(0,0);
        configurarBotoes();        
    }

    private void configurarSpritesDefaults()
    {
        sprVazio = Resources.Load<Sprite>("Sprites/collectables/tile-vazio");
        sprRandom = Resources.Load<Sprite>("Sprites/collectables/tile-random");
    }

    private void configurarReferenciasComBoard()
    {
        GameObject goBoardAssembler = getBoardAssembler();
        dicionarioGosBoard = inicializarDicionarioDeGosBoard(goBoardAssembler);
        goMira = inicializarGoMira(goBoardAssembler);
    }

    public void posicionarMira(int linha, int coluna)
    {
        GameObject go00 = dicionarioGosBoard[linha][coluna];
        goMira.transform.position = go00.transform.position;
    }

    private GameObject getBoardAssembler()
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            Debug.Log("Nome: " + gos[contador].name);
            if (gos[contador].name == "BoardAssembler")
            {
                return gos[contador];
            }
        }
        Debug.LogError("Nao existe na cena o prefab BoardAssembler");
        return null;
    }

    private Dictionary<int, Dictionary<int, GameObject>> inicializarDicionarioDeGosBoard(GameObject goBoardAssembler)
    {
        Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard = new Dictionary<int, Dictionary<int, GameObject>>();
        for (int contadorLinha = 0; contadorLinha < goBoardAssembler.transform.childCount; contadorLinha++)
        {
            GameObject goLinha = goBoardAssembler.transform.GetChild(contadorLinha).gameObject;
            int nomeNumericoLinha;
            bool isNumericoLinha = int.TryParse(goLinha.name, out nomeNumericoLinha);
            if (isNumericoLinha)
            {
                Dictionary<int, GameObject> dicionarioColuna = new Dictionary<int, GameObject>();

                for (int contadorColuna = 0; contadorColuna < goLinha.transform.childCount; contadorColuna++)
                {
                    GameObject goColuna = goLinha.transform.GetChild(contadorColuna).gameObject;
                    int nomeNumericoColuna;
                    bool isNumericoColuna = int.TryParse(goColuna.name, out nomeNumericoColuna);
                    if (isNumericoColuna)
                    {
                        colocarSprite(goColuna, sprVazio);
                        dicionarioColuna.Add(nomeNumericoColuna, goColuna);                        
                    }
                }

                dicionarioGosBoard.Add(nomeNumericoLinha, dicionarioColuna);
            }
        }
        return dicionarioGosBoard;
    }

    private void colocarSprite(GameObject go, Sprite sprite)
    {
        go.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private GameObject inicializarGoMira(GameObject goBoardAssembler)
    {
        GameObject goMira = goBoardAssembler.transform.Find("mira").gameObject;
        if (goMira == null)
        {
            Debug.LogError("Objeto mira nao existe no game object BoardAssembler");
        }
        return goMira;
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