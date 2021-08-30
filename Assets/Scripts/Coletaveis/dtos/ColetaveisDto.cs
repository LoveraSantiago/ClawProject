using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private int pontosColetado;
    [SerializeField] private int pontosAcerto;
    [Space(5)]
    [SerializeField] private GameObject sensorDeColetado;
    [SerializeField] private GameObject tile;
    [SerializeField] private CircleCollider2D referenciaColliderColetado;
    [SerializeField] private ParticleSystem efeitoColetado;
    [Space(5)]    
    [SerializeField] private Sprite[] caracteres;
    [Space(5)]
    [SerializeField] private TuboDto tuboDto;    
    [Space(5)]    
    [SerializeField] private BoardDto boardDto;

    public int PontosColetados { get { return pontosColetado; } }
    public int PontosAcerto { get { return pontosAcerto; } }

    public GameObject SensorDeColetado { get { return sensorDeColetado; } }    
    public GameObject Tile { get { return tile; } }    
    public CircleCollider2D ReferenciaColliderColetado { get { return referenciaColliderColetado; } }
    public ParticleSystem EfeitoColetado { get { return efeitoColetado; } }

    public Sprite[] Caracteres { get { return caracteres; } }

    public TuboDto TuboDto { get { return tuboDto; } }    

    public BoardDto BoardDto { get { return boardDto; } }
}
