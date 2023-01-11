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

    public override float getDelayInicio()
    {
        return getDelayInicioMaterialize();
    }

    public override void iniciarPup()
    {
        EfeitoSpawner efeitoSpwaner = new EfeitoSpawner(powerUpDto.EfeitoMaterializeDto);
        Sprite spriteMissil = powerUpDto.MissilTeleguiadoDto.SpriteMissil;
        efeitoSpwaner.spawnPowerUp(spriteMissil, getPosicao(), new Vector3(0.3f, 1.1f, 0));
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(showMissilAposSpawnMaterialize(efeitoSpwaner));
    }

    private IEnumerator showMissilAposSpawnMaterialize(EfeitoSpawner efeitoSpwaner)
    {
        yield return new WaitForSeconds(getDelayInicio());
        ligar();
        hitColetavel = false;
        HumAlvoGOSelecionado alvoSelecionado = new HumAlvoGOSelecionado();
        coroutine = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(alvoSelecionado.onSelecionar(inputGame, this));
        efeitoSpwaner.desligar();
    }

    public override void resetPup()
    {
        desligar();
        powerUpFinalizacao.finalizado();
        efeitoFaiscas.gameObject.SetActive(false);
        animacao.parado();
        colocarNoAngulo(0);

        EfeitoParticulas efeitoExplosao = new EfeitoParticulas();
        efeitoExplosao.desligar(powerUpDto.MissilTeleguiadoDto.EfeitoExplosao);
    }   

    public IEnumerator transformar(GO entrada)
    {
        return dispararMissil(entrada);
    }
    
    private IEnumerator dispararMissil(GO go)
    {
        processarPreExplosao();
        yield return processarMissilEmRota(go);

        processarExplosao(go);
        processarPosExplosao();
        yield return new WaitForSeconds(powerUpDto.MissilTeleguiadoDto.DelayPosExplosao);

        resetPup();
        yield return null;
    } 
    
    private void processarPreExplosao()
    {
        hitColetavel = true;
        animacao.acionado();
        efeitoFaiscas.gameObject.SetActive(true);
        efeitoFaiscas.Play();
        capsuleCollider.isTrigger = true;
        somPowerUp.playSomMissil();
    }

    private IEnumerator processarMissilEmRota(GO go)
    {
        MissilTeleguiadoDto missiTeleguiadoDto = powerUpDto.MissilTeleguiadoDto;
        PathMissilDto pathMissilDto = missiTeleguiadoDto.PathMissilDto;
        float velocidadeMissil = missiTeleguiadoDto.Velocidade;
        int tamanhoDaRota = pathMissilDto.PathPointsMissil.Length;

        RotaDoMissilTeleguiado rota = new RotaDoMissilTeleguiado();
        rota.recalcularRota(go.getPosicao(), pathMissilDto);        
        yield return rota.rotaParaOAlvo(this, velocidadeMissil, tamanhoDaRota);
    }

    private void processarExplosao(GO go)
    {
        colocarNaPosicao(go.getPosicao());
        parar();
        efeitoFaiscas.Stop();
        animacao.explodir();
        acertarGo(go);

        Vector3 posicaoExplosao = getPosicao() + new Vector3(0, powerUpDto.MissilTeleguiadoDto.HalturaExplosao, 0);
        EfeitoParticulas efeitoExplosao = new EfeitoParticulas();
        efeitoExplosao.ligar(powerUpDto.MissilTeleguiadoDto.EfeitoExplosao, posicaoExplosao);
        CameraShake cameraShake = new CameraShake();        
        cameraShake.shakeEParar(powerUpDto.MissilTeleguiadoDto.CameraShakeDto);
    }

    private void processarPosExplosao()
    {
        powerUpFinalizacao.preFinalizar();
    }

    private void acertarGo(GO go)
    {
        if (go is Coletavel)
        {
            Coletavel coletavel = (Coletavel)go;
            somPowerUp.playSomExplosao();
            coletavel.disparar(powerUpDto.MissilTeleguiadoDto.VelocidadeHit, powerUpDto.MissilTeleguiadoDto.VelocidadeHit);
            coletavel.desligarMira();
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
            ContextoEstaticoUtils.monoBehaviour.StopCoroutine(coroutine);
            HelperColetaveisInGame.desligarMirasNosColetaveis();
            resetPup();
        }
    }   
}
