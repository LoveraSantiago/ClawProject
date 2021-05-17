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
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_CIMA);
        bindarComponentes(root, maquina, MaquinaColorida.BASE_PARTE);
        bindarComponentes(root, maquina, MaquinaColorida.BASE_CHAO);
        bindarComponentes(root, maquina, MaquinaColorida.BORDA_VIDRO);       
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_FRONTAL);       
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_SAIDA);       
        bindarComponentes(root, maquina, MaquinaColorida.BARRA);       
        bindarComponentes(root, maquina, MaquinaColorida.CHAO_DENTRO);       
        bindarComponentes(root, maquina, MaquinaColorida.TUBO);       
        bindarComponentes(root, maquina, MaquinaColorida.VIGA_TRAS);       

        bindarComponentes(root, maquina, MaquinaColorida.BTN_POWERUP_1);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_PARTEDENTRO_1);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_CONTORNO_1);
        bindarComponentes(root, maquina, MaquinaColorida.BTN_POWERUP_2);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_PARTEDENTRO_2);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_CONTORNO_2);
        bindarComponentes(root, maquina, MaquinaColorida.BTN_POWERUP_3);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_PARTEDENTRO_3);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_CONTORNO_3);
        bindarComponentes(root, maquina, MaquinaColorida.BTN_POWERUP_4);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_PARTEDENTRO_4);       
        bindarComponentes(root, maquina, MaquinaColorida.BTN_CONTORNO_4);
        bindarComponentes(root, maquina, MaquinaColorida.BOTAO);

        bindarComponentes(root, maquina, MaquinaColorida.PLACA_FICHA);
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_P_CIMA);
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_P_BAIXO);
        bindarComponentes(root, maquina, MaquinaColorida.QUADRADO_MAIOR);
        bindarComponentes(root, maquina, MaquinaColorida.QUADRADO_MENOR);
        bindarComponentes(root, maquina, MaquinaColorida.FURO_CIMA);
        bindarComponentes(root, maquina, MaquinaColorida.FURO_BAIXO);

        bindarComponentes(root, maquina, MaquinaColorida.DISPLAY_COLETADOS);
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_COLETADO1);
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_COLETADO2);
        bindarComponentes(root, maquina, MaquinaColorida.PLACA_COLETADO3);

        bindarComponentes(root, maquina, MaquinaColorida.DISPLAY_TIMER);
        bindarComponentes(root, maquina, MaquinaColorida.DIGITOS_TIMERS);

        bindarComponentes(root, maquina, MaquinaColorida.DISPLAY_SCORES1);
        bindarComponentes(root, maquina, MaquinaColorida.DISPLAY_SCORES2);
        bindarComponentes(root, maquina, MaquinaColorida.DISPLAY_SCORES3);
        bindarComponentes(root, maquina, MaquinaColorida.LEDS1);
        bindarComponentes(root, maquina, MaquinaColorida.LEDS2);
        bindarComponentes(root, maquina, MaquinaColorida.LEDS3);
    }    

    private void bindarComponentes(VisualElement root, MaquinaColorida maquina, string componente)
    {
        root.Q<ColorField>(componente).RegisterCallback<ChangeEvent<Color>>(
            evt => maquina.colorir(componente, evt.newValue));

        root.Q<Button>("reset-" + componente)
            .clicked += () => maquina.reset(componente);
    }
}