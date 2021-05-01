using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao
{
    private GameObject tileBomb;
    private Sprite imgBomb;
    private MonoBehaviour monoBehaviour;

    public ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp { get; private set; }
    public ProdutorDeEvento<PowerUpInfoFim> produtorDeEventoFinalizacao { get; private set; }

    public PowerUpManager(GameObject tileBomb, Sprite spriteBomb, MonoBehaviour monoBehaviour)
    {
        this.tileBomb = tileBomb;
        this.imgBomb = spriteBomb;
        this.monoBehaviour = monoBehaviour;

        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
        produtorDeEventoFinalizacao = new ProdutorDeEvento<PowerUpInfoFim>();
    }

    public PowerUpParaMaquina distribuirPowerUpParaMaquina()
    {
        PowerUp  powerUpBomba = new PowerUp(PowerUp.TIPO.BOMBA_DA_GARRA, 5);
        PowerUpParaMaquina powerUpParaMaquinaBomba = new PowerUpParaMaquina(powerUpBomba, imgBomb, true);
        return powerUpParaMaquinaBomba;
    }

    public void acionado(PowerUp.TIPO tipoPowerUp)
    {    
        if(tipoPowerUp == PowerUp.TIPO.BOMBA_DA_GARRA)
        {
            PowerUpInfo powerUpInfo = new PowerUpInfo();
            powerUpInfo.configurarDuracaoTempo(9);
            powerUpInfo.configurarObjetoInteracaoComGarra(new PowerUpBomba(tileBomb, this, monoBehaviour));
            produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        }
    }

    public void finalizado()
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(false, true);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }
}
