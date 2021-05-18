using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MaquinaAssembler : EditorWindow
{
    [MenuItem("Window/MaquinaAssembler")]
    public static void ShowExample()
    {
        MaquinaAssembler wnd = GetWindow<MaquinaAssembler>();
        wnd.titleContent = new GUIContent("MaquinaAssembler");
    }

    private MaquinaColorida maquina;

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
        criarComponentDropDownField(root);

        maquina = new MaquinaColorida();
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_CIMA);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BASE_PARTE);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BASE_CHAO);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BORDA_VIDRO);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_FRONTAL);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_SAIDA);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BARRA);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.CHAO_DENTRO);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.TUBO);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.VIGA_TRAS);       

        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_POWERUP_1);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_PARTEDENTRO_1);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_CONTORNO_1);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_POWERUP_2);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_PARTEDENTRO_2);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_CONTORNO_2);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_POWERUP_3);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_PARTEDENTRO_3);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_CONTORNO_3);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_POWERUP_4);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_PARTEDENTRO_4);       
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BTN_CONTORNO_4);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BOTAO);

        bindarComponentes(root, maquina, ConstantesCoresMaquina.PARTE_CIMA);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PARTE_BAIXO);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.FURO_HASTE);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.HASTE);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.JOYSTICK_BOLA);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.FURO_BOTAO);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.BOTAO);


        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_FICHA);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_P_CIMA);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_P_BAIXO);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.QUADRADO_MAIOR);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.QUADRADO_MENOR);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.FURO_CIMA);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.FURO_BAIXO);

        bindarComponentes(root, maquina, ConstantesCoresMaquina.DISPLAY_COLETADOS);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_COLETADO1);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_COLETADO2);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.PLACA_COLETADO3);

        bindarComponentes(root, maquina, ConstantesCoresMaquina.DISPLAY_TIMER);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.DIGITOS_TIMERS);

        bindarComponentes(root, maquina, ConstantesCoresMaquina.DISPLAY_SCORES1);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.DISPLAY_SCORES2);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.DISPLAY_SCORES3);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.LEDS1);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.LEDS2);
        bindarComponentes(root, maquina, ConstantesCoresMaquina.LEDS3);

        bindarComponentes(root, maquina, ConstantesCoresMaquina.CABO_DA_GARRA);

        root.Q<Button>("mapa").clicked += () => maquina.gerarMapa();
    }    

    private void criarComponentDropDownField(VisualElement root)
    {
        List<string> dicionarios = new List<string> { "0", "1", "2" };
        DropdownField dropDownField = new DropdownField("Dicionarios", dicionarios, 0);
        dropDownField.RegisterCallback<ChangeEvent<string>>((evt) => {
            if (evt.newValue != "0")
            {
                AbstractLevel level = LevelFlowManager.getLevelByString(evt.newValue);
                Dictionary<string, string> dicionarioDeCores = level.getDicionarioDeCores();
                foreach(KeyValuePair<string, string> entry in dicionarioDeCores)
                {
                    ColorField colorField = root.Q<ColorField>(entry.Key);
                    Color cor = Utils.getCorByHex(entry.Value);
                    colorField.value = cor;
                    maquina.colorir(entry.Key, cor);
                }
            }
        });

        root.Q<VisualElement>("linha-1")
               .Add(dropDownField);
    }

    private void bindarComponentes(VisualElement root, MaquinaColorida maquina, string componente)
    {
        root.Q<ColorField>(componente).RegisterCallback<ChangeEvent<Color>>(
            evt => maquina.colorir(componente, evt.newValue));

        root.Q<Button>("select-" + componente)
           .clicked += () => maquina.select(componente);

        root.Q<Button>("reset-" + componente)
            .clicked += () => maquina.reset(componente);
    }
}