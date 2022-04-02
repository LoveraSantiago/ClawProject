using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class MaquinaAssemblerV5 : EditorWindow
{
    [MenuItem("Window/UI Toolkit/MaquinaAssemblerV5")]
    public static void ShowExample()
    {
        MaquinaAssemblerV5 wnd = GetWindow<MaquinaAssemblerV5>();
        wnd.titleContent = new GUIContent("MaquinaAssemblerV5");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/maquina-assembler/MaquinaAssemblerV5.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/maquina-assembler/MaquinaAssemblerV5.uss");
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);
    }
}