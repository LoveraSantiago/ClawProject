using UnityEngine;

public class DisplayTimerDigito2Pontos 
{   

    public DisplayTimerDigito2Pontos(SingleDisplayTimerDto singleDisplayTimer)
    {
        singleDisplayTimer.Segmentos[0].color = Color.red;
        singleDisplayTimer.Segmentos[1].color = Color.red;
    }
}
