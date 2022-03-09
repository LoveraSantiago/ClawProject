using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private int pontosColetado;
    [SerializeField] private int pontosAcerto;
    [Space(5)]
    [SerializeField] private GameObject sensorDeColetado;     
    [SerializeField] private CircleCollider2D referenciaColliderColetado;
    [Space(5)]
    [SerializeField] private ParticleSystem efeitoColetado;    
    [Space(5)]        
    [SerializeField] private GameObject prefabColetaveisDto;
    [Space(5)]
    [SerializeField] private ContextoDto contextoColetavel;
    [Space(5)]
    [SerializeField] private ContextoDto contextoGaiola;
    [Space(5)]    
    [SerializeField] private DescarteTuboDto descarteTuboDto;
    [Space(5)]    
    [SerializeField] private BoardDto boardDto;

    public int PontosColetados { get { return pontosColetado; } }
    public int PontosAcerto { get { return pontosAcerto; } }

    public GameObject SensorDeColetado { get { return sensorDeColetado; } }    

    public ContextoDto ContextoColetavel { get { return contextoColetavel; } }      
    public ContextoDto ContextoGaiola { get { return contextoGaiola; } }      

    public CircleCollider2D ReferenciaColliderColetado { get { return referenciaColliderColetado; } }
    public ParticleSystem EfeitoColetado { get { return efeitoColetado; } }    
    
    public GameObject PrefabColetaveisDto { get { return prefabColetaveisDto; } }
   
    public DescarteTuboDto DescarteTuboDto { get { return descarteTuboDto; } }

    public BoardDto BoardDto { get { return boardDto; } }
}
