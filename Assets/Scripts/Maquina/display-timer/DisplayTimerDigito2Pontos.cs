using UnityEngine;

public class DisplayTimerDigito2Pontos 
{
    private SingleDisplayTimerDto sDisplayDto;
    private Color corOriginal;

    public DisplayTimerDigito2Pontos(SingleDisplayTimerDto singleDisplayTimer)
    {
        sDisplayDto = singleDisplayTimer;
        setCor(Color.red);
    } 

    public void configuradoPeloLevel(Color corDigito)
    {
        corOriginal = corDigito;
    }

    public void estadoBlink(bool estadoBlink)
    {
        if (estadoBlink)
        {
            setCor(corOriginal);
        }
        else
        {
            setCor(Color.red);
        }
    }

    private void setCor(Color cor)
    {
        sDisplayDto.Segmentos[0].color = cor;
        sDisplayDto.Segmentos[1].color = cor;
    }
}
