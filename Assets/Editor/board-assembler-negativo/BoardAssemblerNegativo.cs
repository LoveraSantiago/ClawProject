using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


public class BoardAssemblerNegativo : EditorWindow
{
    [MenuItem("Window/BoardAssemblerNegativo")]
    public static void ShowExample()
    {
        BoardAssemblerNegativo wnd = GetWindow<BoardAssemblerNegativo>();
        wnd.titleContent = new GUIContent("BoardAssemblerNegativo");
    }

    private Sprite spriteVazio;
    private Preenchedor preenchedor;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler-negativo/BoardAssemblerNegativo.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler-negativo/BoardAssemblerNegativo.uss");
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);

        ColetavelHelper.configurar();
        ReferenciasDoBoardAssemblerNegativo referenciasDoBoard = new ReferenciasDoBoardAssemblerNegativo();
        NavegacaoPeloBoardNegativo navegacao = new NavegacaoPeloBoardNegativo(root, referenciasDoBoard);
        ProcessadorResult processador = new ProcessadorResult(referenciasDoBoard);
        preenchedor = new Preenchedor();
        BoardCleanerNegativo cleaner = new BoardCleanerNegativo(referenciasDoBoard, navegacao, 
            (go) => preenchedor.colocarSprVazio(go, spriteVazio), 
            (text) => preenchedor.resetText(text));
        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => preenchedor.colocarSprite(navegacao.getGoDaMira(), spr));

        RemontadorBoard remontador = new RemontadorBoard(referenciasDoBoard, listaDeSprites);
        criarComponentDropDownField(root, cleaner, remontador);

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });

        root.Q<UnityEngine.UIElements.Button>("botaoMenosTodos")    .clicked += () => listaDeSprites.limparTodaLista();
        root.Q<UnityEngine.UIElements.Button>("botaoMenos")         .clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<UnityEngine.UIElements.Button>("botaoClean")         .clicked += () => cleaner.clean();
        root.Q<UnityEngine.UIElements.Button>("botaoProcessar")     .clicked += () => processador.gerarArrayDeIds();
        root.Q<UnityEngine.UIElements.Button>("botaoProcessarOrdem").clicked += () => processador.gerarArrayDeOrdem();
        root.Q<UnityEngine.UIElements.Button>("botaoCimaAll")       .clicked += () => navegacao.navegarBaixoTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoBaixoAll")      .clicked += () => navegacao.navegarCimaTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoEsquerdaAll")   .clicked += () => navegacao.navegarTrasTotal();
        root.Q<UnityEngine.UIElements.Button>("botaoDireitaAll")    .clicked += () => navegacao.navegarFrenteTotal();
        root.Q<IntegerField>("ordem").RegisterValueChangedCallback(evento => preenchedor.colocarTexto(navegacao, evento.newValue, spriteVazio));

        spriteVazio = listaDeSprites.getSpriteVazio();
        cleaner.clean();
    }            

    private void criarComponentDropDownField(
        VisualElement root, BoardCleaner cleaner, RemontadorBoard remontador)
    {
        List<string> listaDeLevels = EditorUtils.getListaDeLevels();

        DropdownField dropDownField = new DropdownField("Dicionarios", listaDeLevels, 0);
        dropDownField.RegisterCallback<ChangeEvent<string>>((evt) => {

            cleaner.clean();

            if (evt.newValue != "0")
            {

                AbstractLevel level = LevelFlowManager.getLevelByString(evt.newValue);
                int[,] coletaveis = level.getArrayDeColetaveis();
                remontador.montarColetaveis(coletaveis, (go, spr) => preenchedor.colocarSprite(go, spr));

                BoardOrdem[] ordens = level.getBoardOrdem();
                remontador.montarLabels(ordens);
            }
        });

        root.Q<VisualElement>("espacoDropDown")
               .Add(dropDownField);
    }
}