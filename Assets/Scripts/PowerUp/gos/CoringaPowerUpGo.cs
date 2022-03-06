using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoringaPowerUpGo : AbstractTrocaPowerUpGo,
                                Transformador<Coletavel, IEnumerator>
{
    private bool finalizando;

    private HumAlvoSelecionado alvoSelecionado;
    private Coletavel coletavelSelecionado;

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
        helperInGame.ligarMirasNosColetaveis(true);

        alvoSelecionado = new HumAlvoSelecionado();
        coroutineAlvo = Utils.MonoBehaviour.StartCoroutine(alvoSelecionado.onSelecionado(true, inputGame, this));
    }

    public override void resetPup()
    {
        Debug.Log("Reset chamado");
        coletavelSelecionado = null;
        finalizando = false;
        coroutineAlvo = null;        
    }

    public IEnumerator transformar(Coletavel entrada)
    {
        return fazerTroca(entrada);
    }

    private IEnumerator fazerTroca(Coletavel coletavel)
    {
        coletavelSelecionado = coletavel;

        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        HelperColetaveisInGame helperInGame     = new HelperColetaveisInGame();

        ColetavelEntidade coletavelEntidade = helperColetavel.getColetavelEntidadeBySprite(coletavel.nomeSprite);
        List<ColetavelEntidade> listaFamilia = helperColetavel.getListaDeColetaveisEntidadeByFamiliaExcluindo(coletavelEntidade);

        MaterialTeleporte materialTeleporte = new MaterialTeleporte();        
        materialTeleporte.addTrocaIn(coletavel.getSprite());
        coletavel.addMaterial(materialTeleporte.materialTeleporte);

        int indiceSorteado = MathUtils.escolherDeZeroAteLimite(listaFamilia.Count);
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

            indiceSorteado = MathUtils.escolherDeZeroAteLimiteDiferenteDe(listaFamilia.Count, indiceSorteado);
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

            indiceSorteado = MathUtils.escolherDeZeroAteLimiteDiferenteDe(listaFamilia.Count, indiceSorteado);
        }

        finalizando = true;
        
        helperInGame.desligarMirasNosColetaveis();
        powerUpFinalizacao.preFinalizar();
        coletavel.receberSprite(sprSorteado);
        getTrocadorDeOrdem().atualizar(coletavel);
        resetPup();        
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!finalizando)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutineAlvo);
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
