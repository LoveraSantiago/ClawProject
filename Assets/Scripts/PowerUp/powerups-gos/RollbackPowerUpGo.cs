using System.Collections;
using UnityEngine;

public class RollbackPowerUpGo : PowerUpNaoInteracaoComGarra,
                                 PowerUpInteracaoDisplayColetado
{
    private Coroutine coroutine;
    private bool finalizado;

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

    public void iniciar(InformacaoDisplayColetado informacaoDisplayColetados)
    {
        coroutine = Utils.MonoBehaviour.StartCoroutine(getCliqueNoDisplayDeColetados(informacaoDisplayColetados));
    }

    public override void resetPup(){}   

    public override void timeout()
    {
        if (!finalizado)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            powerUpFinalizacao.preFinalizar();
            powerUpFinalizacao.finalizado();
        }
    }

    private IEnumerator getCliqueNoDisplayDeColetados(InformacaoDisplayColetado informacaoDisplayColetados)
    {
        //TODO adicionar delay de inicio
        yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayInicial);
        if (informacaoDisplayColetados.isTodosDisplaysDesocupados())
        {
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayReset);
            if (informacaoDisplayColetados.isTodosDisplaysDesocupados())
            {
                Debug.Log("Pup Prefinalizar displays desocupados");
                powerUpFinalizacao.preFinalizar();
                yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayFinalizar);
                Debug.Log("Pup Finalizar displays desocupados");
                powerUpFinalizacao.finalizado();
            }
            else
            {
                informacaoDisplayColetados.restartPowerUp(getTipoRestartPup(), this);
            }
        }
        else
        {
            while (!finalizado)
            {
                finalizado = informacaoDisplayColetados.acertouDisplay(inputGame.getPosicaoTap());                    
                yield return null;
            }
            Debug.Log("Pup Prefinalizar normal");
            powerUpFinalizacao.preFinalizar();
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayFinalizar);
            Debug.Log("Pup Finalizar normal");
            powerUpFinalizacao.finalizado();
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
