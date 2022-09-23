using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private int pontosColetado;
    [SerializeField] private int pontosAcerto;
    [Space(3)]
    [SerializeField] private int orderColetaveis;
    [SerializeField] private int orderDestaqueColetaveis;
    [SerializeField] private int orderEscondidoColetaveis;
    [Space(3)]
    [SerializeField] private GameObject sensorDeColetado;     
    [SerializeField] private CircleCollider2D referenciaColliderColetado;
    [Space(3)]
    [SerializeField] private ParticleSystem efeitoColetado;        
    [Space(3)]
    [SerializeField] private GameObject goMainColetavel;    
    [SerializeField] private GameObject goMainGaiola;        
    [Space(3)]    
    [SerializeField] private DescarteTuboDto descarteTuboDto;
    [Space(3)]    
    [SerializeField] private BoardDto boardDto;

    public int PontosColetados { get { return pontosColetado; } }
    public int PontosAcerto { get { return pontosAcerto; } }

    public int OrderColetaveis { get { return orderColetaveis; } }
    public int OrderDestaqueColetaveis { get { return orderDestaqueColetaveis; } }
    public int OrderEscondidoColetaveis { get { return orderEscondidoColetaveis; } }

    public GameObject SensorDeColetado { get { return sensorDeColetado; } }    

    public GameObject GoMainColetavel { get { return goMainColetavel; } }      
    public GameObject GoMainGaiola { get { return goMainGaiola; } }      

    public CircleCollider2D ReferenciaColliderColetado { get { return referenciaColliderColetado; } }
    public ParticleSystem EfeitoColetado { get { return efeitoColetado; } }    
   
    public DescarteTuboDto DescarteTuboDto { get { return descarteTuboDto; } }

    public BoardDto BoardDto { get { return boardDto; } }
}
