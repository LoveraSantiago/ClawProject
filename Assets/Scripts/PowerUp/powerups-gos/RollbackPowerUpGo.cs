using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollbackPowerUpGo : PowerUpNaoInteracaoComGarra,
                                 PowerUpInteracaoDisplayColetado
{
    private Coroutine coroutine;

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

    public void iniciar(InformacaoDisplayColetado[] informacaoDisplayColetados)
    {
        coroutine = monoBehaviour.StartCoroutine(getCliqueNoDisplayDeColetados(informacaoDisplayColetados));
    }

    public override void resetPup(){}

    public void resetImediato(bool reset)
    {
        if (reset)
        {
            monoBehaviour.StartCoroutine(resetNoTempo(powerUpDto.RollBackDto.DelayReset));
        }
    }

    public override void timeout()
    {
        monoBehaviour.StopCoroutine(coroutine);
        powerUpFinalizacao.finalizado();
    }

    private IEnumerator getCliqueNoDisplayDeColetados(InformacaoDisplayColetado[] informacaoDisplayColetados)
    {
        bool finalizar = false;
        string selecionado = null;
        while(!finalizar)
        {
            for(int contador = 0; contador < informacaoDisplayColetados.Length; contador++)
            {
                selecionado = informacaoDisplayColetados[contador].getColetavelDoDisplayAcertado(inputGame.getPosicaoTap());
                if(selecionado != null)
                {
                    finalizar = true;
                    break;
                }
            }
            yield return null;
        }
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
