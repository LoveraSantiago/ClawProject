using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao
{
    private PowerUpDto powerUpDto;
    
    private PoolDePowerUpGos poolDePowerUpGos;
    private MonoBehaviour monoBehaviour;

    public ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp { get; private set; }
    public ProdutorDeEvento<PowerUpInfoFim> produtorDeEventoFinalizacao { get; private set; }

    public PowerUpManager(PowerUpDto powerUpDto, MonoBehaviour monoBehaviour)
    {
        this.powerUpDto = powerUpDto;
        this.monoBehaviour = monoBehaviour;

        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
        produtorDeEventoFinalizacao = new ProdutorDeEvento<PowerUpInfoFim>();

        AbstractPowerUpGo.configurar(this, monoBehaviour);
        poolDePowerUpGos = new PoolDePowerUpGos(powerUpDto);        
    }    

    public void acionado(PowerUpEntidade powerUp)
    {    
        GarraInteracaoComPowerUp interacaoComPowerUp = poolDePowerUpGos.getPowerUpGo(powerUp.name);

        PowerUpInfo powerUpInfo = new PowerUpInfo();
        powerUpInfo.configurarDuracaoTempo(powerUp.duracao);
        powerUpInfo.configurarObjetoInteracaoComGarra(interacaoComPowerUp);

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void acionado(PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        AbstractPowerUpGo interacaoComPowerUp = poolDePowerUpGos.getPowerUpGo(powerUp.name);
        interacaoComPowerUp.iniciarNaPosicao(posicaoAtual);

        PowerUpInfo powerUpInfo = new PowerUpInfo();
        powerUpInfo.configurarDuracaoTempo(powerUp.duracao);
        powerUpInfo.configurarObjetoInteracaoComGarra(interacaoComPowerUp);

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(false, true);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }

    public void preFinalizar()
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(true, false);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }
}
