using UnityEngine;

public class PowerUpManager : PowerUpAcaoAcionamento,
                              PowerUpAcaoFinalizacao,
                              PowerUpAcaoExpirado,
                              AcaoPowerUpAcionado.ProdutorEvento
{
    private int indiceBtnEmAcao;
    private ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp;

    private ContadorTimeout contadorTimeout;

    public PowerUpManager(PowerUpDto powerUpDto, InputGame inputGame)
    {
        configurarPowerUps(powerUpDto, inputGame);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
        contadorTimeout = new ContadorPowerUpInativo();
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
        AbstractPowerUpGo.configurar(informacaoDisplayColetado);
    }

    public void update()
    {
        contadorTimeout.contarTimeout(this);
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

    public void expirar()
    {
        throw new System.NotImplementedException();
    }

    public void finalizado()
    {        
        produtorDeEventoPowerUp.produziuEvento(PowerUpInfo.ofFinalizar(indiceBtnEmAcao));
    }    

    private void iniciarPowerUp(PowerUpInfo powerUpInfo)
    {
        contadorTimeout = new ContadorPowerUpAtivo(powerUpInfo.duracaoTempo);

        InteracaoPowerUpComComponente interacao = powerUpInfo.interacaoComComponentes;
        if (InteracaoComponentesUtils.isNotInteracaoComGarra(interacao))
        {
            interacao.iniciar();
        }
    }   

    ProdutorDeEvento<PowerUpInfo> AcaoPowerUpAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoPowerUp;
    }    
}
