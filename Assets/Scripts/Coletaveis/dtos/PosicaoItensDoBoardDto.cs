using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PosicaoItensDoBoardDto 
{
    [SerializeField] private float inicio;    
    [SerializeField] private float total;    

    public float Inicio { get { return inicio;  } }
    public float Total { get { return total;  } }
}
