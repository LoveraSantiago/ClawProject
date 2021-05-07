using UnityEngine;
using System.Collections.Generic;

public class PowerUpParaMaquina : AcaoBotaoPowerUp
{
    private static PowerUpAcionamento powerUpAcionamento;
    
    private PowerUpEntidade powerUp;
    private Sprite imgBtn;

    public PowerUpParaMaquina(PowerUpEntidade.NAME tipo, Dictionary<string, Sprite> dicionarioDeSprites)
    {
        powerUp = PowerUpEntidade.getPowerUpEntidadeByEnum(tipo);
        imgBtn = dicionarioDeSprites[powerUp.nomeSprite];
    }

    public void acionar()
    {
        powerUpAcionamento.acionado(powerUp);
    }

    public void acionar(Vector3 posicaoAtual)
    {
        powerUpAcionamento.acionado(powerUp, posicaoAtual);
    }

    public bool isClicavel()
    {
        return powerUp.isClicavel;
    }

    public bool isDraggavel()
    {
        return !isClicavel();
    }

    public static void configAcionadorDePowerUp(PowerUpAcionamento powerUpAcionamentoArg)
    {
        powerUpAcionamento = powerUpAcionamentoArg;
    }

    public Sprite getImgBotao()
    {
        return imgBtn;
    }

}
