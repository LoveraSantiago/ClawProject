using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayDeColetadoDto 
{
    [SerializeField] float inicialDelay;
    [SerializeField] float tempoReset;
    [SerializeField] float velocSubidaImg;
    [SerializeField] private SpriteRenderer[] spritesDisplayColetados = new SpriteRenderer[3]; //3

    public float InicialDelay { get { return inicialDelay; } }
    public float TempoReset { get { return tempoReset; } }
    public float VelocSubidaImg { get { return velocSubidaImg; } }
    public SpriteRenderer[] SpritesDisplayColetados { get { return spritesDisplayColetados; } }
}
