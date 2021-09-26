using UnityEngine;

public class ColetaveisManager : ConsumidorDeEventoTrigger,
                                AcaoColetado.ProdutorEvento,                              
                                AcaoBoardElevadoFim.ProdutorEvento,
                                AcaoColetadoFim.ConsumidorEvento,
                                AcaoImantadoPelaGarra.ConsumidorEvento,
                                AcaoSubidaDaGarra.ConsumidorEvento,                                
                                AcaoPUpAcionado.ConsumidorEvento,                                
                                AcaoTempoEsgotado.ConsumidorEvento
{
    private ColetaveisDto coletaveisDto;
    private ColetavelTile coletavelImantado;
    
    private BoardManager board;
    private TuboDeSaida tuboSaida;
    private EfeitoColetado efeito;
    private PoolDeColetaveis poolDeColetaveis;
    private ContadorDeColetaveis contador;
    private ContadorOrdenadoDeColetaveis contadorOrdenado;
    private DetectorDeTriggers detectorDeTrigger;

    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeInformacoesDoColetado;    

    public ColetaveisManager(ColetaveisDto coletaveisDto)
    {
        this.coletaveisDto = coletaveisDto;

        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarPoolDeColetaveis(coletaveisDto);

        board     = new BoardManager(coletaveisDto.BoardDto);
        contador  = new ContadorDeColetaveis(coletaveisDto.PontosColetados, coletaveisDto.PontosAcerto);
        contadorOrdenado = new ContadorOrdenadoDeColetaveis();
        tuboSaida = new TuboDeSaida(coletaveisDto.TuboDto);
        efeito    = new EfeitoColetado(coletaveisDto.EfeitoColetado);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetadoDto>();

        ColetavelTile.configReferenciaColliderColetado(coletaveisDto.ReferenciaColliderColetado);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        board.configuradoPeloLevel(level);
        tuboSaida.configuradoPeloLevel(level.devolverParaBoard());
    }

    public void start()//TODO TALVEZ START POSSA SER CHAMADO PELO CONFIGURADOPELOLEVEL
    {
        int qtdColetaveisDoBoard = board.create(poolDeColetaveis);
        contador.configurarTotalColetaveis(qtdColetaveisDoBoard);
        coletavelImantado = poolDeColetaveis.getColetavelPeloNome("1");//PEGANDO UM COLETAVEL DEFAULT P EVITAR NULL CHECK
    }    

    private void configurarSensorDeColetado(GameObject goSensorDeColetado)
    {
        detectorDeTrigger = goSensorDeColetado.GetComponent<DetectorDeTriggers>();
        detectorDeTrigger.registrarConsumidorDeTrigger(this);
    }

    private void configurarPoolDeColetaveis(ColetaveisDto coletaveisDto)
    {
        Coletavel.configurar(coletaveisDto);
        poolDeColetaveis = new PoolDeColetaveis();
        ColetavelQuery.inicializarDicionarioDeColetaveisInGame(poolDeColetaveis);
    }

    private void processarColetado(GameObject gameObjectColetado)
    {
        contador.subtrairColetavel();
        ColetavelTile coletavelAcertado = poolDeColetaveis.getColetavelPeloNome(gameObjectColetado.name);
        coletavelAcertado.desligar();        

        contador.adicionarColetado(coletavelAcertado);        

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetadoDto infoColetadoDto = new InformacoesColetadoDto();
        infoColetadoDto.addInfosDisplayColetados(coletavelAcertado.getSprite(), contador.resultCombinacao);
        infoColetadoDto.addInfosDisplayScore(contador.getScore());
        infoColetadoDto.addInfosPosicao(gameObjectColetado.transform.position);
        infoColetadoDto.addInfoFinalizado(contador.hasFinished());

        efeito.acionarEfeito(gameObjectColetado.transform.position);
        produtorDeInformacoesDoColetado.produziuEvento(infoColetadoDto);         
    }

    private void processarDesimantado()
    {
        coletavelImantado.desimantar();
    }

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER INICIO
    //É DISPARADO QDO SENSOR PEGA UM COLETAVEL QUE A VELOCIDADE Y É POSITIVA
    public void consumir(Collider2D goColetado)
    {
        //Debug.Log("Nome Coletado: " + goColetado.name);
        if (poolDeColetaveis.contemNome(goColetado.name))
        {
            ColetavelTile coletado = poolDeColetaveis.getColetavelPeloNome(goColetado.name);            
            if(coletado.isTouchingCentroDaGarra())
            {            
                processarColetado(goColetado.gameObject);
            }
        }
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER FIM         

    void AcaoImantadoPelaGarra.ConsumidorEvento.consumirEvento(InformacoesColetadoImantadoDto evento)
    {
        coletavelImantado = poolDeColetaveis.getColetavelPeloNome(evento.nomeColetado);
        coletavelImantado.imantar();
    }

    void AcaoSubidaDaGarra.ConsumidorEvento.consumirEvento(ContagemSubidaGarra evento)
    {
        processarDesimantado();
    }

    void AcaoPUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            processarDesimantado();
            if (evento.isNotColetavel)
            {
                detectorDeTrigger.desligarTrigger();
            }
        }
        else if (evento.isPreFinalizar && evento.hasColetavel)
        {
            processarColetado(evento.coletavelTile.getGoColetavel());
        }        
        else if (evento.isFinalizar)
        {
            detectorDeTrigger.ligarTrigger();
        }
    }            
    
    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        if (evento.restart)
        {
            int qtdAtivados = board.subirBoard(poolDeColetaveis);
            contador.adicionarColetaveisExtras(qtdAtivados);            
        }        
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFim evento)
    {
        tuboSaida.devolver(contador.resultCombinacao, evento, contador.getColetados(), poolDeColetaveis);        
        board.devolver(contador.resultCombinacao, evento, contador.getColetados());
        contador.reajustarContagem(evento, board.isDevolverBoard());
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeInformacoesDoColetado;
    }

    ProdutorDeEvento<BoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBoardElevadoFim.ProdutorEvento)board).getProdutorDeEvento();
    }
}
