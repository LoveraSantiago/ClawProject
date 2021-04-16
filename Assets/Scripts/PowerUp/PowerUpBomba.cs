using UnityEngine;

public class PowerUpBomba : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    private GameObject explosao;

    public PowerUpBomba(GameObject tileBomb)
        : base(tileBomb, "bomba")
    {
        tileBomb.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);

        explosao = tileBomb.transform.Find("explosao").gameObject;
    }

    public void consumirEvento(Collision2D evento)
    {
        Debug.Log("EXPLODIR CHAMADO");
        if(Utils.isTag(evento, "Coletavel"))
        {
            explosao.SetActive(true);
        }
    }
}
