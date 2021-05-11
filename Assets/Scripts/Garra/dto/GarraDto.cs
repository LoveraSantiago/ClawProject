using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraDto 
{   //TODO TALVEZ AGRUPAR EM UM DTO DE ANGULOS MANTENDO UMA UNICA REFERENCIA
    [SerializeField] private float velocMovHorizontal;
    [SerializeField] private float velocMovCima;
    [SerializeField] private float velocMovBaixo;
    [Space(5)]
    [SerializeField] private float anguloIdleMin;
    [SerializeField] private float anguloIdleMax;
    [SerializeField] private float velocAnguloIdle;
    [Space(5)]
    [SerializeField] private float anguloAbertura;
    [SerializeField] private float velocAnguloAbertura;
    [Space(5)]
    [SerializeField] private float anguloFechamento;
    [SerializeField] private float velocAnguloFechamento;
    [Space(5)]
    [SerializeField] private Rigidbody2D rigidBody;
    [Space(5)]
    [SerializeField] private Transform centroDaGarra;
    [SerializeField] private Transform pincaEsquerda;
    [SerializeField] private Transform pincaDireita;
    [SerializeField] private GameObject colisor;
    [Space(5)]
    [SerializeField] private CaboGarraDto caboDto;

    public float VelocMovHorizontal { get { return velocMovHorizontal; } }   
    public float VelocMovCima { get { return velocMovCima; } }   
    public float VelocMovBaixo { get { return velocMovBaixo * -1; } }

    public float AnguloIdleMin { get { return anguloIdleMin; } }
    public float AnguloIdleMax { get { return anguloIdleMax; } }
    public float VelocAnguloIdle { get { return velocAnguloIdle; } }

    public float AnguloAbertura { get { return anguloAbertura; } }
    public float VelocidadeAnguloAbertura { get { return velocAnguloAbertura; } }

    public float AnguloFechamento { get { return anguloFechamento; } }
    public float VelocidadeAnguloFechamento { get { return velocAnguloFechamento; } }

    public Rigidbody2D RigidBody { get { return rigidBody; } }
    
    public Transform CentroDaGarra { get { return centroDaGarra; } }
    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }
    public GameObject Colisor { get { return colisor; } }

    public CaboGarraDto CaboDaGarraDto { get { return caboDto; } }

}
