using UnityEngine;

public class GarraManager : AcaoInfoDaGarra.ProdutorEvento,                            
                            AcaoSincroniaComDirecaoDaGarra.ProdutorEvento,
                            AcaoColetado.ConsumidorEvento,
                            AcaoPUpAcionado.ConsumidorEvento,                            
                            AcaoTempoEsgotado.ConsumidorEvento,
                            AcaoBoardElevadoFim.ConsumidorEvento,
                            AcaoColetadoFim.ConsumidorEvento,
                            AcaoCacaNiquel.ConsumidorEvento,
                            ConsumidorDeEventoTrigger
{
    private bool tempoEsgotadoEmAcao;

    private CaboDaGarra cabo;
    private GerenciadorDeMovimentacaoNormal  gerDeMovNormal;
    private GerenciadorDeMovimentacaoPowerUp gerDeMovPowerUp;
    private GerenciadorDeMovimentacao        gerDeMovAtual;

    public GarraManager(GarraDto garraDto)
    {
        MovimentacaoDaGarra.configurar(garraDto);
    }  

    public void configuradoPeloLevel(GarraDto garraDto, AbstractLevel level)
    {        
        cabo = new CaboDaGarra();
        cabo.configuradoPeloLevel(garraDto.CaboDaGarraDto, level.getDicionarioDeCores());

        if(LevelUtils.isCacaNiquelLevel(level))
        {
            gerDeMovAtual = new GerenciadorDeMovimentacaoCacaNiquel();
        }
        else
        {
            configurarColisorCentroDaPinca(garraDto.Colisor);
            gerDeMovNormal  = new GerenciadorDeMovimentacaoNormal();
            gerDeMovPowerUp = new GerenciadorDeMovimentacaoPowerUp();
            gerDeMovAtual   = gerDeMovNormal;
        }
    }

    public void start(GarraDto garraDto)
    {
        cabo.start(garraDto.CaboDaGarraDto);
        gerDeMovAtual.iniciarMovimentacoes();
    }

    public void update(GarraDto garraDto, InputGame inputGame)
    {
        gerDeMovAtual.update(inputGame);
        cabo.update(garraDto.CaboDaGarraDto);
    }

    public void fixedUpdate(GarraDto garraDto)
    {
        gerDeMovAtual.fixedUpdate();
        cabo.fixedUpdate(garraDto.CaboDaGarraDto, garraDto.RigidBody.transform);
    }

    private void processarGarraColidiuCom(Collider2D other)
    {
        gerDeMovAtual.garraColidiuCom(other);
    }

    private void configurarColisorCentroDaPinca(GameObject goColisor)
    {
        DetectorDeTriggers detectorDeColisoes = goColisor.GetComponent<DetectorDeTriggers>();
        detectorDeColisoes.registrarConsumidorDeTrigger(this);
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

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
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

    //TODO tentar unificar
    ProdutorDeEvento<InformacoesDaGarraDto> AcaoInfoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return gerDeMovNormal == null ? null : ((AcaoInfoDaGarra.ProdutorEvento)gerDeMovNormal).getProdutorDeEvento();        
    }   

    ProdutorDeEvento<DirecaoDaGarra> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return gerDeMovAtual.getProdutorDeEvento();
    }   
}
