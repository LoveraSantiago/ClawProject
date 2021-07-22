using UnityEngine;

public class GarraManager : AcaoImantadoPelaGarra.ProdutorEvento,
                            AcaoSubidaDaGarra.ProdutorEvento,
                            AcaoSincroniaComDirecaoDaGarra.ProdutorEvento,
                            AcaoColetado.ConsumidorEvento,
                            AcaoPowerUpInicio.ConsumidorEvento,
                            ConsumidorDeEventoTrigger,                        
                            Consumidor<PowerUpInfoFim>
{
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };

    private GerenciadorDeMovimentacaoNormal gerDeMovNormal;
    private GerenciadorDeMovimentacaoPowerUp gerDeMovPowerUp;
    private GerenciadorDeMovimentacao gerDeMovAtual;
    private CaboDaGarra cabo;

    public GarraManager(GarraDto garraDto, InputGame inputGame)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacao(garraDto, inputGame);
        gerDeMovNormal = new GerenciadorDeMovimentacaoNormal();
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

    void AcaoPowerUpInicio.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {        
        gerDeMovPowerUp.receberGarraInteracaoComPowerUp(evento.garraInteracaoPowerUp, evento.duracaoTempo);
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

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> INICIO
    public void consumir(PowerUpInfoFim powerUpInfoFim)
    {
        if (powerUpInfoFim.finalizar)
        {
            processarFimPowerUp();
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> FIM

    ProdutorDeEvento<InformacoesColetadoImantado> AcaoImantadoPelaGarra.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return ((AcaoImantadoPelaGarra.ProdutorEvento)gerDeMovNormal).getProdutorDeEventoColetado();
    }

    ProdutorDeEvento<ContagemSubidaGarra> AcaoSubidaDaGarra.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return ((AcaoSubidaDaGarra.ProdutorEvento)gerDeMovNormal).getProdutorDeEventoColetado();
    }

    ProdutorDeEvento<DirecaoDaGarra> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return MovimentacaoDaGarra.produtorEventoDirecao;
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetado evento)
    {
        gerDeMovAtual.garraComemorar();
    }    

    public Consumidor<PowerUpInfoFim> getConsumidorDePowerUpFim()
    {
        return this;
    }   
}
