using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private float coletadoScale;//0.55586    
    [SerializeField] private SpriteRenderer[] coletadosSprites = new SpriteRenderer[3];//3
    [SerializeField] private Text scoreTextField;
    [Space(5)]
    [SerializeField] private GameObject goTriggerDeColetado;    

    public float ColetadoScale { get { return coletadoScale; } }
    public SpriteRenderer[] ColetadosPosicoes { get { return coletadosSprites; } }
    public Text ScoreTextField { get { return scoreTextField; } }

    public GameObject GoTriggerDeColetado { get { return goTriggerDeColetado; } }    
}
