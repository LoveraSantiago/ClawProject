using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplayTimerDto 
{
    [SerializeField] private SpriteRenderer tras;
    [SerializeField] private SpriteRenderer[] segmentos;

    public SpriteRenderer Tras { get { return tras; } }
    public SpriteRenderer[] Segmentos { get { return segmentos; }}
}
