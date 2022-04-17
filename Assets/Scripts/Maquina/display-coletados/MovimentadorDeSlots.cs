using System.Collections;
using UnityEngine;

public class MovimentadorDeSlots 
{
    private bool continuarMovimentacao;
    private PosicoesSlots posicoes;

    public MovimentadorDeSlots(SingleDisplaySlotDto singleDisplaySlotDto, SingleSlotColetadoDto singleSlotColetadoDto)
    {
        continuarMovimentacao = true;
        posicoes = new PosicoesSlots(singleDisplaySlotDto, singleSlotColetadoDto);
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
        slot.transform.localPosition = posicoes.posSlotBaixoInicial;
        Vector3 posFinal = new Vector3(slot.transform.localPosition.x, 0, slot.transform.localPosition.z);
        yield return movimentarSlot(velocidade, delay, slot, posFinal);
    }

    public IEnumerator descerSlotColetado(GameObject slot, DisplaysColetadosDto displaysSlotsDto)
    {
        float velocidade = displaysSlotsDto.VelocImg;
        float fimDelay = displaysSlotsDto.FimDelay;
        yield return movimentarSlot(velocidade, fimDelay, slot, posicoes.posSlotBaixoInicial);
    }

    public IEnumerator descerSlotNone(GameObject slot, DisplaysColetadosDto displaysSlotsDto, Executor executorFimMovimentacao)
    {
        float velocidade = displaysSlotsDto.VelocImg;
        Vector3 posFinal = new Vector3(slot.transform.localPosition.x, 0, slot.transform.localPosition.z);
        yield return movimentarSlot(velocidade, 0, slot, posFinal, executorFimMovimentacao);        
    }

    public IEnumerator subirSlotNone(GameObject slot, DisplaysColetadosDto displaysSlotsDto, Executor executorFimMovimentacao)
    {
        float velocidade = displaysSlotsDto.VelocImg;
        yield return movimentarSlot(velocidade, 0, slot, posicoes.posSlotCimaInicial, executorFimMovimentacao);        
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
