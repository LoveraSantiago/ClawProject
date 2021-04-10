using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BoardDto
{  
    [SerializeField] public int xSize, ySize;
    [SerializeField] public float shakeTile;
    [SerializeField] private float delayInicialVoltaBoard;
    [SerializeField] private float delayVoltaBoard;
    [Space(5)]
    [SerializeField] private Transform posicaoRefVoltaBoard;
    [SerializeField] public Transform startBoard;
    [SerializeField] private SpriteRenderer spriteTile;
    [Space(5)]
    [SerializeField] public List<Sprite> characters = new List<Sprite>();

    public float DelayInicialVoltaBoard { get { return delayInicialVoltaBoard; } }
    public float DelayVoltaBoard { get { return delayVoltaBoard; } }
    public Transform PosicaoRefVoltaBoard { get { return posicaoRefVoltaBoard; } }

    public SpriteRenderer SpriteTile { get { return spriteTile; } }
}
