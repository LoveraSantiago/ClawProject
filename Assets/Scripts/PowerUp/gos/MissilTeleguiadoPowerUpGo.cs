using System.Collections;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractExplosivelPowerUpGo,
                                         Transformador<GO, IEnumerator>
{
    private bool hitColetavel;    

    private AnimacaoMissilTeleguiado animacao;
    private CapsuleCollider2D capsuleCollider;        
    private ParticleSystem efeitoFaiscas;
    private Coroutine coroutine;

    public MissilTeleguiadoPowerUpGo() : 
        base(powerUpDto.MissilTeleguiadoDto.MissilGo, "missil-teleguiado"){}

    public override TipoInteracaoGarra getInteracaoComGarra()
    {
        return TipoInteracaoGarra.PARADO;
    }    

    public override float getAnguloParaGarraSegurar()
    {
        return powerUpDto.MissilTeleguiadoDto.AngGarra;
    }

    public override void colocarNaPosicao(Vector3 posicao)
    {
        base.colocarNaPosicao(posicao + new Vector3(0, powerUpDto.MissilTeleguiadoDto.HalturaPos, 0));
    }

    public override void configurarPup()
    {
        capsuleCollider = extrairComponente<CapsuleCollider2D>();

        Transform transfImagem = extrairTransform("imagem");
        Animator animator = transfImagem.GetComponent<Animator>();
        animacao = new AnimacaoMissilTeleguiado(animator);
        efeitoFaiscas = transfImagem.transform.Find("faiscas")
                               .GetComponent<ParticleSystem>();
    }

    public override void iniciarPup()
    {
        ligar();
        hitColetavel = false;
        HumAlvoGOSelecionado alvoSelecionado = new HumAlvoGOSelecionado();
        coroutine = Utils.MonoBehaviour.StartCoroutine(alvoSelecionado.onSelecionar(false, inputGame, this));        
    }

    public IEnumerator transformar(GO entrada)
    {
        return disparandoMissil(entrada);
    }

    public override void resetPup()
    {
        desligar();
        powerUpFinalizacao.finalizado();
        efeitoFaiscas.gameObject.SetActive(false);
        animacao.parado();
        colocarNoAngulo(0);
    }   
    
    private IEnumerator disparandoMissil(GO go)
    {
        hitColetavel = true;

        animacao.acionado();
        efeitoFaiscas.gameObject.SetActive(true);
        efeitoFaiscas.Play();

        RotaDoMissilTeleguiado rota = new RotaDoMissilTeleguiado();
        rota.recalcularRota(go.getPosicao(), powerUpDto.MissilTeleguiadoDto.PathMissilDto);
        
        capsuleCollider.isTrigger = true;
        yield return rota.rotaParaOAlvo(this, powerUpDto.MissilTeleguiadoDto.Velocidade, powerUpDto.MissilTeleguiadoDto.PathMissilDto.PathPointsMissil.Length);

        colocarNaPosicao(go.getPosicao());
        parar();
        efeitoFaiscas.Stop();
        animacao.explodir();
        acertarGo(go);

        Vector3 posicaoExplosao = getPosicao() + new Vector3(0, powerUpDto.MissilTeleguiadoDto.HalturaExplosao, 0);
        EfeitoExplosao efeitoExplosao = new EfeitoExplosao(powerUpDto);
        efeitoExplosao.explodir(posicaoExplosao);        

        CameraShake cameraShake = new CameraShake();
        cameraShake.shakeEParar(1f, new Vector3(50, 50, 50), 50f, 0.4f);
        powerUpFinalizacao.preFinalizar();

        yield return new WaitForSeconds(powerUpDto.MissilTeleguiadoDto.DelayPosExplosao);

        resetPup();
        yield return null;
    }    

    private void acertarGo(GO go)
    {
        if (go is Coletavel)
        {
            Coletavel coletavel = (Coletavel)go;
            coletavel.disparar(powerUpDto.MissilTeleguiadoDto.VelocidadeHit, powerUpDto.MissilTeleguiadoDto.VelocidadeHit);
            coletavel.desligarAnimacao();
        }
        else
        {
            go.desligar();
        }
    }

    public override void timeout()
    {
        if (!hitColetavel)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);

            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.desligarMirasNosColetaveis();
            resetPup();
        }
    }   
}
