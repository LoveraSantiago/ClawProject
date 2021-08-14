using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private BombaDto bombaDto;
    [Space(3)]
    [SerializeField] private GameObject missilNuclearPUp;
    [Space(3)]
    [SerializeField] private GameObject minaTerrestrePUp;
    [Space(3)]
    [SerializeField] private GameObject missilTeleguiadoPUp;
    [SerializeField] private PathMissilDto pathMissilDto;
    [Space(3)]
    [SerializeField] private GameObject vazioPUp;
    [Space(3)]
    [SerializeField] private Material matTeleporteIn;
    [SerializeField] private Material matTeleporteOut;
    [Space(3)]
    [SerializeField] private AsaDto asaDto;
 
    public BombaDto BombaDto { get { return bombaDto; } }
    public GameObject MissilNuclearPUp { get { return missilNuclearPUp; } }
    public GameObject MinaTerrestrePUp { get { return minaTerrestrePUp; } }

    public GameObject MissilTeleguiadoPUp { get { return missilTeleguiadoPUp; } }
    public PathMissilDto PathMissilDto { get { return pathMissilDto; } }

    public GameObject VazioPUp { get { return vazioPUp; } }
    public Material MatTeleporteIn { get { return matTeleporteIn; } }
    public Material MatTeleporteOut { get { return matTeleporteOut; } }

    public AsaDto AsaDto { get { return asaDto; } }
}
