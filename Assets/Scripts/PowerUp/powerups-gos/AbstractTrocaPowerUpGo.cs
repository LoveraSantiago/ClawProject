using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTrocaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    protected static readonly string PROP_SPRITE_IN = "inSprite";
    protected static readonly string PROP_SPRITE_OUT = "outSprite";
    protected static readonly string PROP_VALOR = "valor";

    protected static TrocadorDeOrdem trocadorDeOrdem;

    private bool hitColetavel2;
    private Coroutine coroutine;

    public AbstractTrocaPowerUpGo(GameObject goTile, string nome) : base(goTile, nome) { }

    public override void configurarPup() { }

    public override void iniciarPup()
    {
        ColetaveisMiras miras = new ColetaveisMiras();
        miras.ligar();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvos());
    }

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
                        Utils.MonoBehaviour.StartCoroutine(realizarTroca(coletavel1, coletavel2));
                    }
                }
            }
            yield return null;
        }
        yield return null;
    }

    protected abstract IEnumerator realizarTroca(ColetavelTile coletavel1, ColetavelTile coletavel2);

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


    public static void configurarTrocadorDeOrdem(TrocadorDeOrdem trocadorDeOrdemArg)
    {
        trocadorDeOrdem = trocadorDeOrdemArg;
    }
}
