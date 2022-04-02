using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class MaquinaAssemblerV5 : EditorWindow
{
    [MenuItem("Window/assemblers/MaquinaAssemblerV5")]
    public static void ShowExample()
    {
        MaquinaAssemblerV5 wnd = GetWindow<MaquinaAssemblerV5>();
        wnd.titleContent = new GUIContent("MaquinaAssemblerV5");
    }

    private MaquinaColoridaV2 maquina;

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/maquina-assembler/MaquinaAssemblerV5.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/maquina-assembler/MaquinaAssemblerV5.uss");

        maquina = new MaquinaColoridaV2();

        bindarComponentes(root, maquina, ConstantesCoresMaquinaV2.PLACA_FRENTE);
        bindarComponentes(root, maquina, ConstantesCoresMaquinaV2.VIGAS);

        bindarComponentes(root, maquina, ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL);
        bindarComponentes(root, maquina, ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO);
        bindarComponentes(root, maquina, ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS);
    }
    
    private void bindarComponentes(VisualElement root, MaquinaColoridaV2 maquina, string componente)
    {
        root.Q<ColorField>(componente).RegisterCallback<ChangeEvent<Color>>(
            evt => maquina.colorir(componente, evt.newValue));

        root.Q<Button>("select-" + componente)
           .clicked += () => maquina.select(componente);

        root.Q<Button>("reset-" + componente)
            .clicked += () => maquina.reset(componente);
    }
}