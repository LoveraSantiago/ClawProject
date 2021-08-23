using UnityEngine;

public class DisplayTimerGlow : ArcoIrisConjunto
{
    private bool blink;
    private GlowEfeito glowEfeito;

    public bool getEstadoBlink()
    {
        return blink;
    }

    public void ativarBlink()
    {
        blink = true;
    }

    public void ligarGlowFail()
    {
        glowEfeito.ligarGlowFail();
    }

    public void desligarGlow()
    {
        glowEfeito.desligarGlow();
    }

    public DisplayTimerGlow(DisplayTimerDto displayDto)
    {
        glowEfeito = new GlowEfeito(displayDto.PlacaEfeito, new MaterialGlow(displayDto.MaterialEfeito));
    }

    public void desligar()
    {
        if (!blink)
        {
            glowEfeito.desligarGlow();
        }
    }

    public void ligar()
    {
        if (!blink)
        {
            glowEfeito.ligarGlowSucesso();
        }
    }

    public void passarCor(Color cor)
    {
        if (!blink)
        {
            glowEfeito.materialGlow.setCorNoMaterial(cor);
        }
    }
}
