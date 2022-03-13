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

        HelperColetaveisInGame coletaveisInGame = new HelperColetaveisInGame();
        if (coletaveisInGame.naoTemColetavelOvoInGame())
        {
            DoisAlvoColetavelSelecionado alvosSelecionados = new DoisAlvoColetavelSelecionado(true);
            coroutine = Utils.MonoBehaviour.StartCoroutine(alvosSelecionados.onSelecionar(inputGame, this));
        }
        else
        {
            Utils.MonoBehaviour.StartCoroutine(ativacaoFalha());
        }
    }

    public IEnumerator transformar(DuplaDeColetaveisDto duplaDeColetaveis)
    {
        hitColetavel2 = true;
        return realizarTroca(duplaDeColetaveis);
    }    

    private IEnumerator ativacaoFalha()
    {
        yield return new WaitForSeconds(1f);
        finalizar();
    }

    protected abstract IEnumerator realizarTroca(DuplaDeColetaveisDto duplaDeColetaveis);    

    public override void timeout()
    {
        if (!hitColetavel2)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            finalizar();
        }
    }  
    
    private void finalizar()
    {   
        HelperColetaveisInGame coletaveisInGame = new HelperColetaveisInGame();
        coletaveisInGame.desligarMirasNosColetaveis();
        powerUpFinalizacao.finalizado();
    }
}
