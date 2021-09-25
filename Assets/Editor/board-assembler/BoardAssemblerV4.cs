using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardAssemblerV4 : EditorWindow
{
    [MenuItem("Window/BoardAssemblerV4")]
    public static void ShowExample()
    {
        BoardAssemblerV4 wnd = GetWindow<BoardAssemblerV4>();
        wnd.titleContent = new GUIContent("BoardAssemblerV4");
    }

    private Sprite spriteVazio;
    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;
    private ColetavelQuery coletavelQuery;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler/BoardAssemblerV4.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler/BoardAssemblerV4.uss");
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);

        coletavelQuery = new ColetavelQuery();
        ReferenciasDoBoardAssembler referenciasDoBoard = new ReferenciasDoBoardAssembler();
        NavegacaoPeloBoard navegacao = new NavegacaoPeloBoard(root, referenciasDoBoard.goMira, referenciasDoBoard.dicionarioGosBoard);
        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => colocarSprite(navegacao.getGoDaMira(), spr));

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });

        root.Q<Button>("botaoMenosTodos").clicked += () => listaDeSprites.limparTodaLista();
        root.Q<Button>("botaoMenos").clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<Button>("botaoClean").clicked += () => cleanBoard();
        root.Q<Button>("botaoProcessar").clicked += () => gerarArrayDeIds();
        root.Q<Button>("botaoCimaAll").clicked += () => navegacao.navegarCimaTotal();
        root.Q<Button>("botaoBaixoAll").clicked += () => navegacao.navegarBaixoTotal();
        root.Q<Button>("botaoEsquerdaAll").clicked += () => navegacao.navegarTrasTotal();
        root.Q<Button>("botaoDireitaAll").clicked += () => navegacao.navegarFrenteTotal();

        dicionarioGosBoard = referenciasDoBoard.dicionarioGosBoard;
        spriteVazio = listaDeSprites.getSpriteVazio();
        cleanBoard();
    }

    private void colocarSprite(GameObject go, Sprite sprite)
    {
        go.GetComponent<SpriteRenderer>().sprite = sprite;
        go.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void cleanBoard()
    {
        for (int contadorLinha = 0; contadorLinha < dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject> dicionarioLinha = dicionarioGosBoard[0];
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {                
                GameObject goIt = dicionarioGosBoard[contadorLinha][contadorColuna];
                colocarSprite(goIt, spriteVazio);

                if(isSextoElementoLinhaPar(contadorLinha, contadorColuna))                
                {
                    goIt.SetActive(false);
                }
            }
        }
    }

    private bool isSextoElementoLinhaPar(int linha, int coluna)
    {
        return linha % 2 != 0 && coluna == 6;
    }

    private void gerarArrayDeIds()
    {
        string result = "{";

        for (int contadorLinha = 0; contadorLinha < dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject> dicionarioLinha = dicionarioGosBoard[0];
            result += "{";
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goIt = dicionarioGosBoard[contadorLinha][contadorColuna];
                Sprite spriteIt = goIt.GetComponent<SpriteRenderer>().sprite;

                ColetavelEntidade coletavelEntidade = coletavelQuery.getColetavelEntidadeBySprite(spriteIt.name);

                string separador = contadorColuna == dicionarioLinha.Count - 1 ? "" : ", ";
                result += coletavelEntidade.id + separador;
            }
            string separadorFim = contadorLinha == dicionarioGosBoard.Count - 1 ? "" : ", ";
            result += "}" + separadorFim;
        }
        result += "}";
        Debug.Log(result);
    }
    //Resultado deve ser colocado como:
    //int[,] x = new int[,]  { { 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0} };
}