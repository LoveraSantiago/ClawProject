using UnityEngine;

public class PowerUpInfo
{
    public int duracaoTempo{ get; private set; }
    public GarraInteracaoComPowerUp garraInteracaoPowerUp { get; private set; }

    public void configurarDuracaoTempo(int duracao)
    {
        duracaoTempo = duracao;
    }

    public void configurarObjetoInteracaoComGarra(GarraInteracaoComPowerUp garraInteracaoPowerUp)
    {
        this.garraInteracaoPowerUp = garraInteracaoPowerUp;
    }
}
