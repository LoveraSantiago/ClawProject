using UnityEngine;

public class DisplayTimerDigito2Pontos 
{
    private SpriteRenderer sprRenderer2Pontos;
    private Color corOriginal;

    public DisplayTimerDigito2Pontos(SpriteRenderer sprRenderer2Pontos)
    {
        this.sprRenderer2Pontos = sprRenderer2Pontos;
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
        sprRenderer2Pontos.color = cor;
    }
}
