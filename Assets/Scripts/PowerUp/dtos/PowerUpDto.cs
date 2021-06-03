using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private GameObject bomdPUp;
    [SerializeField] private GameObject missilNuclearPUp;
    [SerializeField] private GameObject minaTerrestrePUp;
    [SerializeField] private GameObject missilTeleguiadoPUp;
    [SerializeField] private GameObject teleportePUp;
    [Space(5)]    
    [SerializeField] private PathMissilDto pathMissilDto;
 
    public GameObject BombPUp { get { return bomdPUp; } }
    public GameObject MissilNuclearPUp { get { return missilNuclearPUp; } }
    public GameObject MinaTerrestrePUp { get { return minaTerrestrePUp; } }
    public GameObject MissilTeleguiadoPUp { get { return missilTeleguiadoPUp; } }
    public GameObject TeleportePUp { get { return teleportePUp; } }
        
    public PathMissilDto PathMissilDto { get { return pathMissilDto; } }
}
