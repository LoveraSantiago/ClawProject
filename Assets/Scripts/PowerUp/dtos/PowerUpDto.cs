using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private GameObject bomdPUp;
    [Space(3)]
    [SerializeField] private GameObject missilNuclearPUp;
    [Space(3)]
    [SerializeField] private GameObject minaTerrestrePUp;
    [Space(3)]
    [SerializeField] private GameObject missilTeleguiadoPUp;
    [SerializeField] private PathMissilDto pathMissilDto;
    [Space(3)]
    [SerializeField] private GameObject teleportePUp;
    [SerializeField] private Material matTeleporteIn;
    [SerializeField] private Material matTeleporteOut;
    [Space(3)]
    [SerializeField] private GameObject asaPup;
 
    public GameObject BombPUp { get { return bomdPUp; } }
    public GameObject MissilNuclearPUp { get { return missilNuclearPUp; } }
    public GameObject MinaTerrestrePUp { get { return minaTerrestrePUp; } }

    public GameObject MissilTeleguiadoPUp { get { return missilTeleguiadoPUp; } }
    public PathMissilDto PathMissilDto { get { return pathMissilDto; } }

    public GameObject TeleportePUp { get { return teleportePUp; } }
    public Material MatTeleporteIn { get { return matTeleporteIn; } }
    public Material MatTeleporteOut { get { return matTeleporteOut; } }

    public GameObject AsaPup { get { return asaPup; } }
}
