using UnityEngine;
using System.Collections.Generic;

public class PowerUpManager : PowerUpAcaoAcionamento,
                              PowerUpAcaoFinalizacao,                              
                              AcaoPowerUpAcionado.ProdutorEvento,
                              AcaoDesligarMaquina.ConsumidorEvento,
                              AcaoDesligarMaquinaResultado.ConsumidorEvento,
                              Fornecedor<ResultadoPowerUpDto>
{
    private int indiceBtnEmAcao;
    private List<PowerUpUsadoDto> listaPupsUsados;
    private ProdutorDeEvento<PowerUpInfoDto> produtorDeEventoPowerUp;

    private SomPowerUp somPowerUp;
    private ControlePowerUp controlePowerUp;

    public PowerUpManager(PowerUpGameDto powerUpDto, InputGame inputGame, SomPowerUp somPowerUp)
    {
        this.somPowerUp = somPowerUp;
        listaPupsUsados = new List<PowerUpUsadoDto>();
        configurarPowerUps(powerUpDto, inputGame);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfoDto>();
        controlePowerUp = new ControlePowerUpInativo();
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
        controlePowerUp.contarTimeout();
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp)
    {
        listaPupsUsados.Add(new PowerUpUsadoDto(powerUp.tipo, Time.time));
        indiceBtnEmAcao = indiceBtn;
        PowerUpInfoDto powerUpInfo = FactoryPowerUpInfoDto.ofInicio(powerUp);
        somPowerUp.playSomBackgroundPowerUp();
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        iniciarPowerUp(powerUpInfo);
    }

    public void acionado(int indiceBtn, PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        listaPupsUsados.Add(new PowerUpUsadoDto(powerUp.tipo, Time.time));
        indiceBtnEmAcao = indiceBtn;
        PowerUpInfoDto powerUpInfo = FactoryPowerUpInfoDto.ofInicio(powerUp, posicaoAtual);
        somPowerUp.playSomBackgroundPowerUp();
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
        iniciarPowerUp(powerUpInfo);
    }

    public void emAndamento(PowerUpEnums.ESTADO estadoAtual)
    {
        produtorDeEventoPowerUp.produziuEvento(FactoryPowerUpInfoDto.ofEmAndamento(estadoAtual));
    }

    public void preFinalizar()
    {        
        produtorDeEventoPowerUp.produziuEvento(FactoryPowerUpInfoDto.ofPreFinalizar());
    }

    public void preFinalizar(Coletavel coletavel)
    {
        PowerUpInfoDto powerUpInfo = FactoryPowerUpInfoDto.ofPreFinalizar(coletavel);            
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void expirado()
    {        
        controlePowerUp = new ControlePowerUpInativo();
        PowerUpInfoDto powerUpInfo = FactoryPowerUpInfoDto.ofExpirado();        
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {
        controlePowerUp = new ControlePowerUpInativo();
        somPowerUp.playSomBackgroundNormal();
        produtorDeEventoPowerUp.produziuEvento(FactoryPowerUpInfoDto.ofFinalizar(indiceBtnEmAcao));
    }

    public ResultadoPowerUpDto fornecer()
    {
        return new ResultadoPowerUpDto(listaPupsUsados);
    }

    private void iniciarPowerUp(PowerUpInfoDto powerUpInfo)
    {
        controlePowerUp = new ControlePowerUpAtivo(powerUpInfo);

        InteracaoPowerUpComComponente interacao = powerUpInfo.interacaoPupComComponentes;
        if (InteracaoComponentesUtils.isNotInteracaoComGarra(interacao))
        {
            interacao.iniciar();
        }
    }   

    ProdutorDeEvento<PowerUpInfoDto> AcaoPowerUpAcionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoPowerUp;
    }

    void ProdutorConsumidoresDeEvento<ResultadoDesligarMaquinaDto>.ConsumidorEvento.consumirEvento(ResultadoDesligarMaquinaDto evento)
    {
        if (!evento.resultadoSair)
        {
            controlePowerUp.continuar();
        }
    }

    void ProdutorConsumidoresDeEvento<DesligarMaquinaDto>.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
    {
        controlePowerUp.pausar();
    }
}
