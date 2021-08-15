using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollbackPowerUpGo : PowerUpNaoInteracaoComGarra,
                                 PowerUpInteracaoDisplayColetado
{
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
    
    public override void iniciarPup(){}

    public override void resetPup()
    {
        
    }

    public void resetImediato(bool reset)
    {
        if (reset)
        {
            monoBehaviour.StartCoroutine(resetNoTempo(powerUpDto.RollBackDto.DelayReset));
        }
    }

    public override void timeout()
    {
        powerUpFinalizacao.finalizado();
    }

    private IEnumerator resetNoTempo(float delayReset)
    {
        yield return new WaitForSeconds(delayReset);
        timeout();
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
