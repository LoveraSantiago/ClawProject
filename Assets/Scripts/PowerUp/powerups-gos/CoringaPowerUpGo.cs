using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoringaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    protected static readonly string PROP_VALOR = "valor";
    protected static readonly string PROP_SPRITE_IN = "inSprite";
    protected static readonly string PROP_SPRITE_OUT = "outSprite";

    private bool finalizando;
    private Coroutine coroutineAlvo;
    private Coroutine coroutineTroca;
    private ColetavelTile coletavelSelecionado;

    public CoringaPowerUpGo() : 
        base(powerUpDto.VazioPUp, "coringa"){}

    public override void configurarPup(){}

    public override void iniciarPup()
    {
        HelperColetaveisInGame helprInGame = new HelperColetaveisInGame();
        helprInGame.ligarMirasNosColetaveis();
        coroutineAlvo = Utils.MonoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup()
    {
        Debug.Log("Reset chamado");
        coletavelSelecionado = null;
        finalizando = false;
        coroutineAlvo = null;
        coroutineTroca = null;
    }

    private IEnumerator selecionarAlvo()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis();

        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos();
        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;        
        helperInGame.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);

        coroutineTroca = Utils.MonoBehaviour.StartCoroutine(fazerTroca(coletavelSelecionado));
    }

    private IEnumerator fazerTroca(ColetavelTile coletavelTile)
    {
        HelperColetavelEntidade helperColetavelEntidade = new HelperColetavelEntidade();
        ColetavelEntidade coletavel = helperColetavelEntidade.getColetavelEntidadeBySprite(coletavelTile.nomeSprite);
        List<ColetavelEntidade> listaFamilia = helperColetavelEntidade.getListaDeColetaveisEntidadeByFamiliaExcluindo(coletavel);

        Material matTroca = new Material(powerUpDto.TeleporteDto.MatTeleporte);
        matTroca.SetTexture(PROP_SPRITE_IN, coletavelTile.getSprite().texture);
        coletavelTile.addMaterial(matTroca);

        int indiceSorteado = UtilsMath.escolherDeZeroAteLimite(listaFamilia.Count);
        Sprite sprSorteado = null;
        while (!finalizando)
        {
            ColetavelEntidade coletavelSorteado = listaFamilia[indiceSorteado];
            sprSorteado = context.dicionarioDeSprites[coletavelSorteado.nomeSprite];
            matTroca.SetTexture(PROP_SPRITE_OUT, sprSorteado.texture);

            bool houveToque = false;
            float contador = 0;
            while (contador < 1.01f)
            {
                houveToque = houveToque ? houveToque : inputGame.aconteceuTap();
                contador += Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeCoringa;
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
                contador -= Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeCoringa;
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

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.desligarMirasNosColetaveis();
        powerUpFinalizacao.preFinalizar();
        coletavelTile.receberSprite(sprSorteado);
        resetPup();
        coletavelTile.clearMaterial();
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!finalizando)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutineAlvo);
            if(coroutineTroca != null)
            {
                Utils.MonoBehaviour.StopCoroutine(coroutineTroca);
            }
            if(coletavelSelecionado != null)
            {
                coletavelSelecionado.clearMaterial();
            }
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.desligarMirasNosColetaveis();
            powerUpFinalizacao.finalizado();
            resetPup();
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
