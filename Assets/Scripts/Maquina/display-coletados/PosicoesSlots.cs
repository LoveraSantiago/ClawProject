using UnityEngine;

public class PosicoesSlots 
{
    public Vector3 posFinal { get; private set; }
    public Vector3 posSlotBaixoInicial { get; private set; }
    public Vector3 posSlotCimaInicial { get; private set; }

    public PosicoesSlots(SingleDisplaySlotDto singleDisplaySlotDto)
    {
        posSlotBaixoInicial = singleDisplaySlotDto.GoSlotBaixo.transform.localPosition;
        posSlotCimaInicial = singleDisplaySlotDto.GoSlotCima.transform.localPosition;

        Vector3 localPosition = singleDisplaySlotDto.GoSlotBaixo.transform.localPosition;
        posFinal = new Vector3(localPosition.x, 0.5f, localPosition.z);
    }

}
