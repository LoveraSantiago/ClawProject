using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private GameObject tileBomb;
    [SerializeField] private GameObject tileMissil;

 
    public GameObject TileBomb { get { return tileBomb; } }
    public GameObject TileMissil { get { return tileMissil; } }
}
