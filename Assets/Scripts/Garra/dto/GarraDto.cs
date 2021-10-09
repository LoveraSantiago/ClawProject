using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraDto 
{   
    [SerializeField] private float velocMovHorizontal;
    [SerializeField] private float velocMovCima;
    [SerializeField] private float velocMovBaixo;
    [Space(3)]
    [SerializeField] private GarraAngulosDto angulos;
    [Space(3)]        
    [SerializeField] private float velocAnguloIdle;
    [Space(3)]    
    [SerializeField] private float velocAnguloAbertura;
    [Space(3)]
    [SerializeField] private float anguloFechamento;
    [SerializeField] private float velocAnguloFechamento;
    [Space(3)]
    [SerializeField] private float posCacaNiquel;
    [Space(3)]
    [SerializeField] private Rigidbody2D rigidBody;
    [Space(3)]
    [SerializeField] private Transform  centroDaGarra;
    [SerializeField] private Transform  pincaEsquerda;
    [SerializeField] private Transform  pincaDireita;
    [SerializeField] private GameObject colisor;
    [SerializeField] private Animator   animator;
    [Space(5)]
    [SerializeField] private CaboGarraDto caboDto;

    public float VelocMovHorizontal { get { return velocMovHorizontal; } }   
    public float VelocMovCima { get { return velocMovCima; } }   
    public float VelocMovBaixo { get { return velocMovBaixo * -1; } }

    public GarraAngulosDto Angulos { get { return angulos; } }
    
    public float VelocAnguloIdle { get { return velocAnguloIdle; } }
    
    public float VelocidadeAnguloAbertura { get { return velocAnguloAbertura; } }

    public float AnguloFechamento { get { return anguloFechamento; } }
    public float VelocidadeAnguloFechamento { get { return velocAnguloFechamento; } }

    public float PosCacaNiquel { get { return posCacaNiquel; } }

    public Rigidbody2D RigidBody { get { return rigidBody; } }
    
    public Transform CentroDaGarra { get { return centroDaGarra; } }
    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }
    public GameObject Colisor { get { return colisor; } }
    public Animator Animator { get { return animator; } }

    public CaboGarraDto CaboDaGarraDto { get { return caboDto; } }

}
