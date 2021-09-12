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

    public void acionado(PowerUpEntidade powerUp)
    {
        AbstractPowerUpGo interacaoComPowerUp = powerUp.getPowerUpGo();

        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.INICIO)
            .configurarPupEntidade(powerUp);           

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void acionado(PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.INICIO)
            .configurarPupEntidade(powerUp, posicaoAtual);                                   

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }   

    public void preFinalizar()
    {
        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.PREFINALIZAR);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void preFinalizar(ColetavelTile coletavelTile)
    {
        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.PREFINALIZAR)
            .addColetavel(coletavelTile);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {
        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.FINALIZAR);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }    

    ProdutorDeEvento<PowerUpInfo> AcaoPUpAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoPowerUp;
    }    
}
