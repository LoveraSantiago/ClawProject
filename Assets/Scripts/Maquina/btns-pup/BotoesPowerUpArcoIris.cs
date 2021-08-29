using UnityEngine;

public class BotoesPowerUpArcoIris : ArcoIrisConjunto
{
    private GlowBotaoPowerUp[] glowsBtns;

    public BotoesPowerUpArcoIris(BotaoPowerUp[] btnsPowerUp)
    {
        glowsBtns = new GlowBotaoPowerUp[btnsPowerUp.Length];
        for(int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            glowsBtns[contador] = btnsPowerUp[contador].glow;
        }
    }

    public void desligar()
    {
        for(int contador = 0; contador < glowsBtns.Length; contador++)
        {
            glowsBtns[contador].desligarGlow();
        }
    }

    public void ligar()
    {
        for (int contador = 0; contador < glowsBtns.Length; contador++)
        {
            glowsBtns[contador].ligarGlow();
        }
    }

    public void passarCor(Color cor)
    {     
        for (int contador = 0; contador < glowsBtns.Length; contador++)
        {
            glowsBtns[contador].passarCorDoMaterial(cor);
        }
    }
}
