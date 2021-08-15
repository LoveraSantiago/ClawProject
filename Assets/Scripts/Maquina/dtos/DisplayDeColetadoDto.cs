using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayDeColetadoDto 
{
    [SerializeField] private float inicialDelay;//TODO tentar tirar delay a partir da evolucao de efeito particulas
    [SerializeField] private float fimDelay;//delay do reset de um display coletado para o outro    
    [SerializeField] private float velocImg;
    [SerializeField] private Sprite sprVazio;
    [Space(5)]
    [SerializeField] private Material materialGlowDisplay;
    [Space(5)]
    [SerializeField] private SingleDisplayColetadoDto[] singleDisplayColetado = new SingleDisplayColetadoDto[3];

    public float InicialDelay { get { return inicialDelay; } }
    public float FimDelay { get { return fimDelay; } }    
    public float VelocImg { get { return velocImg; } }
    public Sprite SprVazio { get { return sprVazio; } }

    public SingleDisplayColetadoDto[] SingleDisplaysColetadoDto { get { return singleDisplayColetado; } }

    public Material MaterialGlowDisplay { get { return materialGlowDisplay; } }
}
