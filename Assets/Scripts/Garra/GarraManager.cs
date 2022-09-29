using UnityEngine;

public class GarraManager : AcaoInfoDaGarra.ProdutorEvento,                            
                            AcaoSincroniaComDirecaoDaGarra.ProdutorEvento,
                            AcaoColetado.ConsumidorEvento,
                            AcaoPowerUpAcionado.ConsumidorEvento,                            
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
        AbstractMovimentacaoDaGarra.configurar(garraDto);
        cabo = new CaboDaGarra(garraDto.CaboDaGarraDto);

        if(LevelUtils.isCacaNiquelLevel(ContextoEstaticoUtils.level))
        {
            gerDeMovAtual = new GerenciadorDeMovimentacaoCacaNiquel();
        }
        else
        {
            configurarColisorCentroDaPinca(garraDto.Corpo.Colisor);
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
        cabo.fixedUpdate(garraDto.CaboDaGarraDto, garraDto.Corpo.TransformBaseCorpo.transform);
    }    

    private void configurarColisorCentroDaPinca(GameObject goColisor)
    {
        DetectorDeTriggers detectorDeColisoes = goColisor.GetComponent<DetectorDeTriggers>();
        detectorDeColisoes.registrarConsumidorDeTrigger(this);
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            gerDeMovPowerUp.receberGarraInteracaoComPowerUp(evento.interacaoComComponentes, evento.duracaoTempo);
            gerDeMovPowerUp.iniciarMovimentacoes();
            gerDeMovAtual = gerDeMovPowerUp;
        }
        else if (evento.isExpirado)
        {
            gerDeMovPowerUp.largarPowerUp();
        }
        else if (evento.isFinalizar)
        {
            gerDeMovPowerUp.finalizarPowerUp();
            gerDeMovNormal.trocarParaAcaoNormal();
            gerDeMovAtual = gerDeMovNormal;
        }
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QDO GARRA COLLIDE COM UM COLETAVEL
    public void consumir(Collider2D colliderDeColetavel)
    {        
        gerDeMovAtual.garraColidiuCom(colliderDeColetavel);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM
   
    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {        
        gerDeMovAtual.garraComemorar();
    }        

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotadoDto evento)
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

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        if (gerDeMovAtual != gerDeMovPowerUp && !tempoEsgotadoEmAcao)
        {
            gerDeMovNormal.iniciarMovimentacoes();            
        }
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelEventoDto evento)
    {
        if (evento.isInicio)
        {
            gerDeMovAtual.iniciarMovimentacoes();
        }
        else if (evento.isEmAndamento && evento.isResultSucesso())
        {
            gerDeMovAtual.garraComemorar();
        }
    }

    //TODO tentar unificar
    ProdutorDeEvento<InformacoesDaGarraDto> AcaoInfoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return gerDeMovNormal == null ? null : ((AcaoInfoDaGarra.ProdutorEvento)gerDeMovNormal).getProdutorDeEvento();        
    }   

    ProdutorDeEvento<Direcao> AcaoSincroniaComDirecaoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return gerDeMovAtual.getProdutorDeEvento();
    }   
}
