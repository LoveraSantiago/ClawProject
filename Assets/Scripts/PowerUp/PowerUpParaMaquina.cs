using UnityEngine;

public class PowerUpParaMaquina : AcaoBotaoPowerUp
{
    private static PowerUpAcionamento powerUpAcionamento;
    
    private PowerUpEntidade powerUpEntidade;    

    public PowerUpParaMaquina(PowerUpEntidade powerUpEntidade)
    {
        this.powerUpEntidade = powerUpEntidade;
    }

    public void acionar()
    {
        powerUpAcionamento.acionado(powerUpEntidade);
    }

    public void acionar(Vector3 posicaoAtual)
    {
        powerUpAcionamento.acionado(powerUpEntidade, posicaoAtual);
    }

    public bool isClicavel()
    {
        return powerUpEntidade.isClicavel;
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
        return powerUpEntidade.sprPowerUp;
    }

    public PowerUpEnums.TIPO getTipo()
    {
        return powerUpEntidade.tipo;
    }
}
