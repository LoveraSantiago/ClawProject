using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao,
                              AcaoPUpAcionado.ProdutorEvento
{
    private ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp;    

    public PowerUpManager(PowerUpDto powerUpDto, InputGame inputGame)
    {
        configurarPowerUps(powerUpDto, inputGame);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();        
    }    

    private void configurarPowerUps(PowerUpDto powerUpDto, InputGame inputGame)
    {        
        PowerUpEntidade.configurarDicionarioDeSpritesPup(powerUpDto.PrefabPowerUpDto);
        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        AbstractPowerUpGo.configurarAbstractPowerUp(powerUpDto, this, inputGame);        
    }

    public void configurarGosPowerUps(TrocadorDeOrdem trocadorDeOrdem)
    {
        TeleportePowerUpGo.configurarTrocadorDeOrdem(trocadorDeOrdem);
    }

    public void acionado(PowerUpEntidade powerUp)
    {
        PowerUpInfo powerUpInfo = PowerUpInfo.ofInicio(powerUp);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void acionado(PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        PowerUpInfo powerUpInfo = PowerUpInfo.ofInicio(powerUp, posicaoAtual);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }   

    public void preFinalizar()
    {        
        produtorDeEventoPowerUp.produziuEvento(PowerUpInfo.ofPreFinalizar());
    }

    public void preFinalizar(ColetavelTile coletavelTile)
    {
        PowerUpInfo powerUpInfo = PowerUpInfo.ofPreFinalizar(coletavelTile);            
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {        
        produtorDeEventoPowerUp.produziuEvento(PowerUpInfo.ofFinalizar());
    }    

    ProdutorDeEvento<PowerUpInfo> AcaoPUpAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoPowerUp;
    }    
}
