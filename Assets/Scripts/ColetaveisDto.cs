using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private float coletadoScale;//0.55586
    [SerializeField] private GameObject[] coletadoPosicoes = new GameObject[3];//3
    [SerializeField] private Text scoreTextField;

    public float ColetadoScale { get { return coletadoScale; } }
    public GameObject[] ColetadoPosicoes { get { return coletadoPosicoes; } }
    public Text ScoreTextField { get { return scoreTextField; } }
}
