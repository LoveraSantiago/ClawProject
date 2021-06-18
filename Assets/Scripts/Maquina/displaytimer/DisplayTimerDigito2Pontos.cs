using UnityEngine;

public class DisplayTimerDigito2Pontos 
{
    private SingleDisplayTimerDto sDisplayDto;

    public DisplayTimerDigito2Pontos(SingleDisplayTimerDto singleDisplayTimer)
    {
        sDisplayDto = singleDisplayTimer;
        singleDisplayTimer.Segmentos[0].color = Color.red;
        singleDisplayTimer.Segmentos[1].color = Color.red;
    }   
}
