using UnityEngine;

public class PowerUpParaMaquina : AcaoBotaoPowerUp
{
    private static PowerUpAcaoAcionamento powerUpAcionamento;
    
    private PowerUpEntidade powerUpEntidade;    

    public PowerUpParaMaquina(PowerUpEntidade powerUpEntidade)
    {
        this.powerUpEntidade = powerUpEntidade;
    }

    public void acionar(int indiceBtn)
    {
        powerUpAcionamento.acionado(indiceBtn, powerUpEntidade);
    }

    public void acionar(int indiceBtn, Vector3 posicaoAtual)
    {
        powerUpAcionamento.acionado(indiceBtn, powerUpEntidade, posicaoAtual);
    }

    public bool isClicavel()
    {
        return powerUpEntidade.isClicavel;
    }

    public bool isDraggavel()
    {
        return !isClicavel();
    }

    public static void configAcionadorDePowerUp(PowerUpAcaoAcionamento powerUpAcionamentoArg)
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
