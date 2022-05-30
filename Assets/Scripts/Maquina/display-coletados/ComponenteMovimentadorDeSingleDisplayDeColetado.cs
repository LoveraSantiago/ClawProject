using System.Collections;
using UnityEngine;

public class ComponenteMovimentadorDeSingleDisplayDeColetado : ComponenteDtoDeSingleDisplayDeColetado
{
    private static int POS_Y_FINAL = 0;
    private static float POS_Y_BAIXO_INICIAL = -0.7f;
    private static float POS_Y_CIMA_INICIAL = 0.7f;

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
        goSlotBaixo.transform.localPosition = new Vector3(goSlotBaixo.transform.localPosition.x, POS_Y_BAIXO_INICIAL, goSlotBaixo.transform.localPosition.z);

        Vector3 posFinal = new Vector3(goSlotBaixo.transform.localPosition.x, POS_Y_FINAL, goSlotBaixo.transform.localPosition.z);
        yield return movimentarSlot(velocidade, delay, goSlotBaixo, posFinal);
    }

    protected IEnumerator descerSlotColetado()
    {
        float velocidade = getDisplaysColetadosDto().VelocImg;
        float fimDelay = getDisplaysColetadosDto().FimDelay;

        GameObject goSlotBaixo = getSingleSlotColetadoDto().GoSlotBaixo;
        Vector3 posSlotBaixoInicial = new Vector3(goSlotBaixo.transform.localPosition.x, POS_Y_BAIXO_INICIAL, goSlotBaixo.transform.localPosition.z);

        yield return movimentarSlot(velocidade, fimDelay, goSlotBaixo, posSlotBaixoInicial);
    }

    protected IEnumerator descerSlotNone(Executor executorFimMovimentacao)
    {
        float velocidade = getDisplaysColetadosDto().VelocImg;

        GameObject goSlotCima = getSingleSlotColetadoDto().GoSlotCima;
        goSlotCima.transform.localPosition = new Vector3(goSlotCima.transform.localPosition.x, POS_Y_CIMA_INICIAL, goSlotCima.transform.localPosition.z);
        Vector3 posFinal = new Vector3(goSlotCima.transform.localPosition.x, POS_Y_FINAL, goSlotCima.transform.localPosition.z);

        yield return movimentarSlot(velocidade, 0, goSlotCima, posFinal, executorFimMovimentacao);        
    }

    protected IEnumerator subirSlotNone(Executor executorFimMovimentacao)
    {
        float velocidade = getDisplaysColetadosDto().VelocImg;

        GameObject goSlotCima = getSingleSlotColetadoDto().GoSlotCima;
        Vector3 posInicial = new Vector3(goSlotCima.transform.localPosition.x, POS_Y_CIMA_INICIAL, goSlotCima.transform.localPosition.z);

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
