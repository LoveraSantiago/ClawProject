using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpGameDto 
{    
    [SerializeField] private float halturaPupDraggavel;
    [Space(3)]
    [SerializeField] private GameObject vazioPUp;
    [SerializeField] private GameObject prefabPowerUpDto;
    [Space(3)]
    [SerializeField] private ParticleSystem efeitoExplosao;
    [SerializeField] private ParticleSystem efeitoSpawn;
    [SerializeField] private Material materialMaterialize;
    [Space(3)]
    [SerializeField] private GameObject goMainPup;
    [Space(3)]
    [SerializeField] private Sprite spriteOvo;
    [Space(5)]
    [SerializeField] private BombaDto bombaDto;
    [Space(5)]    
    [SerializeField] private MissilNuclearDto missilNuclearDto;
    [Space(5)]    
    [SerializeField] private MinaDto minaDto;
    [Space(5)]        
    [SerializeField] private MissilTeleguiadoDto missilTeleguiadoDto;
    [Space(5)]    
    [SerializeField] private TeleporteDto teleporteDto;
    [Space(5)]
    [SerializeField] private AsaDto asaDto;
    [Space(5)]
    [SerializeField] private AsaMiniDto asaMiniDto;
    [Space(5)]
    [SerializeField] private BuracoNegroDto buracoNegroDto;
    [Space(5)]
    [SerializeField] private RollbackDto rollBackDto;
    [Space(5)]
    [SerializeField] private MolaDto molaDto;
 
    public float HalturaPupDraggavel { get { return halturaPupDraggavel; } }

    public GameObject VazioPUp { get { return vazioPUp; } }
    public GameObject PrefabPowerUpDto { get { return prefabPowerUpDto; } }

    public ParticleSystem EfeitoExplosao { get { return efeitoExplosao;  } }
    public GameObject GoEfeitoExplosao { get { return efeitoExplosao.gameObject; } }
    public ParticleSystem EfeitoSpawn { get { return efeitoSpawn;  } }
    public Material MaterialMaterialize { get { return materialMaterialize; } }

    public GameObject GoMainPup { get { return goMainPup; } }
    public Sprite SpriteOvo { get { return spriteOvo; } }

    public BombaDto BombaDto { get { return bombaDto; } }
    public MissilNuclearDto MissilNuclearDto { get { return missilNuclearDto; } }    
    public MinaDto MinaDto { get { return minaDto; } }
    
    public MissilTeleguiadoDto MissilTeleguiadoDto { get { return missilTeleguiadoDto; }}
    public TeleporteDto TeleporteDto { get { return teleporteDto; } }   

    public AsaDto AsaDto { get { return asaDto; } }
    public AsaMiniDto AsaMiniDto { get { return asaMiniDto; } }
    public BuracoNegroDto BuracoNegroDto { get { return buracoNegroDto; } }

    public RollbackDto RollBackDto { get { return rollBackDto;  }}
    
    public MolaDto MolaDto { get { return molaDto;  } }
}
