using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayDeColetadoDto 
{
    [SerializeField] float inicialDelay;//TODO tentar tirar delay a partir da evolucao de efeito particulas
    [SerializeField] float fimDelay;//delay do reset de um display coletado para o outro
    [SerializeField] float tempoReset;//Tempo para disparar o reset dos 3 coletaveis
    [SerializeField] float velocImg;
    [Space(5)]
    [SerializeField] private SingleDisplayColetadoDto[] singleDisplayColetado = new SingleDisplayColetadoDto[3];
    [Space(5)]
    [SerializeField] private Material materialGlowDisplay;

    public float InicialDelay { get { return inicialDelay; } }
    public float FimDelay { get { return fimDelay; } }
    public float TempoReset { get { return tempoReset; } }
    public float VelocImg { get { return velocImg; } }

    public SingleDisplayColetadoDto[] SingleDisplaysColetadoDto { get { return singleDisplayColetado; } }

    public Material MaterialGlowDisplay { get { return materialGlowDisplay; } }
}
