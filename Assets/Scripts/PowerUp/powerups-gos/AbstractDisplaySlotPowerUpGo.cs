using System.Collections;
using UnityEngine;

public abstract class AbstractDisplaySlotPowerUpGo : PowerUpNaoInteracaoComGarra,
                                                     PowerUpInteracaoDisplayColetado
{
    private bool finalizado;
    private int contador;
    private Coroutine coroutine;
    private InformacaoDisplayColetado informacaoDisplayColetado;   

    public AbstractDisplaySlotPowerUpGo(GameObject go, string nome)
        : base(go, nome)
    {
    }

    public override PowerUpInteracaoDisplayColetado getObjInteracaoDisplayColetado()
    {
        return this;
    }

    public override void configurarPup() { }

    public override void iniciarPup()
    {
        finalizado = false;
    }

    public void addInformacaoDisplayColetado(InformacaoDisplayColetado informacaoDisplayColetado)
    {
        this.informacaoDisplayColetado = informacaoDisplayColetado;
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
            Utils.MonoBehaviour.StopCoroutine(coroutine);
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
        Debug.Log("Inicio chamado " + contador + " vezes");
        if (contador == 3)
        {
            coroutine = Utils.MonoBehaviour.StartCoroutine(getCliqueNoDisplayDeColetados());
        }
    }

    private void fim()
    {
        contador--;
        Debug.Log("Fim chamado " + (3 - contador) + " vezes");
        if (contador == 0)
        {
            powerUpFinalizacao.preFinalizar();
            powerUpFinalizacao.finalizado();
        }
    }

    private IEnumerator getCliqueNoDisplayDeColetados()
    {
        Debug.Log("Pup Ativado");
        if (informacaoDisplayColetado.isTodosDisplaysDesocupados())
        {
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayReset);
            if (informacaoDisplayColetado.isTodosDisplaysDesocupados())
            {
                informacaoDisplayColetado.restaurarEstadoAntesPowerUp(new ExecutorFim(this));
            }
            else
            {
                Debug.Log("Pup Restartado");
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

    protected abstract PowerUpEntidade.TIPO getTipoRestartPup();        
}
