using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoringaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    protected static readonly string PROP_VALOR = "valor";
    protected static readonly string PROP_SPRITE_IN = "inSprite";
    protected static readonly string PROP_SPRITE_OUT = "outSprite";

    private bool finalizando;
    private Coroutine coroutine;
    private ColetavelTile coletavelSelecionado;

    public CoringaPowerUpGo() : 
        base(powerUpDto.VazioPUp, "coringa"){}

    public override void configurarPup(){}

    public override void iniciarPup()
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.ligarMirasNosColetaveis();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup()
    {
        coletavelSelecionado = null;
        finalizando = false;
    }

    private IEnumerator selecionarAlvo()
    {        
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.ligarMirasNosColetaveis();

        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos();
        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;        
        coletavelHelper.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);

        yield return Utils.MonoBehaviour.StartCoroutine(fazerTroca(coletavelSelecionado));
    }

    private IEnumerator fazerTroca(ColetavelTile coletavelTile)
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        ColetavelEntidade coletavel = coletavelHelper.getColetavelEntidadeBySprite(coletavelTile.nomeSprite);
        List<ColetavelEntidade> listaFamilia = coletavelHelper.getListaDeColetaveisEntidadeByFamiliaExcluindo(coletavel);

        Material matTroca = new Material(powerUpDto.TeleporteDto.MatTeleporte);
        matTroca.SetTexture(PROP_SPRITE_IN, coletavelTile.getSprite().texture);
        coletavelTile.addMaterial(matTroca);

        int indiceSorteado = UtilsMath.escolherDeZeroAteLimite(listaFamilia.Count);
        Sprite sprSorteado = null;
        while (true)
        {
            ColetavelEntidade coletavelSorteado = listaFamilia[indiceSorteado];
            sprSorteado = context.dicionarioDeSprites[coletavelSorteado.nomeSprite];
            matTroca.SetTexture(PROP_SPRITE_OUT, sprSorteado.texture);

            bool houveToque = false;
            float contador = 0;
            while (contador < 1.01f)
            {
                houveToque = houveToque ? houveToque : inputGame.aconteceuTap();
                contador += Time.deltaTime * powerUpDto.TeleporteDto.Velocidade;
                matTroca.SetFloat(PROP_VALOR, contador);                
                yield return null;
            }

            if (houveToque)
            {
                break;
            }

            indiceSorteado = UtilsMath.escolherDeZeroAteLimiteDiferenteDe(listaFamilia.Count, indiceSorteado);
            coletavelSorteado = listaFamilia[indiceSorteado];
            sprSorteado = context.dicionarioDeSprites[coletavelSorteado.nomeSprite];
            matTroca.SetTexture(PROP_SPRITE_IN, sprSorteado.texture);

            houveToque = false;
            while (contador > -0.09f)
            {
                houveToque = houveToque ? houveToque : inputGame.aconteceuTap();
                contador -= Time.deltaTime * powerUpDto.TeleporteDto.Velocidade;
                matTroca.SetFloat(PROP_VALOR, contador);
                yield return null;
            }

            if (houveToque)
            {
                break;
            }

            indiceSorteado = UtilsMath.escolherDeZeroAteLimiteDiferenteDe(listaFamilia.Count, indiceSorteado);
        }

        finalizando = true;
        coletavelHelper.desligarMirasNosColetaveis();
        powerUpFinalizacao.preFinalizar();
        coletavelTile.receberSprite(sprSorteado);
        coletavelTile.clearMaterial();
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!finalizando)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            if(coletavelSelecionado != null)
            {
                coletavelSelecionado.clearMaterial();
            }
            ColetavelHelper coletavelHelper = new ColetavelHelper();
            coletavelHelper.desligarMirasNosColetaveis();
            powerUpFinalizacao.finalizado();
        }
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorCoringa();
    }

    public class FornecedorCoringa : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new CoringaPowerUpGo();
        }
    }
}
