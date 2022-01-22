using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardAssemblerNegativo : EditorWindow
{
    [MenuItem("Window/assemblers/BoardAssemblerNegativo")]
    public static void ShowExample()
    {
        BoardAssemblerNegativo wnd = GetWindow<BoardAssemblerNegativo>();
        wnd.titleContent = new GUIContent("BoardAssemblerNegativo");
    }    

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler-negativo/BoardAssemblerNegativo.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler-negativo/BoardAssemblerNegativo.uss");

        HelperColetavelEntidade.configurar();
        ReferenciasDoBoardNegativo referenciasDoBoard = new ReferenciasDoBoardNegativo();
        NavegacaoPeloBoardNegativo navegacao = new NavegacaoPeloBoardNegativo(root, referenciasDoBoard);        
        ProcessadorDeColetaveis processadorColetaveis = new ProcessadorDeColetaveis(referenciasDoBoard);

        Action<Sprite> onItemSelecionado = (spr) =>
        {
            PosicaoMira posicaoMira = navegacao.getPosicaoDaMira();
            referenciasDoBoard.updateElementoGo(posicaoMira.linha, posicaoMira.coluna, spr);
        };
        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, onItemSelecionado);

        BoardCleanerNegativo cleaner = new BoardCleanerNegativo(referenciasDoBoard, navegacao, () => listaDeSprites.getSpriteVazio());
        navegacao.resetMira();


        RemontadorBoard remontador = new RemontadorBoard(referenciasDoBoard, listaDeSprites);
        DropDownLevels dropDownLevels = new DropDownLevelsNegativo(LevelHelper.getElevadorLevelsAlias());
        dropDownLevels.criarComponentDropDownField(root, cleaner, remontador);

        EventCallback<ChangeEvent<UnityEngine.Object>> onSpriteAdicionado = (e1) =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        };
        root.Q<ObjectField>("objectFieldSprite").RegisterCallback(onSpriteAdicionado);

        root.Q<Button>("botaoMenosTodos") .clicked += () => listaDeSprites.limparTodaLista();
        root.Q<Button>("botaoMenos")      .clicked += () => listaDeSprites.removerUltimaLinha();
        root.Q<Button>("botaoClean")      .clicked += () => cleaner.clean();
        root.Q<Button>("botaoProcessar")  .clicked += () => processadorColetaveis.processar();
        root.Q<Button>("botaoCimaAll")    .clicked += () => navegacao.navegarBaixoTotal();
        root.Q<Button>("botaoBaixoAll")   .clicked += () => navegacao.navegarCimaTotal();
        root.Q<Button>("botaoEsquerdaAll").clicked += () => navegacao.navegarTrasTotal();
        root.Q<Button>("botaoDireitaAll") .clicked += () => navegacao.navegarFrenteTotal();
        
        cleaner.clean();
    }    
}