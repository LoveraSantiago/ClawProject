using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao,
                              AcaoPowerUpInicio.ProdutorEvento,
                              AcaoPowerUpFim.ProdutorEvento
{   
    public ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp { get; private set; }
    private ProdutorDeEvento<PowerUpInfoFim> produtorDeEventoFinalizacao;

    public PowerUpManager(PowerUpDto powerUpDto, MonoBehaviour monoBehaviour, InputGame inputGame)
    {   
        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
        produtorDeEventoFinalizacao = new ProdutorDeEvento<PowerUpInfoFim>();

        AbstractPowerUpGo.configurarAbstractPowerUp(powerUpDto, this, inputGame, monoBehaviour);        
    }    

    public void acionado(PowerUpEntidade powerUp)
    {
        GarraInteracaoComPowerUp interacaoComPowerUp = powerUp.getPowerUpGo();

        PowerUpInfo powerUpInfo = new PowerUpInfo();
        powerUpInfo.configurarDuracaoTempo(powerUp.duracao);
        powerUpInfo.configurarObjetoInteracaoComGarra(interacaoComPowerUp);

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void acionado(PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        AbstractPowerUpGo interacaoComPowerUp = powerUp.getPowerUpGo();
        interacaoComPowerUp.iniciarNaPosicao(posicaoAtual);

        PowerUpInfo powerUpInfo = new PowerUpInfo();
        powerUpInfo.configurarDuracaoTempo(powerUp.duracao);
        powerUpInfo.configurarObjetoInteracaoComGarra(interacaoComPowerUp);

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }   

    public void preFinalizar()
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(true, false);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }

    public void preFinalizar(ColetavelTile coletavelTile)
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(true, false);
        powerUpInfoFim.addColetavel(coletavelTile);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }

    public void finalizado()
    {
        PowerUpInfoFim powerUpInfoFim = new PowerUpInfoFim(false, true);
        produtorDeEventoFinalizacao.produziuEvento(powerUpInfoFim);
    }    

    ProdutorDeEvento<PowerUpInfo> AcaoPowerUpInicio.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEventoPowerUp;
    }

    ProdutorDeEvento<PowerUpInfoFim> AcaoPowerUpFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEventoFinalizacao;
    }    
}
