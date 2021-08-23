using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesPowerUpArcoIris : ArcoIrisConjunto
{
    private BotaoPowerUp[] btnsPowerUp;

    public BotoesPowerUpArcoIris(BotaoPowerUp[] btnsPowerUp)
    {
        this.btnsPowerUp = btnsPowerUp;
    }

    public void desligar()
    {
        for(int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            btnsPowerUp[contador].desligarGlow();
        }
    }

    public void ligar()
    {
        for (int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            btnsPowerUp[contador].ligarGlowSucesso();
        }
    }

    public void passarCor(Color cor)
    {
        for (int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            btnsPowerUp[contador].passarCorDoMaterial(cor);
        }
    }
}
