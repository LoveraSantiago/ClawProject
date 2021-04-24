using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BoardDto
{  
    [SerializeField] private int xSize, ySize;
    [SerializeField] private float shakeTile;
    [SerializeField] private float delayInicialVoltaBoard;
    [SerializeField] private float delayVoltaBoard;
    [Space(5)]
    [SerializeField] private Transform posicaoRefVoltaBoard;
    [SerializeField] private Transform startBoard;
    [SerializeField] private SpriteRenderer spriteTile;
    [Space(5)]
    [SerializeField] private List<Sprite> characters = new List<Sprite>();
    [SerializeField] private float[] posicoesEixoX = new float[7];
    [SerializeField] private float[] posicoesEixoY = new float[8];

    public int XSize{ get { return xSize;}}
    public int YSize{ get { return ySize; }}
    public float ShakeTile { get { return shakeTile; } }
    public float DelayInicialVoltaBoard { get { return delayInicialVoltaBoard; } }
    public float DelayVoltaBoard { get { return delayVoltaBoard; } }

    public Transform StartBoard { get { return startBoard; } }
    public Transform PosicaoRefVoltaBoard { get { return posicaoRefVoltaBoard; } }

    public List<Sprite> Characters = new List<Sprite>();
    public float[] PosicoesEixoX { get { return posicoesEixoX;  } }
    public float[] PosicoesEixoY { get { return posicoesEixoY;  } }
    public SpriteRenderer SpriteTile { get { return spriteTile; } }
    
}
