using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao,
                              AcaoPUpAcionado.ProdutorEvento
{
    private int indiceBtnEmAcao;
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

    public void configurarGosPowerUps(
        InformacaoDisplayColetado informacaoDisplayColetado,
        TrocadorDeOrdem trocadorDeOrdem)
    {
        TeleportePowerUpGo.configurarTrocadorDeOrdem(trocadorDeOrdem);
        AbstractDisplaySlotPowerUpGo.configurar(informacaoDisplayColetado);
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp)
    {
        indiceBtnEmAcao = indiceBtn;
        PowerUpInfo powerUpInfo = PowerUpInfo.ofInicio(powerUp);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        indiceBtnEmAcao = indiceBtn;
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
        produtorDeEventoPowerUp.produziuEvento(PowerUpInfo.ofFinalizar(indiceBtnEmAcao));
    }    

    ProdutorDeEvento<PowerUpInfo> AcaoPUpAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoPowerUp;
    }    
}
