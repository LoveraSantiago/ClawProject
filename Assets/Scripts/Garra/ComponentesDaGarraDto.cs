using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ComponentesDaGarraDto 
{
    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private float gravidadePos;
    [SerializeField] private float gravidadeNeg;
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

    public float VelocidadeMovimento { get { return velocidadeMovimento; } }   
    public float GravidadePos { get { return gravidadePos; } }   
    public float GravidadeNeg { get { return gravidadeNeg * -1; } }

    public float AnguloAberturaGarra { get { return anguloAberturaGarra; } }
    public float VelocidadeAberturaGarra { get { return velocidadeAberturaGarra; } }

    public float AnguloFechamentoGarra { get { return anguloFechamentoGarra; } }
    public float VelocidadeFechamentoGarra { get { return velocidadeFechamentoGarra; } }

    public Rigidbody2D RigidBody { get { return rigidBody; } }

    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }


}
