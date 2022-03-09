using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BoardDto
{       
    [SerializeField] private float delayVoltaBoard;
    [Space(5)]
    [SerializeField] private float velocidadeSubida;
    [SerializeField] private float velocidadeDevolucao;
    [SerializeField] private float subida;
    [SerializeField] private float limiteSubida;
    [SerializeField] private Transform paredeAlta;
    [SerializeField] private Transform paredeBaixa;
    [Space(5)]
    [SerializeField] private Transform boardPosicao;
    [SerializeField] private Transform posicaoRefVoltaBoard;    
    [Space(5)]
    [SerializeField] private float posAlturaSub;     
    [Space(5)]        
    [SerializeField] private PosicaoItensDoBoardDto posicoesXPares;
    [SerializeField] private PosicaoItensDoBoardDto posicoesXImpares;
    [SerializeField] private PosicaoItensDoBoardDto posicoesY;
    [SerializeField] private PosicaoItensDoBoardDto posicoesYObstaculos;
        
    public float DelayVoltaBoard { get { return delayVoltaBoard; } }

    public float VelocidadeSubida { get { return velocidadeSubida; } }
    public float VelocidadeDevolucao { get { return velocidadeDevolucao; } }
    public float Subida { get { return subida; } }
    public float LimiteSubida { get { return limiteSubida; } }

    public Transform ParedeAlta { get { return paredeAlta; } }
    public Transform ParedeBaixa { get { return paredeBaixa; } }

    public Transform BoardPosicao { get { return boardPosicao; } }    
    public Transform PosicaoRefVoltaBoard { get { return posicaoRefVoltaBoard; } }
    
    public float PosAlturaSub { get { return posAlturaSub;  } }       
        
    public PosicaoItensDoBoardDto PosicoesXPares { get { return posicoesXPares; } }
    public PosicaoItensDoBoardDto PosicoesXImpares { get { return posicoesXImpares; } }
    public PosicaoItensDoBoardDto PosicoesY { get { return posicoesY; } }
    public PosicaoItensDoBoardDto PosicoesYObstaculos { get { return posicoesYObstaculos; } }
}
