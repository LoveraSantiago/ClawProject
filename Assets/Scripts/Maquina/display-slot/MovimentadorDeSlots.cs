using System.Collections;
using UnityEngine;

public class MovimentadorDeSlots 
{
    private bool continuarMovimentacao;

    public MovimentadorDeSlots()
    {
        continuarMovimentacao = true;   
    }

    public void cancelarMovimentacaoDeSlot()
    {
        continuarMovimentacao = false;
    }    

    public IEnumerator subirSlotBaixo(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        float delay = displayDto.InicialDelay;
        yield return movimentarSlot(velocidade, delay, slot, posicaoDesejada);
    }

    public IEnumerator descerSlotBaixo(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        float fimDelay = displayDto.FimDelay;
        yield return movimentarSlot(velocidade, fimDelay, slot, posicaoDesejada);
    }

    public IEnumerator descerSlotCima(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        yield return movimentarSlot(velocidade, 0, slot, posicaoDesejada);        
    }

    public IEnumerator subirSlotCima(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        yield return movimentarSlot(velocidade, 0, slot, posicaoDesejada);        
    }

    public IEnumerator movimentarSlot(float velocidade, float delay, GameObject slot, Vector3 posicaoDesejada)
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
