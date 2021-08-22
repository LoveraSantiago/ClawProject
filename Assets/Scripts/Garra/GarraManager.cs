using UnityEngine;

public class GarraManager : AcaoImantadoPelaGarra.ProdutorEvento,
                            AcaoSubidaDaGarra.ProdutorEvento,
                            AcaoSincroniaComDirecaoDaGarra.ProdutorEvento,
                            AcaoColetado.ConsumidorEvento,
                            AcaoPowerUp.ConsumidorEvento,                            
                            AcaoTempoEsgotado.ConsumidorEvento,
                            AcaoBoardElevadoFim.ConsumidorEvento,
                            AcaoColetadoFim.ConsumidorEvento,
                            ConsumidorDeEventoTrigger
{
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };

    private GerenciadorDeMovimentacaoNormal gerDeMovNormal;
    private GerenciadorDeMovimentacaoPowerUp gerDeMovPowerUp;
    private GerenciadorDeMovimentacao gerDeMovAtual;
    private CaboDaGarra cabo;

    public GarraManager(GarraDto garraDto)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacao(garraDto);
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

    public void update(InputGame inputGame)
    {
        gerDeMovAtual.update(inputGame);
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

    void AcaoPowerUp.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio())
        {
            gerDeMovPowerUp.receberGarraInteracaoComPowerUp(evento.interacaoComGarra, evento.duracaoTempo);
            gerDeMovPowerUp.iniciarMovimentacoes();
            gerDeMovAtual = gerDeMovPowerUp;
        }
        else if (evento.isFinalizar())
        {
            gerDeMovNormal.trocarParaAcaoNormal();
            gerDeMovAtual = gerDeMovNormal;
            gerDeMovPowerUp.finalizarPowerUp();
        }
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QDO GARRA COLLIDE COM UM COLETAVEL
    public void consumir(Collider2D colliderDeColetavel)
    {
        processarGarraColidiuCom(colliderDeColetavel);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM
   
    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {        
        gerDeMovAtual.garraComemorar();
    }        

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        gerDeMovNormal.trocarParaAcaoVoltarParaCima();
        gerDeMovAtual = gerDeMovNormal;
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(BoardAcaoFim evento)
    {
        if (!evento.isGameOver)
        {
            gerDeMovNormal.iniciarMovimentacoes();
            gerDeMovAtual = gerDeMovNormal;
        }
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFim evento)
    {
        if (gerDeMovAtual != gerDeMovPowerUp)
        {
            gerDeMovNormal.iniciarMovimentacoes();            
        }
    }

    ProdutorDeEvento<InformacoesColetadoImantadoDto> AcaoImantadoPelaGarra.ProdutorEvento.getProdutorDeEventoColetado()
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
}
