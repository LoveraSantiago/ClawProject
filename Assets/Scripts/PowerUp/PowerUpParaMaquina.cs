using UnityEngine;

public class PowerUpParaMaquina : AcaoBotaoPowerUp
{
    private static PowerUpAcionamento powerUpAcionamento;
    
    private PowerUpEntidade powerUp;    

    public PowerUpParaMaquina(PowerUpEntidade.TIPO tipo)
    {
        powerUp = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipo);
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
        return powerUp.sprPowerUp;
    }

    public PowerUpEntidade.TIPO getTipo()
    {
        return powerUp.tipo;
    }
}
