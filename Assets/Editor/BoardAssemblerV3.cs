using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoardAssemblerV3 : EditorWindow
{

    [MenuItem("Window/BoardAssemblerV3")]
    public static void ShowExample()
    {
        BoardAssemblerV3 wnd = GetWindow<BoardAssemblerV3>();
        wnd.titleContent = new GUIContent("BoardAssemblerV3");
    }

    private Sprite spriteVazio;
    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BoardAssemblerV3.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BoardAssemblerV3.uss");

        ReferenciasDoBoardAssembler referenciasDoBoard = new ReferenciasDoBoardAssembler();
        NavegacaoPeloBoard navegacao = new NavegacaoPeloBoard(root, referenciasDoBoard.goMira, referenciasDoBoard.dicionarioGosBoard);        
        navegacao.resetMira();

        ListaDeSprites listaDeSprites = new ListaDeSprites(root, styleSheet, (spr)=> colocarSprite(navegacao.getGoDaMira(), spr));

        root.Q<ObjectField>("objectFieldSprite").RegisterCallback<ChangeEvent<UnityEngine.Object>>(e1 =>
        {
            listaDeSprites.receberSprite((Sprite)e1.newValue);
        });
        //root.Q<Button>("botaoMais").clicked += () => criarItemLinha();
        root.Q<Button>("botaoMenos").clicked += () => listaDeSprites.removerUltimaLinha();                

        dicionarioGosBoard = referenciasDoBoard.dicionarioGosBoard;
        spriteVazio = listaDeSprites.getSpriteVazio();
        cleanBoard();
    }        

    private void colocarSprite(GameObject go, Sprite sprite)
    {
        Debug.Log(sprite);
        go.GetComponent<SpriteRenderer>().sprite = sprite;
        go.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void cleanBoard()
    {
        for(int contadorLinha = 0; contadorLinha < dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject> dicionarioLinha = dicionarioGosBoard[0];
            for(int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goIt = dicionarioGosBoard[contadorLinha][contadorColuna];
                colocarSprite(goIt, spriteVazio);
            }
        }
    }
}