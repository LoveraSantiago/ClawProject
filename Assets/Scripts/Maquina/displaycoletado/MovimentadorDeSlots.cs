using System.Collections;
using UnityEngine;

public class MovimentadorDeSlots 
{
    public IEnumerator subirSlotBaixo(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        float delay = displayDto.InicialDelay;
        yield return new WaitForSeconds(delay);

        while (slotaAtingiuPosicao(slot, posicaoDesejada, velocidade))
        {
            moverSlotAtePosicao(slot, posicaoDesejada, velocidade);
            yield return null;
        }

        slot.transform.localPosition = posicaoDesejada;
        yield return new WaitForSeconds(delay);        
    }

    public IEnumerator descerSlotBaixo(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        float fimDelay = displayDto.FimDelay;
        yield return new WaitForSeconds(fimDelay);

        while (slotaAtingiuPosicao(slot, posicaoDesejada, velocidade))
        {
            moverSlotAtePosicao(slot, posicaoDesejada, velocidade);
            yield return null;
        }
        slot.transform.localPosition = posicaoDesejada;
    }

    public IEnumerator descerSlotCima(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        while (slotaAtingiuPosicao(slot, posicaoDesejada, velocidade))
        {
            moverSlotAtePosicao(slot, posicaoDesejada, velocidade);
            yield return null;
        }
        slot.transform.localPosition = posicaoDesejada;
    }

    public IEnumerator subirSlotCima(GameObject slot, Vector3 posicaoDesejada, DisplayDeColetadoDto displayDto)
    {
        float velocidade = displayDto.VelocImg;
        while (slotaAtingiuPosicao(slot, posicaoDesejada, velocidade))
        {
            moverSlotAtePosicao(slot, posicaoDesejada, velocidade);
            yield return null;
        }
        slot.transform.localPosition = posicaoDesejada;
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
