using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class BoardAssemblerV4 : EditorWindow
{
    [MenuItem("Window/BoardAssemblerV4")]
    public static void ShowExample()
    {
        BoardAssemblerV4 wnd = GetWindow<BoardAssemblerV4>();
        wnd.titleContent = new GUIContent("BoardAssemblerV4");
    }

    private Sprite spriteVazio;
    private ColetavelQuery coletavelQuery;    
    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;    

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
        NavegacaoPeloBoard navegacao = new NavegacaoPeloBoard(root, referenciasDoBoard);
        BoardCleaner cleaner = new BoardCleaner(referenciasDoBoard);
        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => colocarSprite(navegacao.getGoDaMira(), spr));

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });

        root.Q<UnityEngine.UIElements.Button>("botaoMenosTodos").clicked += () => listaDeSprites.limparTodaLista();
        root.Q<UnityEngine.UIElements.Button>("botaoMenos").clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<UnityEngine.UIElements.Button>("botaoClean").clicked += () => cleaner.clean((go) => colocarSprVazio(go), (text)=> resetText(text));
        root.Q<UnityEngine.UIElements.Button>("botaoProcessar").clicked += () => gerarArrayDeIds();
        root.Q<UnityEngine.UIElements.Button>("botaoCimaAll").clicked += () => navegacao.navegarCimaTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoBaixoAll").clicked += () => navegacao.navegarBaixoTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoEsquerdaAll").clicked += () => navegacao.navegarTrasTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoDireitaAll").clicked += () => navegacao.navegarFrenteTotal();
        root.Q<IntegerField>("ordem").RegisterValueChangedCallback(evento => colocarTexto(navegacao, evento.newValue));            

        dicionarioGosBoard = referenciasDoBoard.dicionarioGosBoard;
        spriteVazio = listaDeSprites.getSpriteVazio();
        cleaner.clean((go) => colocarSprVazio(go), (text) => resetText(text));
    }

    private void colocarSprite(GameObject go, Sprite sprite)
    {
        go.GetComponent<SpriteRenderer>().sprite = sprite;
        go.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void colocarSprVazio(GameObject go)
    {
        colocarSprite(go, spriteVazio);
    }

    private void resetText(Text text)
    {
        text.text = "00";
    }

    private void colocarTexto(NavegacaoPeloBoard navegacao, int novoValor)
    {
        GameObject go = navegacao.getGoDaMira();
        Sprite spr = go.GetComponent<SpriteRenderer>().sprite;
        if (spr != null && spr.name.Equals(spriteVazio.name))
        {
            Text text = navegacao.getTextDaMira();
            text.text = novoValor.ToString();
        }
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