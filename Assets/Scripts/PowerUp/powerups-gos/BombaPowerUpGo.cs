using UnityEngine;
using System.Collections;

public class BombaPowerUpGo : AbstractPowerUpGo,
                              ConsumidorDeEventoCollider,
                              PowerUpInteracaoComGarra
{    
    private bool acionado;    

    private AnimacaoExplosaoPup animacao;
    private CircleCollider2D circleCollider;

    public BombaPowerUpGo()
        : base(powerUpDto.BombaDto.BombaGo, "bomba")
    {            
        goColetavel.SetActive(false);
    }

    public PowerUpEnums.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEnums.INTERACAOGARRA.MOVIMENTO;
    }

    public override PowerUpInteracaoComGarra getObjInteracaoComGarra()
    {
        return this;
    }

    public float getAnguloParaGarraSegurar()
    {
        return powerUpDto.BombaDto.AngGarra;
    }    

    public override void configurarPup()
    {
        goColetavel.GetComponent<DetectorDeColisoes>()
            .registrarConsumidorCollision2dOnEnter(this);

        Animator animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();
        animacao = new AnimacaoExplosaoPup(animator);

        circleCollider = goColetavel.GetComponent<CircleCollider2D>();
    }

    public override void iniciarPup()
    {
        ligar();
    }

    public override void resetPup()
    {
        desligar();
        animacao.playIdle();
        acionado = false;
        desafixarVerticalmente();
        colocarNoAngulo(0);
    }

    public void consumir(Collision2D evento)
    {        
        if(!acionado && UtilsTags.isColetavel(evento))
        {
            acionado = true;
            Utils.MonoBehaviour.StartCoroutine(explodir());
        }
    }
    
    private IEnumerator explodir()
    {        
        animacao.playPreExplodir();
        yield return new WaitForSeconds(powerUpDto.BombaDto.DelayInicial);

        EfeitoExplosao efeitoExplosao = new EfeitoExplosao(powerUpDto);
        efeitoExplosao.explodir(getPosicao());        
        processarExplosao();

        yield return new WaitForSeconds(powerUpDto.BombaDto.DelayExplosao);

        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEParar(1f, new Vector3(50, 50, 50), 50f, 0.4f);
        powerUpFinalizacao.preFinalizar();
        resetPup();
        yield return new WaitForSeconds(powerUpDto.BombaDto.DelayPosExplosao);

        powerUpFinalizacao.finalizado();
        yield return null;
    }    

    private void processarExplosao()
    {
        LayerMask mask = LayerMask.GetMask("Coletavel");
        Collider2D[] acertados = Physics2D.OverlapCircleAll(goColetavel.transform.position, powerUpDto.BombaDto.RaioExplosao, mask);
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            Coletavel acertado = helperInGame.getColetavelInGameByGoName(nomeAcertado);
            int angulo = determinarAngulo(acertado.getPosicao());
            acertado.disparar(angulo, powerUpDto.BombaDto.VelocidadeHit);
        }
    }

    private int determinarAngulo(Vector3 posicao)
    {        
        if (getPosicao().x < posicao.x) return -powerUpDto.BombaDto.AnguloHit;
        else return powerUpDto.BombaDto.AnguloHit;
    }    
}
