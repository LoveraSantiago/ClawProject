using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections.Generic;


public class BoardAssemblerNegativo : EditorWindow
{
    [MenuItem("Window/BoardAssemblerNegativo")]
    public static void ShowExample()
    {
        BoardAssemblerNegativo wnd = GetWindow<BoardAssemblerNegativo>();
        wnd.titleContent = new GUIContent("BoardAssemblerNegativo");
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
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/board-assembler-negativo/BoardAssemblerNegativo.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/board-assembler-negativo/BoardAssemblerNegativo.uss");
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);

        ReferenciasDoBoardAssemblerNegativo referenciasDoBoard = new ReferenciasDoBoardAssemblerNegativo();
        NavegacaoPeloBoardNegativo navegacao = new NavegacaoPeloBoardNegativo(root, referenciasDoBoard);
        ProcessadorResult processador = new ProcessadorResult(referenciasDoBoard);
        BoardCleaner cleaner = new BoardCleaner(referenciasDoBoard, (go) => colocarSprVazio(go), (text) => resetText(text));
        navegacao.resetMira();
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
}