using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplayTimerDto 
{
    [SerializeField] private SpriteRenderer placaIndividual;    
    [SerializeField] private SpriteRenderer segmentos;

    public SpriteRenderer PlacaIndividual { get { return placaIndividual; } }    
    public SpriteRenderer Segmentos { get { return segmentos; }}
}
