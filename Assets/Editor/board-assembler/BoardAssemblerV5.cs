using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
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

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler/BoardAssemblerV5.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler/BoardAssemblerV5.uss");

        HelperColetavelEntidade.configurar();
        ReferenciasDoBoardAssemblerPositivo referenciasDoBoard = new ReferenciasDoBoardAssemblerPositivo();
        NavegacaoPeloBoardPositivo navegacao  = new NavegacaoPeloBoardPositivo(root, referenciasDoBoard);        
        ProcessadorDeColetaveis processadorColetaveis = new ProcessadorDeColetaveis(referenciasDoBoard);
        ProcessadorDeOrdem processadorDeOrdem = new ProcessadorDeOrdem(referenciasDoBoard);
        Preenchedor preenchedor = new Preenchedor();
        BoardCleanerPositivo cleaner = new BoardCleanerPositivo(referenciasDoBoard, navegacao, () => spriteVazio);

        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr) => preenchedor.colocarSprite(navegacao.getGoDaMira(), spr));

        RemontadorBoard remontador = new RemontadorBoard(referenciasDoBoard, listaDeSprites);
        criarComponentDropDownField(root, cleaner, remontador);

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });

        root.Q<Button>("botaoMenosTodos")    .clicked += () => listaDeSprites.limparTodaLista();
        root.Q<Button>("botaoMenos")         .clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<Button>("botaoClean")         .clicked += () => cleaner.clean();
        root.Q<Button>("botaoProcessar")     .clicked += () => processadorColetaveis.processar();
        root.Q<Button>("botaoProcessarOrdem").clicked += () => processadorDeOrdem.processar();
        root.Q<Button>("botaoCimaAll")       .clicked += () => navegacao.navegarCimaTotal();
        root.Q<Button>("botaoBaixoAll")      .clicked += () => navegacao.navegarBaixoTotal();
        root.Q<Button>("botaoEsquerdaAll")   .clicked += () => navegacao.navegarTrasTotal();
        root.Q<Button>("botaoDireitaAll")    .clicked += () => navegacao.navegarFrenteTotal();
        root.Q<IntegerField>("ordem").RegisterValueChangedCallback(evento => preenchedor.colocarTexto(navegacao, evento.newValue, spriteVazio));

        spriteVazio = listaDeSprites.getSpriteVazio();
        cleaner.clean();
    }           

    private void criarComponentDropDownField(
        VisualElement root, BoardCleanerPositivo cleaner, RemontadorBoard remontador)
    {
        List<string> listaDeLevels = EditorUtils.getListaDeLevels();
        Preenchedor preenchedor = new Preenchedor();
        DropdownField dropDownField = new DropdownField("Dicionarios", listaDeLevels, 0);
        dropDownField.RegisterCallback<ChangeEvent<string>>((evt) =>{

            cleaner.clean();

            if (evt.newValue != "0")
            {

                AbstractLevel level = LevelHelper.getLevelByString(evt.newValue);
                int[,] coletaveis = level.getArrayDeColetaveis();                
                remontador.montarColetaveis(coletaveis, (go, spr) => preenchedor.colocarSprite(go, spr));

                BoardOrdem[] ordens = LevelUtils.getBoardOrdensFromLevelOrdenado(level);
                remontador.montarLabels(ordens);
            }
        });

        root.Q<VisualElement>("espacoDropDown")
               .Add(dropDownField);
    }
}