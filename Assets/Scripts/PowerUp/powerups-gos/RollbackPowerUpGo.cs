using System.Collections;
using System.Collections.Generic;
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

    public override PowerUpInteracaoDisplayColetado getObjInteracaoDisplayColetado()
    {
        Debug.Log("Rollback como interacao display coletado");
        return this;
    }

    public override void configurarPup(){}
    
    public override void iniciarPup(){
        finalizado = false;
    }

    public void iniciar(InformacaoDisplayColetado informacaoDisplayColetados)
    {
        coroutine = monoBehaviour.StartCoroutine(getCliqueNoDisplayDeColetados(informacaoDisplayColetados));
    }

    public override void resetPup(){}   

    public override void timeout()
    {
        if (!finalizado)
        {
            monoBehaviour.StopCoroutine(coroutine);
            powerUpFinalizacao.finalizado();
        }
    }

    private IEnumerator getCliqueNoDisplayDeColetados(InformacaoDisplayColetado informacaoDisplayColetados)
    {
        if (informacaoDisplayColetados.isTodosDisplaysDesocupados())
        {
            yield return new WaitForSeconds(powerUpDto.RollBackDto.DelayReset);
            if (informacaoDisplayColetados.isTodosDisplaysDesocupados())
            {
                powerUpFinalizacao.finalizado();
            }
            else
            {
                informacaoDisplayColetados.restartPowerUp(this);
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
