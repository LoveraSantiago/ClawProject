using UnityEngine;

public class ColetaveisManager : ConsumidorDeEventoTrigger,
                                AcaoColetado.ProdutorEvento,                              
                                AcaoBoardElevadoFim.ProdutorEvento,
                                AcaoColetadoFim.ConsumidorEvento,
                                AcaoInfoDaGarra.ConsumidorEvento,                                
                                AcaoPUpAcionado.ConsumidorEvento,                                
                                AcaoTempoEsgotado.ConsumidorEvento
{    
    private ColetavelTile coletavelImantado;
    
    private BoardManager board;
    private TuboDeDescarte tuboDeDescarte;
    private EfeitoColetado efeito;
    private PoolDeColetaveis poolDeColetaveis;

    private ContadorDeColetaveis         contador;
    public  ContadorDeColetaveisOrdenado contadorOrdenado { get; private set; }

    private DetectorDeTriggers detectorDeTrigger;

    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeInformacoesDoColetado;    

    public ColetaveisManager(ColetaveisDto coletaveisDto)
    {        
        poolDeColetaveis = new PoolDeColetaveis();
        configuracoes(coletaveisDto);        

        board            = new BoardManager(coletaveisDto.BoardDto);
        contador         = new ContadorDeColetaveis(coletaveisDto.PontosColetados, coletaveisDto.PontosAcerto);
        contadorOrdenado = new ContadorDeColetaveisOrdenado(coletaveisDto.EfeitoOutline);
        tuboDeDescarte   = new TuboDeDescarte(coletaveisDto.DescarteTuboDto);
        efeito           = new EfeitoColetado(coletaveisDto.EfeitoColetado);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    private void configuracoes(ColetaveisDto coletaveisDto)
    {
        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarColetaveis(coletaveisDto);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        board.configuradoPeloLevel(level);
        tuboDeDescarte.configuradoPeloLevel(level.devolverParaBoard());
        contadorOrdenado.configuradoPeloLevel(level);
    }

    public void start()//TODO TALVEZ START POSSA SER CHAMADO PELO CONFIGURADOPELOLEVEL
    {
        int qtdColetaveisDoBoard = board.create(poolDeColetaveis);
        contador.configurarTotalColetaveis(qtdColetaveisDoBoard);
        coletavelImantado = poolDeColetaveis.getColetavelPeloNome("1");//PEGANDO UM COLETAVEL DEFAULT P EVITAR NULL CHECK        
        contadorOrdenado.iniciar(poolDeColetaveis);
    }    

    private void configurarSensorDeColetado(GameObject goSensorDeColetado)
    {
        detectorDeTrigger = goSensorDeColetado.GetComponent<DetectorDeTriggers>();
        detectorDeTrigger.registrarConsumidorDeTrigger(this);
    }

    private void configurarColetaveis(ColetaveisDto coletaveisDto)
    {
        Coletavel.configurar(coletaveisDto);
        HelperColetavelEntidade.configurar();
        HelperColetaveisInGame.configurar(poolDeColetaveis);
        ColetavelTile.configurar(coletaveisDto.ReferenciaColliderColetado);
    }

    private void processarColetado(GameObject gameObjectColetado)
    {
        contador.subtrairColetavel();
        ColetavelTile coletavelAcertado = poolDeColetaveis.getColetavelPeloNome(gameObjectColetado.name);
        coletavelAcertado.desligar();        

        contador.adicionarColetado(coletavelAcertado);
        bool resultOrdem = contadorOrdenado.contarOrdem(coletavelAcertado, poolDeColetaveis);

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetadoDto infoColetadoDto = new InformacoesColetadoDto();
        infoColetadoDto.addInfosDisplayColetados(coletavelAcertado.getSprite(), contador.resultCombinacao);
        infoColetadoDto.addInfosDisplayScore(contador.score, contadorOrdenado.contador);
        infoColetadoDto.addInfoFinalizado(contador.isFinished, resultOrdem);

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

    void AcaoInfoDaGarra.ConsumidorEvento.consumirEvento(InformacoesDaGarraDto evento)
    {
        if (evento.isImantadoInfo)
        {
            coletavelImantado = poolDeColetaveis.getColetavelPeloNome(evento.nomeColetado);
            coletavelImantado.imantar();
        }
        else if (evento.isNotImantadoInfo)
        {
            processarDesimantado();
        }
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
        tuboDeDescarte.devolver(contador.resultCombinacao, evento, contador.coletados, poolDeColetaveis);        
        board.devolver(contador.resultCombinacao, evento, contador.coletados);
        contador.reajustarContagem(evento, board.isDevolverBoard());
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeInformacoesDoColetado;
    }

    ProdutorDeEvento<SubidaBoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBoardElevadoFim.ProdutorEvento)board).getProdutorDeEvento();
    }
}
