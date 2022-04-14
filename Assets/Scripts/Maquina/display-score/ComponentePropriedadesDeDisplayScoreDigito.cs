using UnityEngine;

public class ComponentePropriedadesDeDisplayScoreDigito
{
    protected static SegmentosScore segmentos;
    protected static Material materialEfeitoLed;
    protected static Material defaultMaterial;

    protected static Color corOriginalLed;

    public static void configurar(Material materialEfeitoLedArg, Material defaultMaterialArg, Color corOriginalLed)
    {
        segmentos = new SegmentosScore();
        materialEfeitoLed = materialEfeitoLedArg;
        ComponentePropriedadesDeDisplayScoreDigito.corOriginalLed = corOriginalLed;
        defaultMaterial = defaultMaterialArg;
    }
}
