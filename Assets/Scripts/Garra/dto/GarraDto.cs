using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraDto 
{       
    [SerializeField] private GarraVelocidadesDto velocidades;
    [Space(3)]
    [SerializeField] private GarraAngulosDto angulos;    
    [Space(5)]
    [SerializeField] private CaboGarraDto caboDto;       
    [Space(5)]        
    [SerializeField] private float posCacaNiquel;    
    [Space(3)]
    [SerializeField] private Rigidbody2D rigidBody;    
    [SerializeField] private Transform  centroDaGarra;
    [SerializeField] private Transform  pincaEsquerda;
    [SerializeField] private Transform  pincaDireita;
    [SerializeField] private GameObject colisor;
    [SerializeField] private Animator   animator;
    [Space(3)]
    [SerializeField] private ParticleSystem efeitoTrail;

    public GarraVelocidadesDto Velocidades { get { return velocidades; } }
    public GarraAngulosDto Angulos { get { return angulos; } }    

    public float PosCacaNiquel { get { return posCacaNiquel; } }

    public Rigidbody2D RigidBody { get { return rigidBody; } }
    
    public Transform CentroDaGarra { get { return centroDaGarra; } }
    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }
    public GameObject Colisor { get { return colisor; } }
    public Animator Animator { get { return animator; } }
    public ParticleSystem EfeitoTrail { get { return efeitoTrail; } }

    public CaboGarraDto CaboDaGarraDto { get { return caboDto; } }

}
