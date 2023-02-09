using System.Collections;
using UnityEngine;

public abstract class AbstractDisplaySlotPowerUpGo : PowerUpSemInteracao,
                                                     PowerUpInteracaoComDisplayColetado
{
    private bool finalizado;
    private int contador;
    private Coroutine coroutine;

    public AbstractDisplaySlotPowerUpGo(GameObject go, string nome)
        : base(go, nome)
    {
    }

    public override InteracaoPowerUpComComponente getInteracaoComComponente()
    {
        return this;
    }    

    public override void configurarPup() { }

    public override void iniciarPup()
    {
        finalizado = false;
        somPowerUp.playSomChoque();
    }

    public override void resetPup()
    {
        contador = 0;
    }

    public override void timeout()
    {
        if (!finalizado)
        {
            Debug.Log("timeout acionado");
            ContextoEstaticoUtils.monoBehaviour.StopCoroutine(coroutine);
            informacaoDisplayColetado.restaurarEstadoAntesPowerUp(new ExecutorFim(this));
        }
    }

    public Executor getExecutorDeInicio()
    {
        return new ExecutorInicio(this);
    }

    private void inicio()
    {
        contador++;
        //Debug.Log("Inicio chamado " + contador + " vezes");
        if (contador == 3)
        {
            powerUpDto.RollBackDto.EfeitoChoque.gameObject.SetActive(true);
            coroutine = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(getCliqueNoDisplayDeColetados());
        }
    }

    private void fim()
    {
        contador--;
        //Debug.Log("Fim chamado " + (3 - contador) + " vezes");
        if (contador == 0)
        {
            powerUpFinalizacao.preFinalizar();
            powerUpFinalizacao.finalizado();
            powerUpDto.RollBackDto.EfeitoChoque.gameObject.SetActive(false);
        }
    }

    private IEnumerator getCliqueNoDisplayDeColetados()
    {
        //Debug.Log("Pup Ativado");
        if (informacaoDisplayColetado.isTodosDisplaysDesocupados())
        {
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayReset);
            if (informacaoDisplayColetado.isTodosDisplaysDesocupados())
            {
                informacaoDisplayColetado.restaurarEstadoAntesPowerUp(new ExecutorFim(this));
            }
            else
            {
                //Debug.Log("Pup Restartado");
                contador = 0;
                informacaoDisplayColetado.restartPowerUp(getTipoRestartPup(), this);
            }
        }
        else
        {
            while (!finalizado)
            {
                finalizado = informacaoDisplayColetado.acertouDisplay(inputGame.getPosicaoTap());
                yield return null;
            }            
            informacaoDisplayColetado.restaurarEstadoAntesPowerUp(new ExecutorFim(this));
        }
    }

    private class ExecutorInicio : Executor
    {
        private AbstractDisplaySlotPowerUpGo rollback;

        public ExecutorInicio(AbstractDisplaySlotPowerUpGo rollback)
        {
            this.rollback = rollback;
        }

        public void execute()
        {
            rollback.inicio();
        }
    }

    private class ExecutorFim : Executor
    {
        private AbstractDisplaySlotPowerUpGo rollback;

        public ExecutorFim(AbstractDisplaySlotPowerUpGo rollback)
        {
            this.rollback = rollback;
        }

        public void execute()
        {
            rollback.fim();
        }
    }

    protected abstract PowerUpEnums.TIPO getTipoRestartPup();            
}
