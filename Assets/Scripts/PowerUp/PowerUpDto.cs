using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{    
    [SerializeField] private GameObject tileBomb;
    [SerializeField] private GameObject tileMissil;
    [SerializeField] private GameObject tileMinaTerrestre;
 
    public GameObject TileBomb { get { return tileBomb; } }
    public GameObject TileMissil { get { return tileMissil; } }
    public GameObject TileMinaTerrestre { get { return tileMinaTerrestre; } }
}
