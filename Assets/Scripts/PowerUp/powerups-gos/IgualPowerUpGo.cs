using System.Collections;
using UnityEngine;

public class IgualPowerUpGo : PowerUpNaoInteracaoComGarra
{
    private static readonly string PROP_SPRITE_IN = "inSprite";
    private static readonly string PROP_SPRITE_OUT = "outSprite";
    private static readonly string PROP_VALOR = "valor";

    private static TrocadorDeOrdem trocadorDeOrdem;

    private bool hitColetavel2;
    private Coroutine coroutine;

    public IgualPowerUpGo() : base(powerUpDto.VazioPUp, "igual"){ }

    public override void configurarPup() { }

    public override void iniciarPup()
    {
        ColetaveisMiras miras = new ColetaveisMiras();
        miras.ligar();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvos());
    }

    public override void resetPup() { }

    private IEnumerator selecionarAlvos()
    {
        bool hitColetavel1 = false;
        hitColetavel2 = false;

        ColetavelTile coletavel1 = null;
        ColetavelTile coletavel2 = null;

        while (!hitColetavel1)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                bool resultACertado = false;
                coletavel1 = ColetavelHit.hit(inputGame, out resultACertado);
                if (resultACertado)
                {
                    string nomeAlvo = coletavel1.nome;
                    coletavel1.ligarAnimacaoMiraSelecionado();
                    hitColetavel1 = true;
                }
            }
            yield return null;
        }

        while (!hitColetavel2)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                bool resultACertado = false;
                coletavel2 = ColetavelHit.hit(inputGame, out resultACertado);
                if (resultACertado)
                {
                    string nomeAlvo = coletavel2.nome;
                    if (!coletavel1.nome.Equals(coletavel2.nome))
                    {
                        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
                        hitColetavel2 = true;
                        Utils.MonoBehaviour.StartCoroutine(fazerIgual(coletavel1, coletavel2));
                    }
                }
            }
            yield return null;
        }
        yield return null;
    }

    private IEnumerator fazerIgual(ColetavelTile coletavel1, ColetavelTile coletavel2)
    {
        Sprite spr1 = coletavel1.getSprite();
        Sprite spr2 = coletavel2.getSprite();

        Material matIn = new Material(powerUpDto.TeleporteDto.MatTeleporte);
        matIn.SetTexture(PROP_SPRITE_IN, spr1.texture);
        matIn.SetTexture(PROP_SPRITE_OUT, spr2.texture);

        coletavel1.addMaterial(matIn);

        float contador = 0;
        while (contador < 1.01f)
        {
            contador += Time.deltaTime * powerUpDto.TeleporteDto.Velocidade;            
            matIn.SetFloat(PROP_VALOR, contador);
            yield return null;
        }

        powerUpFinalizacao.preFinalizar();
        coletavel1.receberSprite(spr2);

        coletavel1.clearMaterial();

        coletavel1.desligarAnimacao();
        yield return null;

        trocadorDeOrdem.trocarFigura(coletavel1, coletavel2);

        yield return new WaitForSeconds(powerUpDto.TeleporteDto.DelayFinal);
        powerUpFinalizacao.finalizado();
        yield return null;
    }    

    public override void timeout()
    {
        if (!hitColetavel2)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            ColetaveisMiras miras = new ColetaveisMiras();
            miras.desligar();
            powerUpFinalizacao.finalizado();
        }
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorIgual();
    }

    public class FornecedorIgual : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new IgualPowerUpGo();
        }
    }
}
