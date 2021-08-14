using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private BombaDto bombaDto;
    [Space(5)]
    [SerializeField] private GameObject missilNuclearPUp;
    [Space(5)]    
    [SerializeField] private MinaDto minaDto;
    [Space(5)]
    [SerializeField] private GameObject missilTeleguiadoPUp;
    [SerializeField] private PathMissilDto pathMissilDto;
    [Space(5)]
    [SerializeField] private GameObject vazioPUp;
    [Space(5)]
    [SerializeField] private Material matTeleporteIn;
    [SerializeField] private Material matTeleporteOut;
    [Space(5)]
    [SerializeField] private AsaDto asaDto;
 
    public BombaDto BombaDto { get { return bombaDto; } }
    public GameObject MissilNuclearPUp { get { return missilNuclearPUp; } }    
    public MinaDto MinaDto { get { return minaDto; } }

    public GameObject MissilTeleguiadoPUp { get { return missilTeleguiadoPUp; } }
    public PathMissilDto PathMissilDto { get { return pathMissilDto; } }

    public GameObject VazioPUp { get { return vazioPUp; } }
    public Material MatTeleporteIn { get { return matTeleporteIn; } }
    public Material MatTeleporteOut { get { return matTeleporteOut; } }

    public AsaDto AsaDto { get { return asaDto; } }
}
