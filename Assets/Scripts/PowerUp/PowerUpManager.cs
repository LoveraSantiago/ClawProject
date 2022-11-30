using UnityEngine;
using System.Collections.Generic;

public class PowerUpManager : PowerUpAcaoAcionamento,
                              PowerUpAcaoFinalizacao,                              
                              AcaoPowerUpAcionado.ProdutorEvento,
                              Fornecedor<ResultadoPowerUpDto>
{
    private int indiceBtnEmAcao;
    private List<PowerUpUsadoDto> listaPupsUsados;
    private ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp;

    private SomPowerUp somPowerUp;
    private ContadorTimeout contadorTimeout;

    public PowerUpManager(PowerUpGameDto powerUpDto, InputGame inputGame, SomPowerUp somPowerUp)
    {
        this.somPowerUp = somPowerUp;
        listaPupsUsados = new List<PowerUpUsadoDto>();
        configurarPowerUps(powerUpDto, inputGame);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();
        contadorTimeout = new ContadorPowerUpInativo();
    }    

    private void configurarPowerUps(PowerUpGameDto powerUpDto, InputGame inputGame)
    {        
        PowerUpEntidade.configurarDicionarioDeSpritesPup(powerUpDto.PrefabPowerUpDto);
        PowerUpsParaMaquina.configAcionadorDePowerUp(this);
        AbstractPowerUpGo.configurarAbstractPowerUp(powerUpDto, this, inputGame, somPowerUp);        
    }

    public void configuradoPeloLevel(
        InformacaoDisplayColetado informacaoDisplayColetado,
        Fornecedor<TrocadorDeOrdem> fornecedorTrocadorDeOrdem)
    {
        AbstractTrocaPowerUpGo.configurarTrocadorDeOrdem(fornecedorTrocadorDeOrdem);
        AbstractPowerUpGo.configuradoPeloLevel(informacaoDisplayColetado);
    }

    public void update()
    {
        contadorTimeout.contarTimeout();
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp)
    {
        listaPupsUsados.Add(new PowerUpUsadoDto(powerUp.tipo, Time.time));
        indiceBtnEmAcao = indiceBtn;
        PowerUpInfo powerUpInfo = PowerUpInfo.ofInicio(powerUp);
        somPowerUp.playSomBackgroundPowerUp();
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        iniciarPowerUp(powerUpInfo);
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        listaPupsUsados.Add(new PowerUpUsadoDto(powerUp.tipo, Time.time));
        indiceBtnEmAcao = indiceBtn;
        PowerUpInfo powerUpInfo = PowerUpInfo.ofInicio(powerUp, posicaoAtual);
        somPowerUp.playSomBackgroundPowerUp();
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

    public void expirado()
    {
        PowerUpInfo powerUpInfo = PowerUpInfo.ofExpirado();
        somPowerUp.playSomBackgroundNormal();
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {
        contadorTimeout = new ContadorPowerUpInativo();
        somPowerUp.playSomBackgroundNormal();
        produtorDeEventoPowerUp.produziuEvento(PowerUpInfo.ofFinalizar(indiceBtnEmAcao));
    }

    public ResultadoPowerUpDto fornecer()
    {
        return new ResultadoPowerUpDto(listaPupsUsados);
    }

    private void iniciarPowerUp(PowerUpInfo powerUpInfo)
    {
        contadorTimeout = new ContadorPowerUpAtivo(powerUpInfo);

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
