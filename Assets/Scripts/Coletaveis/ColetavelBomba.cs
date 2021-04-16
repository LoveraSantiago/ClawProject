using UnityEngine;

public class ColetavelBomba : Coletavel,
                              GarraInteracaoComPowerUp
{
    public ColetavelBomba(GameObject tileBomb)
        : base(tileBomb, "bomba")
    {
    }   
}
