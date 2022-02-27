using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PosicaoItensDoBoardDto 
{
    [SerializeField] private float inicio;    
    [SerializeField] private float total;
    [SerializeField] private float acrescimo;

    public float Acrescimo { get { return acrescimo;  } }    
    public float Inicio { get { return inicio;  } }
    public float Total { get { return total;  } }
}
