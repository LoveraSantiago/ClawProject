using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BoardDto
{   
    [SerializeField] private float delayInicialVoltaBoard;
    [SerializeField] private float delayVoltaBoard;
    [Space(5)]
    [SerializeField] private Transform boardPosicao;
    [SerializeField] private Transform posicaoRefVoltaBoard;
    [SerializeField] private Transform startBoard;
    [Space(5)]
    [SerializeField] private float posAlturaSub;
    [SerializeField] private float[] posicoesEixoXPar = new float[7];
    [SerializeField] private float[] posicoesEixoXImpar = new float[7];
    [SerializeField] private float[] posicoesEixoY = new float[8];   
    
    public float DelayInicialVoltaBoard { get { return delayInicialVoltaBoard; } }
    public float DelayVoltaBoard { get { return delayVoltaBoard; } }

    public Transform BoardPosicao { get { return boardPosicao; } }
    public Transform StartBoard { get { return startBoard; } }
    public Transform PosicaoRefVoltaBoard { get { return posicaoRefVoltaBoard; } }
    
    public float PosAlturaSub { get { return posAlturaSub;  } }
    public float[] PosicoesEixoXPar { get { return posicoesEixoXPar;  } }
    public float[] PosicoesEixoXImpar { get { return posicoesEixoXImpar;  } }
    public float[] PosicoesEixoY { get { return posicoesEixoY;  } }
}
