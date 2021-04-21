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

    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;
    private GameObject goMira;
    private int linhaInicial;
    private int colunaInicial;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BoardAssembler.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        configurarReferenciasComBoard();
        posicionarMira(0,0);
        configurarBotoes();        
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
                        dicionarioColuna.Add(nomeNumericoColuna, goColuna);
                    }
                }

                dicionarioGosBoard.Add(nomeNumericoLinha, dicionarioColuna);
            }
        }
        return dicionarioGosBoard;
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
            linhaInicial++;
            posicionarMira(linhaInicial, colunaInicial);
        };

        Button btnEsquerda = rootVisualElement.Q<Button>("botaoEsquerda");
        btnEsquerda.clickable.clicked += () =>
        {
            colunaInicial--;
            posicionarMira(linhaInicial, colunaInicial);
        };

        Button btnDireita = rootVisualElement.Q<Button>("botaoDireita");
        btnDireita.clickable.clicked += () =>
        {
            colunaInicial++;
            posicionarMira(linhaInicial, colunaInicial);
        };

        Button btnBaixo = rootVisualElement.Q<Button>("botaoBaixo");
        btnBaixo.clickable.clicked += () =>
        {
            linhaInicial--;
            posicionarMira(linhaInicial, colunaInicial);
        };
    }
}