using System.Collections;
using UnityEngine;

public class MovimentadorDeSlots 
{
    private static int POS_Y_FINAL = 0;
    private static float POS_Y_BAIXO_INICIAL = -0.7f;
    private static float POS_Y_CIMA_INICIAL = 0.7f;

    private bool continuarMovimentacao;

    public MovimentadorDeSlots(SingleSlotColetadoDto singleSlotColetadoDto)
    {
        continuarMovimentacao = true;        
    }

    public void cancelarMovimentacaoDeSlot()
    {
        //Debug.Log("Cancelando movimentacao de slot");
        continuarMovimentacao = false;
    }    

    public IEnumerator subirSlotColetado(GameObject slot, DisplaysColetadosDto displaysSlotsDto)
    {
        float velocidade = displaysSlotsDto.VelocImg;
        float delay = displaysSlotsDto.InicialDelay;
        slot.transform.localPosition = new Vector3(slot.transform.localPosition.x, POS_Y_BAIXO_INICIAL, slot.transform.localPosition.z);
        Vector3 posFinal = new Vector3(slot.transform.localPosition.x, POS_Y_FINAL, slot.transform.localPosition.z);
        yield return movimentarSlot(velocidade, delay, slot, posFinal);
    }

    public IEnumerator descerSlotColetado(GameObject slot, DisplaysColetadosDto displaysSlotsDto)
    {
        float velocidade = displaysSlotsDto.VelocImg;
        float fimDelay = displaysSlotsDto.FimDelay;
        Vector3 posSlotBaixoInicial = new Vector3(slot.transform.localPosition.x, POS_Y_BAIXO_INICIAL, slot.transform.localPosition.z);
        yield return movimentarSlot(velocidade, fimDelay, slot, posSlotBaixoInicial);
    }

    public IEnumerator descerSlotNone(GameObject slot, DisplaysColetadosDto displaysSlotsDto, Executor executorFimMovimentacao)
    {
        float velocidade = displaysSlotsDto.VelocImg;
        slot.transform.localPosition = new Vector3(slot.transform.localPosition.x, POS_Y_CIMA_INICIAL, slot.transform.localPosition.z);
        Vector3 posFinal = new Vector3(slot.transform.localPosition.x, POS_Y_FINAL, slot.transform.localPosition.z);
        yield return movimentarSlot(velocidade, 0, slot, posFinal, executorFimMovimentacao);        
    }

    public IEnumerator subirSlotNone(GameObject slot, DisplaysColetadosDto displaysSlotsDto, Executor executorFimMovimentacao)
    {
        float velocidade = displaysSlotsDto.VelocImg;
        Vector3 posInicial = new Vector3(slot.transform.localPosition.x, POS_Y_CIMA_INICIAL, slot.transform.localPosition.z);
        yield return movimentarSlot(velocidade, 0, slot, posInicial, executorFimMovimentacao);        
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

        while (slotaAtingiuPosicao(slot, posicaoDesejada, velocidade) && continuarMovimentacao)
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

    private bool slotaAtingiuPosicao(GameObject slot, Vector3 posicao, float velocidade)
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
