using System.Collections;
using UnityEngine;

public class RollbackPowerUpGo : PowerUpNaoInteracaoComGarra,
                                 PowerUpInteracaoDisplayColetado
{
    private bool finalizado;
    private int contador;
    private Coroutine coroutine;
    private InformacaoDisplayColetado informacaoDisplayColetado;

    public RollbackPowerUpGo()
        :base(powerUpDto.VazioPUp, "rollback")
    {
    }

    public RollbackPowerUpGo(GameObject go, string nome)
        : base(go, nome)
    {
    }

    public override PowerUpInteracaoDisplayColetado getObjInteracaoDisplayColetado()
    {        
        return this;
    }

    public override void configurarPup(){}
    
    public override void iniciarPup()
    {
        finalizado = false;
    }

    public void addInformacaoDisplayColetado(InformacaoDisplayColetado informacaoDisplayColetado)
    {
        this.informacaoDisplayColetado = informacaoDisplayColetado;
    }

    public Executor getExecutorDeInicio()
    {
        return new ExecutorInicio(this);
    }

    public void inicio()
    {
        contador++;
        if(contador == 3)
        {
            coroutine = Utils.MonoBehaviour.StartCoroutine(getCliqueNoDisplayDeColetados());
        }
    }

    public override void resetPup(){
        contador = 0;
    }   

    public override void timeout()
    {
        if (!finalizado)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            powerUpFinalizacao.preFinalizar();
            powerUpFinalizacao.finalizado();
        }
    }

    private IEnumerator getCliqueNoDisplayDeColetados()
    {
        //TODO adicionar delay de inicio
        //yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayInicial);
        if (informacaoDisplayColetado.isTodosDisplaysDesocupados())
        {
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayReset);
            if (informacaoDisplayColetado.isTodosDisplaysDesocupados())
            {
                Debug.Log("Pup Prefinalizar displays desocupados");
                powerUpFinalizacao.preFinalizar();
                yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayFinalizar);
                Debug.Log("Pup Finalizar displays desocupados");
                powerUpFinalizacao.finalizado();
            }
            else
            {
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
            Debug.Log("Pup Prefinalizar normal");
            powerUpFinalizacao.preFinalizar();
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayFinalizar);
            Debug.Log("Pup Finalizar normal");
            powerUpFinalizacao.finalizado();
        }
    }

    private class ExecutorInicio : Executor
    {
        private RollbackPowerUpGo rollback;

        public ExecutorInicio(RollbackPowerUpGo rollback)
        {
            this.rollback = rollback;
        }

        public void execute()
        {
            rollback.inicio();
        }
    }

    protected virtual PowerUpEntidade.TIPO getTipoRestartPup()
    {
        return PowerUpEntidade.TIPO.ROLLBACK;
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorRollback();
    }    

    public class FornecedorRollback : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new RollbackPowerUpGo();
        }
    }
}
