using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private GameObject bomdPUp;
    [SerializeField] private GameObject missilNuclearPUp;
    [SerializeField] private GameObject minaTerrestrePUp;
    [SerializeField] private GameObject missilTeleguiadoPUp;
    [Space(5)]
    [SerializeField] private Transform[] pathPointsMissil;
 
    public GameObject BombPUp { get { return bomdPUp; } }
    public GameObject MissilNuclearPUp { get { return missilNuclearPUp; } }
    public GameObject MinaTerrestrePUp { get { return minaTerrestrePUp; } }
    public GameObject MissilTeleguiadoPUp { get { return missilTeleguiadoPUp; } }

    public Transform[] PathPointsMissil { get { return pathPointsMissil; } }
}
