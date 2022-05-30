using System.Collections;
using UnityEngine;

public class ComponenteMovimentadorDeSingleDisplayDeColetado : ComponenteDtoDeSingleDisplayDeColetado
{   
    private bool continuarMovimentacao;

    public ComponenteMovimentadorDeSingleDisplayDeColetado(SingleSlotColetadoDto singleSlotColetadoDto)
        :base(singleSlotColetadoDto)
    {
        continuarMovimentacao = true;        
    }

    public void cancelarMovimentacaoDeSlot()
    {
        //Debug.Log("Cancelando movimentacao de slot");
        continuarMovimentacao = false;
    }    

    protected IEnumerator subirSlotColetado()
    {
        float velocidade = getDisplaysColetadosDto().VelocImg;
        float delay = getDisplaysColetadosDto().InicialDelay;

        GameObject goSlotBaixo = getSingleSlotColetadoDto().GoSlotBaixo;
        float posYBaixoInicial = getDisplaysColetadosDto().PosYSlotAcrescimoNeg;
        goSlotBaixo.transform.localPosition = new Vector3(goSlotBaixo.transform.localPosition.x, posYBaixoInicial, goSlotBaixo.transform.localPosition.z);

        float posYFinal = getDisplaysColetadosDto().PosYSlot;
        Vector3 posFinal = new Vector3(goSlotBaixo.transform.localPosition.x, posYFinal, goSlotBaixo.transform.localPosition.z);
        yield return movimentarSlot(velocidade, delay, goSlotBaixo, posFinal);
    }

    protected IEnumerator descerSlotColetado()
    {
        float velocidade = getDisplaysColetadosDto().VelocImg;
        float fimDelay = getDisplaysColetadosDto().FimDelay;

        GameObject goSlotBaixo = getSingleSlotColetadoDto().GoSlotBaixo;
        float posYBaixoInicial = getDisplaysColetadosDto().PosYSlotAcrescimoNeg;
        Vector3 posSlotBaixoInicial = new Vector3(goSlotBaixo.transform.localPosition.x, posYBaixoInicial, goSlotBaixo.transform.localPosition.z);

        yield return movimentarSlot(velocidade, fimDelay, goSlotBaixo, posSlotBaixoInicial);
    }

    protected IEnumerator descerSlotNone(Executor executorFimMovimentacao)
    {
        float velocidade = getDisplaysColetadosDto().VelocImg;

        GameObject goSlotCima = getSingleSlotColetadoDto().GoSlotCima;
        float posYCimaInicial = getDisplaysColetadosDto().PosYSlotAcrescimo;
        goSlotCima.transform.localPosition = new Vector3(goSlotCima.transform.localPosition.x, posYCimaInicial, goSlotCima.transform.localPosition.z);
        float posYFinal = getDisplaysColetadosDto().PosYSlot;
        Vector3 posFinal = new Vector3(goSlotCima.transform.localPosition.x, posYFinal, goSlotCima.transform.localPosition.z);

        yield return movimentarSlot(velocidade, 0, goSlotCima, posFinal, executorFimMovimentacao);        
    }

    protected IEnumerator subirSlotNone(Executor executorFimMovimentacao)
    {
        float velocidade = getDisplaysColetadosDto().VelocImg;

        GameObject goSlotCima = getSingleSlotColetadoDto().GoSlotCima;
        float posYCimaInicial = getDisplaysColetadosDto().PosYSlotAcrescimo;
        Vector3 posInicial = new Vector3(goSlotCima.transform.localPosition.x, posYCimaInicial, goSlotCima.transform.localPosition.z);

        yield return movimentarSlot(velocidade, 0, goSlotCima, posInicial, executorFimMovimentacao);        
    }

    private IEnumerator movimentarSlot(
        float velocidade, float delay, GameObject slot, Vector3 posicaoDesejada)
    {
        yield return movimentarSlot(velocidade, delay, slot, posicaoDesejada, null);
    }

    private IEnumerator movimentarSlot(
       float velocidade, float delay, GameObject slot, Vector3 posicaoDesejada, 
       Executor executorFimMovimentacao)
    {
        yield return new WaitForSeconds(delay);

        while (slotAtingiuPosicao(slot, posicaoDesejada, velocidade) && continuarMovimentacao)
        {
            moverSlotAtePosicao(slot, posicaoDesejada, velocidade);
            yield return null;
        }
        if (continuarMovimentacao)
        {
            slot.transform.localPosition = posicaoDesejada;
            yield return new WaitForSeconds(delay);
        }
        else
        {
            continuarMovimentacao = true;
        }
        executarFimMovimentacao(executorFimMovimentacao);
    }

    private void executarFimMovimentacao(Executor executorFimMovimentacao)
    {
        if (executorFimMovimentacao != null)
        {
            executorFimMovimentacao.execute();
        }
    }

    private bool slotAtingiuPosicao(GameObject slot, Vector3 posicao, float velocidade)
    {
        return (Vector3.Distance(slot.transform.localPosition, posicao))
               > (velocidade * Time.deltaTime);
    }

    private void moverSlotAtePosicao(GameObject slot, Vector3 posicao, float velocidade)
    {
        float acrescimo = velocidade * Time.deltaTime;
        slot.transform.localPosition = Vector3.MoveTowards(
                slot.transform.localPosition, posicao, acrescimo);
    }
}
