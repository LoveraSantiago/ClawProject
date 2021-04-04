using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ComponentesDaGarraDto 
{
    [SerializeField] private float velocMovHorizontal;
    [SerializeField] private float velocMovCima;
    [SerializeField] private float velocMovBaixo;
    [Space(5)]
    [SerializeField] private float anguloIdle;
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
    [SerializeField] private Transform pincaEsquerda;
    [SerializeField] private Transform pincaDireita;
    [SerializeField] private GameObject colisor;

    public float VelocMovHorizontal { get { return velocMovHorizontal; } }   
    public float VelocMovCima { get { return velocMovCima; } }   
    public float VelocMovBaixo { get { return velocMovBaixo * -1; } }

    public float AnguloAbertura { get { return anguloAbertura; } }
    public float VelocidadeAnguloAbertura { get { return velocAnguloAbertura; } }

    public float AnguloFechamento { get { return anguloFechamento; } }
    public float VelocidadeAnguloFechamento { get { return velocAnguloFechamento; } }

    public Rigidbody2D RigidBody { get { return rigidBody; } }
    
    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }
    public GameObject Colisor { get { return colisor; } }

}
