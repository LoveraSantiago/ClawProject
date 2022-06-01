using UnityEngine;

public class ContextoEstaticoDisplayScoresDigito 
{   
    public SegmentosScore Segmentos { get; private set; }
    public Material MaterialEfeitoLed { get; private set; }
    public Material DefaultMaterial { get; private set; }
    public Color CorOriginalLed { get; private set; }

    public ContextoEstaticoDisplayScoresDigito(
        Material materialEfeitoLed, Material defaultMaterial, Color corOriginalLed)
    {
        Segmentos = new SegmentosScore();
        MaterialEfeitoLed = materialEfeitoLed;
        DefaultMaterial = defaultMaterial;
        CorOriginalLed = corOriginalLed;
    }
}
