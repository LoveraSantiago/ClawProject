using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoringaPowerUpGo : AbstractTrocaPowerUpGo,
                                Transformador<ColetavelTile, IEnumerator>
{
    private bool finalizando;

    private HumAlvoSelecionado alvoSelecionado;
    private ColetavelTile coletavelSelecionado;

    private Coroutine coroutineAlvo;    

    public CoringaPowerUpGo() : 
        base(powerUpDto.VazioPUp, "coringa")
    {
        Debug.Log("Coringa instanciado");
    }

    public override void configurarPup(){}

    public override void iniciarPup()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis();

        alvoSelecionado = new HumAlvoSelecionado();
        coroutineAlvo = Utils.MonoBehaviour.StartCoroutine(alvoSelecionado.onSelecionado(inputGame, this));
    }

    public override void resetPup()
    {
        Debug.Log("Reset chamado");
        coletavelSelecionado = null;
        finalizando = false;
        coroutineAlvo = null;        
    }

    public IEnumerator transformar(ColetavelTile entrada)
    {
        return fazerTroca(entrada);
    }

    private IEnumerator fazerTroca(ColetavelTile coletavelTile)
    {
        coletavelSelecionado = coletavelTile;

        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        HelperColetaveisInGame helperInGame     = new HelperColetaveisInGame();

        ColetavelEntidade coletavel = helperColetavel.getColetavelEntidadeBySprite(coletavelTile.nomeSprite);
        List<ColetavelEntidade> listaFamilia = helperColetavel.getListaDeColetaveisEntidadeByFamiliaExcluindo(coletavel);

        MaterialTeleporte materialTeleporte = new MaterialTeleporte();        
        materialTeleporte.addTrocaIn(coletavelTile.getSprite());
        coletavelTile.addMaterial(materialTeleporte.materialTeleporte);

        int indiceSorteado = UtilsMath.escolherDeZeroAteLimite(listaFamilia.Count);
        Sprite sprSorteado = null;
        while (!finalizando)
        {
            ColetavelEntidade coletavelSorteado = listaFamilia[indiceSorteado];
            sprSorteado = helperColetavel.getSpriteColetavelByNomeSprite(coletavelSorteado.nomeSprite);
            materialTeleporte.addTrocaOut(sprSorteado);

            bool houveToque = false;
            float contador = 0;
            while (contador < 1.01f)
            {
                houveToque = houveToque ? houveToque : inputGame.aconteceuTap();
                contador += Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeCoringa;
                materialTeleporte.addValorDeTroca(contador);
                yield return null;
            }

            if (houveToque)
            {
                break;
            }

            indiceSorteado = UtilsMath.escolherDeZeroAteLimiteDiferenteDe(listaFamilia.Count, indiceSorteado);
            coletavelSorteado = listaFamilia[indiceSorteado];
            sprSorteado = helperColetavel.getSpriteColetavelByNomeSprite(coletavelSorteado.nomeSprite);
            materialTeleporte.addTrocaIn(sprSorteado);

            houveToque = false;
            while (contador > -0.09f)
            {
                houveToque = houveToque ? houveToque : inputGame.aconteceuTap();
                contador -= Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeCoringa;
                materialTeleporte.addValorDeTroca(contador);
                yield return null;
            }

            if (houveToque)
            {
                break;
            }

            indiceSorteado = UtilsMath.escolherDeZeroAteLimiteDiferenteDe(listaFamilia.Count, indiceSorteado);
        }

        finalizando = true;
        
        helperInGame.desligarMirasNosColetaveis();
        powerUpFinalizacao.preFinalizar();
        coletavelTile.receberSprite(sprSorteado);
        getTrocadorDeOrdem().atualizar(coletavelTile);
        resetPup();        
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!finalizando)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutineAlvo);
            alvoSelecionado.stopCoroutine();
            
            if(coletavelSelecionado != null)
            {
                coletavelSelecionado.clearMaterial();
                getTrocadorDeOrdem().atualizar(coletavelSelecionado);
            }
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.desligarMirasNosColetaveis();
            powerUpFinalizacao.finalizado();
            resetPup();
        }
    }    
}
