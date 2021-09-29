using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BoardAssemblerV5 : EditorWindow
{
    [MenuItem("Window/BoardAssemblerV5")]
    public static void ShowExample()
    {
        BoardAssemblerV5 wnd = GetWindow<BoardAssemblerV5>();
        wnd.titleContent = new GUIContent("BoardAssemblerV5");
    }

    private Sprite spriteVazio;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler/BoardAssemblerV5.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler/BoardAssemblerV5.uss");
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);

        ReferenciasDoBoardAssembler referenciasDoBoard = new ReferenciasDoBoardAssembler();
        NavegacaoPeloBoard navegacao = new NavegacaoPeloBoard(root, referenciasDoBoard);
        ProcessadorResult processador = new ProcessadorResult(referenciasDoBoard);
        BoardCleaner cleaner = new BoardCleaner(referenciasDoBoard);
        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => colocarSprite(navegacao.getGoDaMira(), spr));

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });

        root.Q<UnityEngine.UIElements.Button>("botaoMenosTodos").clicked += () => listaDeSprites.limparTodaLista();
        root.Q<UnityEngine.UIElements.Button>("botaoMenos").clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<UnityEngine.UIElements.Button>("botaoClean").clicked += () => cleaner.clean((go) => colocarSprVazio(go), (text) => resetText(text));
        root.Q<UnityEngine.UIElements.Button>("botaoProcessar").clicked += () => processador.gerarArrayDeIds();
        root.Q<UnityEngine.UIElements.Button>("botaoProcessarOrdem").clicked += () => processador.gerarArrayDeOrdem();
        root.Q<UnityEngine.UIElements.Button>("botaoCimaAll").clicked += () => navegacao.navegarCimaTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoBaixoAll").clicked += () => navegacao.navegarBaixoTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoEsquerdaAll").clicked += () => navegacao.navegarTrasTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoDireitaAll").clicked += () => navegacao.navegarFrenteTotal();
        root.Q<IntegerField>("ordem").RegisterValueChangedCallback(evento => colocarTexto(navegacao, evento.newValue));

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
        //Debug.Log("Troca de texto chamada");
        GameObject go = navegacao.getGoDaMira();
        Sprite spr = go.GetComponent<SpriteRenderer>().sprite;
        if (spr != null && !spr.name.Equals(spriteVazio.name))
        {
            Text text = navegacao.getTextDaMira();
            text.text = novoValor.ToString();
            //Debug.Log("Troca de texto realizada no text " + text.gameObject.name);
        }
        else
        {
            //Debug.Log("Troca de texto NAO realizada");
        }
    }
}