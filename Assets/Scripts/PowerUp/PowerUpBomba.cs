using UnityEngine;
using System.Collections;

public class PowerUpBomba : Coletavel,
                            GarraInteracaoComPowerUp,
                            ConsumidorDeEventoCollider
{
    private bool configurado;
    private bool acionado;
    private int bomba_explosao;

    private GameObject goExplosao;
    private Animator animator;
    private static MonoBehaviour monoBehaviour;

    public PowerUpBomba(GameObject tileBomb, MonoBehaviour monoBehaviourArg)
        : base(tileBomb, "bomba")
    {
        bomba_explosao = Animator.StringToHash("bomba-explosao");
        monoBehaviour = monoBehaviourArg;
    }

    public void consumirEvento(Collision2D evento)
    {
        Debug.Log("EXPLODIR CHAMADO");
        if(!acionado && Utils.isColetavel(evento))
        {
            acionado = true;
            monoBehaviour.StartCoroutine(explodir());
        }
    }

    private IEnumerator explodir()
    {
        yield return new WaitForSeconds(0.4f);
        goExplosao.SetActive(true);
        animator.Play(bomba_explosao);
        yield return new WaitForSeconds(0.25f);
        goExplosao.SetActive(false);
        desligar();
        yield return null;
    }

    public override void ligar()
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
        goExplosao = goColetavel.transform.Find("explosao").gameObject;
    }

    private void configurarAnimator()
    {
        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();        
    }
}
