using UnityEngine;

public class PowerUpBomba : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    private bool configurado;
    private GameObject explosao;

    public PowerUpBomba(GameObject tileBomb)
        : base(tileBomb, "bomba")
    {
        explosao = tileBomb.transform.Find("explosao").gameObject;
    }

    public void consumirEvento(Collision2D evento)
    {
        Debug.Log("EXPLODIR CHAMADO");
        if(Utils.isColetavel(evento))
        {
            Debug.Log("Dentro");
            explosao.SetActive(true);
        }
    }

    public override void ligar()
    {
        if (!configurado)
        {
            configurarDetectorDeCollider();
        }
        base.ligar();
    }

    private void configurarDetectorDeCollider()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);

        configurado = true;
    }
}
