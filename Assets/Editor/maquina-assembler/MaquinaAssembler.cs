using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class MaquinaAssembler : EditorWindow
{
    [MenuItem("Window/UI Toolkit/MaquinaAssembler")]
    public static void ShowExample()
    {
        MaquinaAssembler wnd = GetWindow<MaquinaAssembler>();
        wnd.titleContent = new GUIContent("MaquinaAssembler");
    }


    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/maquina-assembler/MaquinaAssembler.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/maquina-assembler/MaquinaAssembler.uss");
        //VisualElement labelWithStyle = new Label("Hello World! With Style");
        //labelWithStyle.styleSheets.Add(styleSheet);
        //root.Add(labelWithStyle);

        MaquinaColorida maquina = new MaquinaColorida();

        root.Q<ColorField>(MaquinaColorida.PLACA_CIMA).RegisterCallback<ChangeEvent<Color>>(
            evt =>maquina.colorir(MaquinaColorida.PLACA_CIMA, evt.newValue));

        root.Q<Button>("reset-" + MaquinaColorida.PLACA_CIMA)
            .clicked += () => maquina.reset(MaquinaColorida.PLACA_CIMA);

        root.Q<ColorField>(MaquinaColorida.BASE_PARTE).RegisterCallback<ChangeEvent<Color>>(
            evt =>maquina.colorir(MaquinaColorida.BASE_PARTE, evt.newValue));

        root.Q<Button>("reset-" + MaquinaColorida.BASE_PARTE)
            .clicked += () => maquina.reset(MaquinaColorida.BASE_PARTE);
    }    
}