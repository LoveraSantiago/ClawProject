using UnityEngine;

public class PosicoesSlots 
{
    public Vector3 posFinal { get; private set; }
    public Vector3 posSlotBaixoInicial { get; private set; }
    public Vector3 posSlotCimaInicial { get; private set; }

    public PosicoesSlots(SingleDisplaySlotDto singleDisplaySlotDto, SingleSlotColetadoDto singleSlotColetadoDto)
    {
        //posSlotBaixoInicial = singleDisplaySlotDto.GoSlotBaixo.transform.localPosition;
        posSlotBaixoInicial = singleSlotColetadoDto.GoSlot.transform.localPosition - new Vector3(0, 0.7f, 0);
        posSlotCimaInicial = singleDisplaySlotDto.GoSlotCima.transform.localPosition;

        //Vector3 localPosition = singleDisplaySlotDto.GoSlotBaixo.transform.localPosition;
        Vector3 localPosition = singleSlotColetadoDto.GoSlot.transform.localPosition;
        //posFinal = new Vector3(localPosition.x, 0.5f, localPosition.z);
        posFinal = new Vector3(localPosition.x, 0, localPosition.z);
    }

}
