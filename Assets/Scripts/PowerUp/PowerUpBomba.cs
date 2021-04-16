using UnityEngine;

public class PowerUpBomba : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    private bool configurado;
    private bool acionado;

    private int bomba_explosao;
    private GameObject explosao;
    private Animator animator;

    public PowerUpBomba(GameObject tileBomb)
        : base(tileBomb, "bomba")
    {
        bomba_explosao = Animator.StringToHash("bomba-explosao");
    }

    public void consumirEvento(Collision2D evento)
    {
        Debug.Log("EXPLODIR CHAMADO");
        if(!acionado && Utils.isColetavel(evento))
        {
            acionado = true;            
            explosao.SetActive(true);
            animator.Play(bomba_explosao);
        }
    }

    public void ligar(MonoBehaviour monoBehaviour)
    {
        if (!configurado)
        {
            configurarObjetoBomba();            
        }
        base.ligar();
    }

    private void configurarObjetoBomba()
    {
        configurarDetectorDeCollider();
        configurarExplosao();
        configurarAnimator();
        configurado = true;
    }

    private void configurarDetectorDeCollider()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);
    }

    private void configurarExplosao()
    {
        explosao = goColetavel.transform.Find("explosao").gameObject;
    }

    private void configurarAnimator()
    {
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();        
    }
}
