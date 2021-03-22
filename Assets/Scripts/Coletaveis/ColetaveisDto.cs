using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private float coletadoScale;//0.55586
    [SerializeField] private GameObject[] coletadoPosicoes = new GameObject[3];//3
    [SerializeField] private Text scoreTextField;
    [Space(5)]
    [SerializeField] private GameObject goTriggerDeColetado;
    private GameObject[] itensColetados = new GameObject[3];

    public float ColetadoScale { get { return coletadoScale; } }
    public GameObject[] ItensColetados { get { return itensColetados; } }
    public GameObject[] ColetadoPosicoes { get { return coletadoPosicoes; } }
    public Text ScoreTextField { get { return scoreTextField; } }

    public GameObject GoTriggerDeColetado { get { return goTriggerDeColetado; } }
}
