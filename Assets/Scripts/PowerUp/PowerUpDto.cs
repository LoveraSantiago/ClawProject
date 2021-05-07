using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private GameObject bomdPUp;
    [SerializeField] private GameObject missilPUp;
    [SerializeField] private GameObject minaTerrestrePUp;
 
    public GameObject BombPUp { get { return bomdPUp; } }
    public GameObject MissilPUp { get { return missilPUp; } }
    public GameObject MinaTerrestrePUp { get { return minaTerrestrePUp; } }
}
