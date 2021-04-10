using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BoardDto
{  
    [SerializeField] public int xSize, ySize;
    [SerializeField] public float shakeTile;
    [SerializeField] private float delayVoltaBoard;
    [Space(5)]
    [SerializeField] private Transform posicaoRefVoltaBoard;
    [SerializeField] public Transform startBoard;
    [SerializeField] public SpriteRenderer spriteTile;
    [Space(5)]
    [SerializeField] public List<Sprite> characters = new List<Sprite>();

    public float DelayVoltaBoard { get { return delayVoltaBoard; } }
    public Transform PosicaoRefVoltaBoard { get { return posicaoRefVoltaBoard; } }
}
