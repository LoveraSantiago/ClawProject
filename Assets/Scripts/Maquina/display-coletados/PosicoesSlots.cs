using UnityEngine;

public class PosicoesSlots 
{
    public Vector3 posSlotCimaInicial { get; private set; }

    public PosicoesSlots(SingleDisplaySlotDto singleDisplaySlotDto, SingleSlotColetadoDto singleSlotColetadoDto)
    {
        posSlotCimaInicial = singleDisplaySlotDto.GoSlotCima.transform.localPosition;

        Vector3 localPosition = singleSlotColetadoDto.GoSlot.transform.localPosition;
    }

}
