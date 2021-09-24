using UnityEngine;

public class GarraManager : AcaoImantadoPelaGarra.ProdutorEvento,
                            AcaoSubidaDaGarra.ProdutorEvento,
                            AcaoSincroniaComDirecaoDaGarra.ProdutorEvento,
                            AcaoColetado.ConsumidorEvento,
                            AcaoPUpAcionado.ConsumidorEvento,                            
                            AcaoTempoEsgotado.ConsumidorEvento,
                            AcaoBoardElevadoFim.ConsumidorEvento,
                            AcaoColetadoFim.ConsumidorEvento,
                            AcaoCacaNiquel.ConsumidorEvento,
                            ConsumidorDeEventoTrigger
{
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };

    private GerenciadorDeMovimentacaoNormal     gerDeMovNormal;
    private GerenciadorDeMovimentacaoPowerUp    gerDeMovPowerUp;
    private GerenciadorDeMovimentacaoCacaNiquel gerDeMovCacaNiquel;//TODO tentar reaproveitar GerenciadorDeMovimentacaoNormal e remover GerenciadorDeMovimentacaoCacaNiquel
    private GerenciadorDeMovimentacao gerDeMovAtual;
    private CaboDaGarra cabo;

    private bool tempoEsgotadoEmAcao;

    public GarraManager(GarraDto garraDto)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacao(garraDto);
        gerDeMovNormal     = new GerenciadorDeMovimentacaoNormal();
        gerDeMovPowerUp    = new GerenciadorDeMovimentacaoPowerUp();
        gerDeMovCacaNiquel = new GerenciadorDeMovimentacaoCacaNiquel();
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

        if(level.isCacaNiquelLevel())
        {
            gerDeMovAtual = gerDeMovCacaNiquel;
        }
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

    void AcaoPUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            gerDeMovPowerUp.receberGarraInteracaoComPowerUp(evento.interacaoComGarra, evento.duracaoTempo);
            gerDeMovPowerUp.iniciarMovimentacoes();
            gerDeMovAtual = gerDeMovPowerUp;
        }
        else if (evento.isFinalizar)
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
        tempoEsgotadoEmAcao = true;
        gerDeMovNormal.trocarParaAcaoVoltarParaCima();
        gerDeMovAtual = gerDeMovNormal;
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(BoardAcaoFim evento)
    {
        if (!evento.isGameOver)
        {
            tempoEsgotadoEmAcao = false;
            gerDeMovNormal.iniciarMovimentacoes();
            gerDeMovAtual = gerDeMovNormal;
        }
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFim evento)
    {
        if (gerDeMovAtual != gerDeMovPowerUp && !tempoEsgotadoEmAcao)
        {
            gerDeMovNormal.iniciarMovimentacoes();            
        }
    }

    void ProdutorConsumidoresDeEvento<CacaNiquelResult>.ConsumidorEvento.consumirEvento(CacaNiquelResult evento)
    {
        if (evento.isInicio)
        {
            gerDeMovAtual.iniciarMovimentacoes();
        }
    }

    ProdutorDeEvento<InformacoesColetadoImantadoDto> AcaoImantadoPelaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoImantadoPelaGarra.ProdutorEvento)gerDeMovNormal).getProdutorDeEvento();
    }

    ProdutorDeEvento<ContagemSubidaGarra> AcaoSubidaDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoSubidaDaGarra.ProdutorEvento)gerDeMovNormal).getProdutorDeEvento();
    }

    ProdutorDeEvento<DirecaoDaGarra> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return MovimentacaoDaGarra.produtorEventoDirecao;
    }   
}
