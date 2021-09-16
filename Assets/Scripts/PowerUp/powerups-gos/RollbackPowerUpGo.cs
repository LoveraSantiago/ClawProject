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
            powerUpFinalizacao.finalizado();
        }
    }

    private IEnumerator getCliqueNoDisplayDeColetados(InformacaoDisplayColetado informacaoDisplayColetados)
    {
        //TODO adicionar delay de inicio
        if (informacaoDisplayColetados.isTodosDisplaysDesocupados())
        {
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayReset);
            if (informacaoDisplayColetados.isTodosDisplaysDesocupados())
            {
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
            powerUpFinalizacao.preFinalizar();
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayFinalizar);
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
