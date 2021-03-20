using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ComponentesDaGarraDto 
{
    [SerializeField] private float velocMovHorizontal;
    [SerializeField] private float velocMovCima;
    [SerializeField] private float velocMovBaixo;
    [Space(5)]
    [SerializeField] private float anguloAberturaGarra;
    [SerializeField] private float velocidadeAberturaGarra;
    [Space(5)]
    [SerializeField] private float anguloFechamentoGarra;
    [SerializeField] private float velocidadeFechamentoGarra;
    [Space(5)]
    [SerializeField] private Rigidbody2D rigidBody;
    [Space(5)]    
    [SerializeField] private Transform pincaEsquerda;
    [SerializeField] private Transform pincaDireita;
    [SerializeField] private GameObject colisor;

    public float VelocMovHorizontal { get { return velocMovHorizontal; } }   
    public float VelocMovCima { get { return velocMovCima; } }   
    public float VelocMovBaixo { get { return velocMovBaixo * -1; } }

    public float AnguloAberturaGarra { get { return anguloAberturaGarra; } }
    public float VelocidadeAberturaGarra { get { return velocidadeAberturaGarra; } }

    public float AnguloFechamentoGarra { get { return anguloFechamentoGarra; } }
    public float VelocidadeFechamentoGarra { get { return velocidadeFechamentoGarra; } }

    public Rigidbody2D RigidBody { get { return rigidBody; } }
    
    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }
    public GameObject Colisor { get { return colisor; } }

}
