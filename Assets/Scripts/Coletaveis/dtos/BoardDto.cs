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
    [SerializeField] private float[] posicoesEixoXPar = new float[7];
    [SerializeField] private float[] posicoesEixoXImpar = new float[7];
    [SerializeField] private float[] posicoesEixoY = new float[8];   
        
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
    public float[] PosicoesEixoXPar { get { return posicoesEixoXPar;  } }
    public float[] PosicoesEixoXImpar { get { return posicoesEixoXImpar;  } }
    public float[] PosicoesEixoY { get { return posicoesEixoY;  } }
}
