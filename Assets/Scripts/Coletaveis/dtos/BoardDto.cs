using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BoardDto
{       
    [SerializeField] private float delayVoltaBoard;
    [Space(5)]
    [SerializeField] private float velocidadeSubida;
    [SerializeField] private float subida;
    [SerializeField] private float limiteSubida;
    [SerializeField] private Transform paredeAlta;
    [SerializeField] private Transform paredeBaixa;
    [Space(5)]
    [SerializeField] private Transform boardPosicao;
    [SerializeField] private Transform posicaoRefVoltaBoard;
    [SerializeField] private Transform startBoard;
    [Space(5)]
    [SerializeField] private float posAlturaSub;
    [SerializeField] private float[] posicoesEixoY = new float[8];    
    [Space(5)]
    [SerializeField] private float acrescimoItemBoard;
    [SerializeField] private PosicaoItensDoBoardDto posicoesPares;
    [SerializeField] private PosicaoItensDoBoardDto posicoesImpares;
        
    public float DelayVoltaBoard { get { return delayVoltaBoard; } }

    public float VelocidadeSubida { get { return velocidadeSubida; } }
    public float Subida { get { return subida; } }
    public float LimiteSubida { get { return limiteSubida; } }

    public Transform ParedeAlta { get { return paredeAlta; } }
    public Transform ParedeBaixa { get { return paredeBaixa; } }

    public Transform BoardPosicao { get { return boardPosicao; } }
    public Transform StartBoard { get { return startBoard; } }
    public Transform PosicaoRefVoltaBoard { get { return posicaoRefVoltaBoard; } }
    
    public float PosAlturaSub { get { return posAlturaSub;  } }    
    public float[] PosicoesEixoY { get { return posicoesEixoY;  } }
   
    public float AcrescimoItemBoard { get { return acrescimoItemBoard; } }
    public PosicaoItensDoBoardDto PosicoesPares { get { return posicoesPares; } }
    public PosicaoItensDoBoardDto PosicoesImpares { get { return posicoesImpares; } }
}
