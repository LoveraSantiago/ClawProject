using System.Collections;
using UnityEngine;

public abstract class AbstractTrocaDuplaPowerUpGo : PowerUpNaoInteracaoComGarra,
                                               BiTransformadorUnario<ColetavelTile, IEnumerator>
{
    private static Fornecedor<TrocadorDeOrdem> fornecedorTrocadorDeOrdem;

    private bool hitColetavel2;
    private Coroutine coroutine;

    public AbstractTrocaDuplaPowerUpGo(GameObject goTile, string nome) : base(goTile, nome) { }

    public override void configurarPup() { }

    public override void iniciarPup()
    {        
        hitColetavel2 = false;
        DoisAlvosSelecionados alvosSelecionados = new DoisAlvosSelecionados();
        coroutine = Utils.MonoBehaviour.StartCoroutine(alvosSelecionados.onSelecionados(inputGame, this));
    }

    public IEnumerator transformar(ColetavelTile entrada1, ColetavelTile entrada2)
    {
        hitColetavel2 = true;
        return realizarTroca(entrada1, entrada2);
    }    

    protected abstract IEnumerator realizarTroca(ColetavelTile coletavel1, ColetavelTile coletavel2);

    protected TrocadorDeOrdem getTrocadorDeOrdem()
    {
        return fornecedorTrocadorDeOrdem.fornecer();
    }

    public override void timeout()
    {
        if (!hitColetavel2)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.desligarMirasNosColetaveis();
            powerUpFinalizacao.finalizado();
        }
    }

    public static void configurarTrocadorDeOrdem(Fornecedor<TrocadorDeOrdem> fornecedorTrocadorDeOrdemArg)
    {
        fornecedorTrocadorDeOrdem = fornecedorTrocadorDeOrdemArg;
    }   
}
