using System.Collections;
using UnityEngine;

public abstract class AbstractTrocaDuplaPowerUpGo : AbstractTrocaPowerUpGo,
                                                    Transformador<DuplaDeColetaveisDto, IEnumerator>
{
    private bool hitColetavel2;
    private Coroutine coroutine;

    public AbstractTrocaDuplaPowerUpGo(GameObject goTile, string nome) : base(goTile, nome) { }

    public override void configurarPup() { }

    public override void iniciarPup()
    {        
        hitColetavel2 = false;
        DoisAlvosSelecionados alvosSelecionados = new DoisAlvosSelecionados();
        coroutine = Utils.MonoBehaviour.StartCoroutine(alvosSelecionados.onSelecionado(inputGame, this));
    }

    public IEnumerator transformar(DuplaDeColetaveisDto duplaDeColetaveis)
    {
        hitColetavel2 = true;
        return realizarTroca(duplaDeColetaveis);
    }    

    protected abstract IEnumerator realizarTroca(DuplaDeColetaveisDto duplaDeColetaveis);    

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
}
