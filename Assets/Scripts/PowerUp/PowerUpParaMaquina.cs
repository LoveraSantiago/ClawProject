using UnityEngine;

public class PowerUpParaMaquina : AcaoBotaoPowerUp
{
    private static PowerUpAcionamento powerUpAcionamento;

    private bool clicavel;
    private PowerUp powerUp;
    private Sprite imgBtn;

    public PowerUpParaMaquina(PowerUp powerUp, Sprite imgBtn, bool clicavel)
    {
        this.powerUp = powerUp;
        this.clicavel = clicavel;
        this.imgBtn = imgBtn;
    }

    public void acionar()
    {
        powerUpAcionamento.acionado(powerUp.tipo);
    }

    public bool isClicavel()
    {
        return clicavel;
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
