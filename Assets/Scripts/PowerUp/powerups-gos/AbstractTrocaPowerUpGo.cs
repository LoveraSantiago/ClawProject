using System.Collections;
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
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvos());
    }

    private IEnumerator selecionarAlvos()
    {        
        hitColetavel2 = false;
        HelperColetaveisInGame helperColetavel = new HelperColetaveisInGame();
        helperColetavel.ligarMirasNosColetaveis();

        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos();        
        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
        ColetavelTile coletavel1 = selecionadorDeAlvos.coletavelSelecionado;
        coletavel1.ligarAnimacaoMiraSelecionado();

        yield return selecionadorDeAlvos.selecionarAlvoDiferenteDe(inputGame, coletavel1.nome);
        ColetavelTile coletavel2 = selecionadorDeAlvos.coletavelSelecionado;
        helperColetavel.ligarMiraAlvoFinalNoColetavel(coletavel2.nome);

        hitColetavel2 = true;
        Utils.MonoBehaviour.StartCoroutine(realizarTroca(coletavel1, coletavel2));        
    }

    protected abstract IEnumerator realizarTroca(ColetavelTile coletavel1, ColetavelTile coletavel2);

    public override void timeout()
    {
        if (!hitColetavel2)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            HelperColetaveisInGame helperColetavel = new HelperColetaveisInGame();
            helperColetavel.desligarMirasNosColetaveis();
            powerUpFinalizacao.finalizado();
        }
    }

    public static void configurarTrocadorDeOrdem(TrocadorDeOrdem trocadorDeOrdemArg)
    {
        trocadorDeOrdem = trocadorDeOrdemArg;
    }
}
