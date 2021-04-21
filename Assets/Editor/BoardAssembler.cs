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


    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BoardAssembler.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BoardAssembler.uss");
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);

        //configurarReferenciasComBoard();
        //configurarMiraPosInicial();

        //Button btn = rootVisualElement.Q<Button>("botaoCima");
        //btn.clickable.clicked += () =>
        //{
        //    Debug.Log("Fui Pressionado");
        //};
    }

    private void configurarReferenciasComBoard()
    {
        GameObject goBoardAssembler = getBoardAssembler();
        dicionarioGosBoard = inicializarDicionarioDeGosBoard(goBoardAssembler);
        goMira = inicializarGoMira(goBoardAssembler);
    }

    public void configurarMiraPosInicial()
    {
        GameObject go00 = dicionarioGosBoard[0][0];
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
}