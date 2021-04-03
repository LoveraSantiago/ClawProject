using UnityEngine;
using UnityEngine.UI;

// todo - deletar esta classe
#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private float coletadoScale;//0.55586        
    [SerializeField] private Text scoreTextField;    

    public float ColetadoScale { get { return coletadoScale; } }    
    public Text ScoreTextField { get { return scoreTextField; } }    
}
