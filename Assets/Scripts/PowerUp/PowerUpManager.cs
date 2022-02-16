using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao,
                              AcaoPowerUpAcionado.ProdutorEvento
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
        Fornecedor<TrocadorDeOrdem> fornecedorTrocadorDeOrdem)
    {
        AbstractTrocaPowerUpGo.configurarTrocadorDeOrdem(fornecedorTrocadorDeOrdem);
        AbstractDisplaySlotPowerUpGo.configurar(informacaoDisplayColetado);
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp)
    {
        indiceBtnEmAcao = indiceBtn;
        PowerUpInfo powerUpInfo = PowerUpInfo.ofInicio(powerUp);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        iniciarPowerUp(powerUpInfo);
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        indiceBtnEmAcao = indiceBtn;
        PowerUpInfo powerUpInfo = PowerUpInfo.ofInicio(powerUp, posicaoAtual);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        iniciarPowerUp(powerUpInfo);
    }   

    public void preFinalizar()
    {        
        produtorDeEventoPowerUp.produziuEvento(PowerUpInfo.ofPreFinalizar());
    }

    public void preFinalizar(Coletavel coletavel)
    {
        PowerUpInfo powerUpInfo = PowerUpInfo.ofPreFinalizar(coletavel);            
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {        
        produtorDeEventoPowerUp.produziuEvento(PowerUpInfo.ofFinalizar(indiceBtnEmAcao));
    }    

    ProdutorDeEvento<PowerUpInfo> AcaoPowerUpAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoPowerUp;
    }    

    private void iniciarPowerUp(PowerUpInfo powerUpInfo)
    {
        InteracaoPowerUpComComponente interacao = powerUpInfo.interacaoComComponentes;
        if (InteracaoComponentesUtils.isNotInteracaoComGarra(interacao))
        {
            interacao.iniciar();
        }
    }
}
