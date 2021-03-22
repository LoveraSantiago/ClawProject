using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private float coletadoScale;//0.55586    
    [SerializeField] private SpriteRenderer[] coletadoSprites = new SpriteRenderer[3];//3
    [SerializeField] private Text scoreTextField;
    [Space(5)]
    [SerializeField] private GameObject goTriggerDeColetado;    

    public float ColetadoScale { get { return coletadoScale; } }
    public SpriteRenderer[] ColetadoPosicoes { get { return coletadoSprites; } }
    public Text ScoreTextField { get { return scoreTextField; } }

    public GameObject GoTriggerDeColetado { get { return goTriggerDeColetado; } }    
}
