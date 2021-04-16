using UnityEngine;

public class PowerUpBomba : Coletavel,
                              GarraInteracaoComPowerUp
{
    public PowerUpBomba(GameObject tileBomb)
        : base(tileBomb, "bomba")
    {
    }   
}
