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

    public void iniciar(InformacaoDisplayColetado[] informacaoDisplayColetados)
    {
        coroutine = monoBehaviour.StartCoroutine(getCliqueNoDisplayDeColetados(informacaoDisplayColetados));
    }

    public override void resetPup(){}

    public void resetImediato(bool reset)
    {
        if (reset)
        {
            monoBehaviour.StartCoroutine(resetImediato(powerUpDto.RollBackDto.DelayReset));
        }
    }

    public override void timeout()
    {
        monoBehaviour.StopCoroutine(coroutine);
        powerUpFinalizacao.finalizado();
    }

    private IEnumerator getCliqueNoDisplayDeColetados(InformacaoDisplayColetado[] informacaoDisplayColetados)
    {        
        while(!finalizado)
        {
            for(int contador = 0; contador < informacaoDisplayColetados.Length; contador++)
            {
                finalizado = informacaoDisplayColetados[contador].getColetavelDoDisplayAcertado(inputGame.getPosicaoTap());
                if(finalizado)
                {
                    informacaoDisplayColetados[contador].descerSlotBaixo(monoBehaviour);
                    break;
                }
            }
            yield return null;
        }
    }

    private IEnumerator resetImediato(float delayReset)
    {
        yield return new WaitForSeconds(delayReset);
        monoBehaviour.StopCoroutine(coroutine);
        powerUpFinalizacao.finalizado();
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
