using UnityEngine;
using System.Collections;

public class BombaPowerUpGo : AbstractPowerUpGo,
                              ConsumidorDeEventoCollider,
                              PowerUpInteracaoComGarra
{    
    private bool acionado;

    private int bomba_explosao;
    private int bomba_idle;
    
    private Animator animator;
    
    private CircleCollider2D circleCollider;

    public BombaPowerUpGo()
        : base(powerUpDto.BombaDto.BombaGo, "bomba")
    {
        bomba_explosao = Animator.StringToHash("explosao");
        bomba_idle     = Animator.StringToHash("idle");

        goColetavel.SetActive(false);
    }

    public PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.MOVIMENTO;
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

        animator = goColetavel.transform.Find("imagem").GetComponent<Animator>();

        circleCollider = goColetavel.GetComponent<CircleCollider2D>();
    }

    public override void iniciarPup()
    {
        ligar();
    }

    public override void resetPup()
    {
        desligar();
        animator.Play(bomba_idle);
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
        yield return new WaitForSeconds(powerUpDto.BombaDto.DelayInicial);

        //animator.Play(bomba_explosao);
        desligar();
        acionarEfeitoExplosao(getPosicao());        
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
        ColetavelQuery coletavelQuery = new ColetavelQuery();

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            Coletavel acertado = coletavelQuery.getColetavelInGameByName(nomeAcertado);
            int angulo = determinarAngulo(acertado.getPosicao());
            acertado.disparar(angulo, powerUpDto.BombaDto.VelocidadeHit);
        }
    }

    private int determinarAngulo(Vector3 posicao)
    {        
        if (getPosicao().x < posicao.x) return -powerUpDto.BombaDto.AnguloHit;
        else return powerUpDto.BombaDto.AnguloHit;
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorBomba();
    }

    public class FornecedorBomba : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new BombaPowerUpGo();
        }
    }
}
