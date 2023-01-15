using System.Collections;
using UnityEngine;

public abstract class AbstractTrocaDuplaPowerUpGo : AbstractTrocaPowerUpGo,
                                                    MiraSelecionadoOnColetavel,
                                                    Transformador<DuplaDeColetaveisDto, IEnumerator>
{
    private bool hitColetavel2;
    private Coroutine coroutine;
    private DoisAlvoColetavelSelecionado alvosSelecionados;

    public AbstractTrocaDuplaPowerUpGo(GameObject goTile, string nome) : base(goTile, nome) { }

    public override void configurarPup() { }

    public override void iniciarPup()
    {        
        hitColetavel2 = false;
        
        if (HelperColetaveisInGame.naoTemColetavelOvoInGame())
        {
            alvosSelecionados = new DoisAlvoColetavelSelecionado(true, this);
            coroutine = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(alvosSelecionados.onSelecionar(inputGame, this));
        }
        else
        {
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(ativacaoFalha());
        }
    }
    //***** IMPLEMENTACAO TrocaDuplaPowerUpGo INICIO *****
    public void coletavel1Selecionado(Coletavel coletavel)
    {
        powerUpFinalizacao.emAndamento(PowerUpEnums.ESTADO.ALVO1_SELECIONADO);
    }

    public void coletavel2Selecionado(Coletavel coletavel)
    {
        powerUpFinalizacao.emAndamento(PowerUpEnums.ESTADO.ALVO2_SELECIONADO);
    }
    //***** IMPLEMENTACAO TrocaDuplaPowerUpGo FIM *****  

    //***** IMPLEMENTACAO Transformador<DuplaDeColetaveisDto, IEnumerator> INICIO *****
    public IEnumerator transformar(DuplaDeColetaveisDto duplaDeColetaveis)
    {
        hitColetavel2 = true;
        return realizarTroca(duplaDeColetaveis);        
    }
    //***** IMPLEMENTACAO Transformador<DuplaDeColetaveisDto, IEnumerator> FIM *****

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
            ContextoEstaticoUtils.monoBehaviour.StopCoroutine(coroutine);
            alvosSelecionados.timeout();
            finalizar();
        }
    }  
    
    protected void finalizar()
    {           
        HelperColetaveisInGame.desligarMirasNosColetaveis();
        resetPup();
        powerUpFinalizacao.finalizado();
    }   
}
