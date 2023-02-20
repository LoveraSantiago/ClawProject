using UnityEngine;

public class GarraManager : AcaoInfoDaGarra.ProdutorEvento,                            
                            AcaoSincroniaComDirecaoDaGarra.ProdutorEvento,
                            AcaoColetado.ConsumidorEvento,
                            AcaoPowerUpAcionado.ConsumidorEvento,                            
                            AcaoTempoEsgotado.ConsumidorEvento,
                            AcaoBoardElevadoFim.ConsumidorEvento,
                            AcaoColetadoFim.ConsumidorEvento,
                            AcaoCacaNiquel.ConsumidorEvento,
                            AcaoDesligarMaquina.ConsumidorEvento,
                            ConsumidorDeEventoTrigger,
                            Fornecedor<int>
{
    private bool tempoEsgotadoEmAcao;
    private bool gameOver;

    private CaboDaGarra cabo;
    private GerenciadorDeMovimentacaoNormal  gerDeMovNormal;
    private GerenciadorDeMovimentacaoPowerUp gerDeMovPowerUp;
    private GerenciadorDeMovimentacao        gerDeMovAtual;

    public GarraManager(GarraDto garraDto, SomGarra somGarra)
    {
        AbstractMovimentacaoDaGarra.configurar(garraDto, somGarra);
        cabo = new CaboDaGarra(garraDto.CaboDaGarraDto);
        gameOver = false;

        if(LevelUtils.isCacaNiquelLevel())
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
        //Debug.log("garra start");
        cabo.start(garraDto.CaboDaGarraDto);
        gerDeMovAtual.iniciarMovimentacoes();        
    }

    public void update(GarraDto garraDto, InputGame inputGame)
    {
        //Debug.log("garra update");        
        gerDeMovAtual.update(inputGame);
        cabo.update(garraDto.CaboDaGarraDto);
        
    }

    public void fixedUpdate(GarraDto garraDto)
    {
        //Debug.log("garra fixedUpdate");
        
        gerDeMovAtual.fixedUpdate();        
        cabo.fixedUpdate(garraDto.CaboDaGarraDto, garraDto.Corpo.TransformBaseCorpo.transform);        
    }      

    public void parar()
    {
        Debug.Log("garra parar");
        gerDeMovNormal.trocarParaAcaoParado();
        gerDeMovAtual = gerDeMovNormal;
        ////Debug.log(gerDeMovAtual);
    }

    private void pararGameOver()
    {
        gameOver = true;
        parar();
    }

    public int fornecer()
    {
        return gerDeMovAtual.getContagemDeSubidas();
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QDO GARRA COLLIDE COM UM COLETAVEL
    public void consumir(Collider2D colliderDeColetavel)
    {
        //Debug.log("garra consumindo evento Collider2D");
        gerDeMovAtual.garraColidiuCom(colliderDeColetavel);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM

    private void configurarColisorCentroDaPinca(GameObject goColisor)
    {
        DetectorDeTriggers detectorDeColisoes = goColisor.GetComponent<DetectorDeTriggers>();
        detectorDeColisoes.registrarConsumidorDeTrigger(this);
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfoDto evento)
    {
        //Debug.log("garra consumindo evento PowerUpInfoDto");
        if (evento.isEstadoInicio)
        {
            gerDeMovPowerUp.receberGarraInteracaoComPowerUp(evento.interacaoPupComComponentes);
            gerDeMovPowerUp.iniciarMovimentacoes();
            gerDeMovAtual = gerDeMovPowerUp;
        }
        else if (evento.isEstadoExpirado)
        {
            gerDeMovPowerUp.largarPowerUp();
        }
        else if (evento.isEstadoFinalizar)
        {
            gerDeMovPowerUp.finalizarPowerUp();
            gerDeMovNormal.trocarParaAcaoNormal();
            gerDeMovAtual = gerDeMovNormal;
        }
    }
   
    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        //Debug.log("garra consumindo evento InformacoesColetadoDto");
        InformacoesFimDeJogoDto infoFimDeJogo = evento.infosFimDeJogo;
        if (infoFimDeJogo.fimDeJogo)
        {
            pararGameOver();
        }
        else
        {
            gerDeMovAtual.garraComemorar();
        }
    }        

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotadoDto evento)
    {
        //Debug.log("garra consumindo evento TempoEsgotadoDto");
        if (!evento.isTimeOver())
        {
            if (!gameOver)
            {
                tempoEsgotadoEmAcao = true;        
                gerDeMovNormal.trocarParaAcaoVoltarParaCima();
                gerDeMovAtual = gerDeMovNormal;
            }
        }
        else
        {
            pararGameOver();
        }
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        //Debug.log("garra consumindo evento SubidaBoardAcaoFim");
        if (!evento.isGameOver)
        {
            if (!gameOver)
            {
                tempoEsgotadoEmAcao = false;
                gerDeMovNormal.iniciarMovimentacoes();
                gerDeMovAtual = gerDeMovNormal;
            }
        }
        else
        {
            pararGameOver();
        }
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        //Debug.log("garra consumindo evento ColetadoFimDto");
        if (gerDeMovAtual != gerDeMovPowerUp && !tempoEsgotadoEmAcao && gerDeMovAtual.getContagemDeSubidas() > 0)
        {
            if (!gameOver)
            {
                gerDeMovNormal.iniciarMovimentacoes();            
            }
        }
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelEventoDto evento)
    {
        //Debug.log("garra consumindo evento CacaNiquelEventoDto");
        if (evento.isInicio)
        {
            gerDeMovAtual.iniciarMovimentacoes();
        }
        else if (evento.isEmAndamento && evento.isResultSucesso())
        {
            gerDeMovAtual.garraComemorar();
        }
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
    {
        pararGameOver();
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
