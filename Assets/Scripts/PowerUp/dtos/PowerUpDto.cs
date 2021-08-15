using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private GameObject vazioPUp;
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
    [SerializeField] private RollbackDto rollBackDto;
 
    public GameObject VazioPUp { get { return vazioPUp; } }

    public BombaDto BombaDto { get { return bombaDto; } }
    public MissilNuclearDto MissilNuclearDto { get { return missilNuclearDto; } }    
    public MinaDto MinaDto { get { return minaDto; } }
    
    public MissilTeleguiadoDto MissilTeleguiadoDto { get { return missilTeleguiadoDto; }}
    public TeleporteDto TeleporteDto { get { return teleporteDto; } }   

    public AsaDto AsaDto { get { return asaDto; } }
    public RollbackDto RollBackDto { get { return rollBackDto;  }}
}
