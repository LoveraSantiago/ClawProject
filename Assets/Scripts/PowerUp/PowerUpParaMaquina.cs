using UnityEngine;
using System.Collections.Generic;

public class PowerUpParaMaquina : AcaoBotaoPowerUp
{
    private static PowerUpAcionamento powerUpAcionamento;
    
    private PowerUp powerUp;
    private Sprite imgBtn;

    public PowerUpParaMaquina(PowerUp.NAME tipo, Dictionary<string, Sprite> dicionarioDeSprites)
    {
        powerUp = PowerUp.getPowerUpByEnum(tipo);
        imgBtn = dicionarioDeSprites[powerUp.nomeSprite];
    }

    public void acionar()
    {
        powerUpAcionamento.acionado(powerUp);
    }

    public void acionar(Vector3 posicaoAtual)
    {
        
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
