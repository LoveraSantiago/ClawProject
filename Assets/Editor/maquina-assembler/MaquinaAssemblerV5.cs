using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;

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

        criarComponentDropDownField(root);
        maquina = new MaquinaColoridaV2();
        List<ColorField>  listaDeColorFields = new List<ColorField>();

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.PLACA_FRENTE);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.VIGAS);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.BASE_CHAO);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.BARRA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.CHAO_DENTRO);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.CABO_DA_GARRA);

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS);

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL2);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL3);

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.DISPLAY_SCORE_LEDS);      
        
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.TUBO_BASE);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.TUBO_BORDA);  
        
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.JOYSTICK_MESA_BAIXO);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.JOYSTICK_SUPORTE);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.JOYSTICK_HASTE);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.JOYSTICK_BOLA);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.JOYSTICK_BTN_SUPORTE);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.JOYSTICK_BTN);

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.ORIFICIO_FICHA);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.ORIFICIO_CARD);               
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.ORIFICIO_SETA);

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.BTN_PUP_BASE_DIREITA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.BTN_PUP_TAMPA_DIREITA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.BTN_PUP_BASE_ESQUERDA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.BTN_PUP_TAMPA_ESQUERDA);

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SCROLL_PUP_SETA_CIMA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SCROLL_PUP_DIVISORIA);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SCROLL_PUP_DIGITOS);

        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO);
        bindarComponentes(root, maquina, listaDeColorFields, ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO);

        root.Q<Button>("mapa").clicked += () => maquina.gerarMapa();
        root.Q<Button>("reset-mapa").clicked += () => {
            for(int contador = 0; contador < listaDeColorFields.Count; contador++)
            {
                listaDeColorFields[contador].value = Color.white;
            }
        };
    }
    
    private void bindarComponentes(VisualElement root, MaquinaColoridaV2 maquina, List<ColorField> listaDeColorFields, string componente)
    {
        ColorField colorField = root.Q<ColorField>(componente);
        listaDeColorFields.Add(colorField);

        colorField.RegisterCallback<ChangeEvent<Color>>(
            evt => maquina.colorir(componente, evt.newValue));

        root.Q<Button>("select-" + componente)
           .clicked += () => maquina.select(componente);

        root.Q<Button>("reset-" + componente)
            .clicked += () => colorField.value = Color.white;
    }

    private void criarComponentDropDownField(VisualElement root)
    {
        List<string> listaDeLevels = LevelHelper.getAllLevelsAlias();

        DropdownField dropDownField = new DropdownField("Dicionarios", listaDeLevels, 0);
        dropDownField.RegisterCallback<ChangeEvent<string>>((evt) => {
            if (evt.newValue != "0")
            {
                AbstractLevel level = LevelHelper.getLevelByString(evt.newValue);
                Dictionary<string, string> dicionarioDeCores = level.getDicionarioDeCores();
                foreach (KeyValuePair<string, string> entry in dicionarioDeCores)
                {
                    ColorField colorField = root.Q<ColorField>(entry.Key);
                    Color cor = Utils.getCorByHex(entry.Value);
                    colorField.value = cor;
                    maquina.colorir(entry.Key, cor);
                }
            }
        });

        root.Q<VisualElement>("linha0")
               .Add(dropDownField);
    }
}