using UnityEngine;

public class GarraManager : ConsumidorDeEventoTrigger,
                            Consumidor<PowerUpInfo>,
                            Consumidor<PowerUpInfoFim>,
                            Consumidor<InformacoesColetado>
{
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };

    private GerenciadorDeMovimentacaoNormal  gerDeMovNormal;
    private GerenciadorDeMovimentacaoPowerUp gerDeMovPowerUp;
    private GerenciadorDeMovimentacao gerDeMovAtual;
    private CaboDaGarra cabo;

    public GarraManager(GarraDto garraDto, InputGame inputGame)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacao(garraDto, inputGame);
        gerDeMovNormal  = new GerenciadorDeMovimentacaoNormal();
        gerDeMovPowerUp = new GerenciadorDeMovimentacaoPowerUp();
        gerDeMovAtual = gerDeMovNormal;

        configurarColisorCentroDaPinca(garraDto.Colisor);

        cabo = new CaboDaGarra(garraDto.CaboDaGarraDto, garraDto.RigidBody.transform);
    }

    private void configurarColisorCentroDaPinca(GameObject goColisor)
    {
        DetectorDeTriggers detectorDeColisoes = goColisor.GetComponent<DetectorDeTriggers>();
        detectorDeColisoes.registrarConsumidorDeTrigger(this);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        gerDeMovNormal.configuradoPeloLevel(level.getMecanicaDaGarra());
        cabo.configuradoPeloLevel(level.getDicionarioDeCores());
    }

    public void start()
    {
        cabo.start();
        gerDeMovAtual.iniciarMovimentacoes();
    }

    public void update()
    {
        gerDeMovAtual.update();
        cabo.update();
    }

    public void fixedUpdate()
    {
        gerDeMovAtual.fixedUpdate();
        cabo.fixedUpdate();
    }

    private void processarGarraColidiuCom(Collider2D other)
    {
        gerDeMovAtual.garraColidiuCom(other);
    }

    private void processarFimPowerUp()
    {
        gerDeMovNormal.trocarParaAcaoNormal();
        gerDeMovAtual = gerDeMovNormal;
    }

    private void processarPowerUp(PowerUpInfo powerUpInfo)
    {        
        gerDeMovPowerUp.receberGarraInteracaoComPowerUp(powerUpInfo.garraInteracaoPowerUp, powerUpInfo.duracaoTempo);
        gerDeMovPowerUp.iniciarMovimentacoes();
        gerDeMovAtual = gerDeMovPowerUp;        
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QDO GARRA COLLIDE COM UM COLETAVEL
    public void consumir(Collider2D colliderDeColetavel)
    {
        processarGarraColidiuCom(colliderDeColetavel);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> INICIO
    public void consumir(PowerUpInfo evento)
    {
        processarPowerUp(evento);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> INICIO
    public void consumir(PowerUpInfoFim powerUpInfoFim)
    {
        if (powerUpInfoFim.finalizar)
        {
            processarFimPowerUp();
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<InformacoesColetado> INICIO
    public void consumir(InformacoesColetado evento)
    {
        gerDeMovAtual.garraComemorar();
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<InformacoesColetado> FIM

    public ProdutorDeEvento<DirecaoDaGarra> getDisparadorDeEventoDeDirecao()
    {
        return MovimentacaoDaGarra.produtorEventoDirecao;
    }

    public ProdutorDeEvento<string> getProdutorDeEventoTocadoPelaGarra()
    {
        return MovimentacaoDaGarra.produtorEventoGarraAcertou;
    }

    public ProdutorDeEvento<int> getProdutorDeEventoSubidaDaGarra()
    {
        return MovimentacaoDaGarra.produtorDeEventoSubidaDaGarra;
    }

    public Consumidor<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return this;
    }

    public Consumidor<PowerUpInfoFim> getConsumidorDePowerUpFim()
    {
        return this;
    }  
    
    public Consumidor<InformacoesColetado> getConsumidorInformacoesColetado()
    {
        return this;
    }
}
