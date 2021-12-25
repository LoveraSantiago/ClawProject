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
    private ContadorManager contador;

    private DetectorDeTriggers detectorDeTrigger;

    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeInformacoesDoColetado;    

    public ColetaveisManager(ColetaveisDto coletaveisDto)
    {   
        configuracoes(coletaveisDto);        

        board          = new BoardManager(coletaveisDto.BoardDto);
        contador       = new ContadorManager(coletaveisDto);
        tuboDeDescarte = new TuboDeDescarte(coletaveisDto.DescarteTuboDto);
        efeito         = new EfeitoColetado(coletaveisDto.EfeitoColetado);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    private void configuracoes(ColetaveisDto coletaveisDto)
    {
        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarColetaveis(coletaveisDto);
        //new MateriaisUtils()
        //    .configurarOutline(coletaveisDto.EfeitoOutline);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        board.configuradoPeloLevel(level);
        tuboDeDescarte.configuradoPeloLevel(level.devolverParaBoard());
        contador.configuradoPeloLevel(level);
    }

    public void start()//TODO TALVEZ START POSSA SER CHAMADO PELO CONFIGURADOPELOLEVEL
    {
        int qtdColetaveisDoBoard = board.create();
        contador.iniciar(qtdColetaveisDoBoard);

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        coletavelImantado = helperInGame.getColetavelInGameByGoName("1");//PEGANDO UM COLETAVEL DEFAULT P EVITAR NULL CHECK    
    }    

    public Fornecedor<TrocadorDeOrdem> getFornecedorTrocadorDeOrdem()
    {
        return contador.getFornecedorTrocadorDeOrdem();
    }

    private void configurarSensorDeColetado(GameObject goSensorDeColetado)
    {
        detectorDeTrigger = goSensorDeColetado.GetComponent<DetectorDeTriggers>();
        detectorDeTrigger.registrarConsumidorDeTrigger(this);
    }

    private void configurarColetaveis(ColetaveisDto coletaveisDto)
    {
        GO.configurar(coletaveisDto);
        HelperColetavelEntidade.configurar();
        HelperColetaveisInGame.configurar();
        ColetavelTile.configurar(coletaveisDto.ReferenciaColliderColetado);
    }

    private void processarColetado(GameObject gameObjectColetado)
    {        
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        ColetavelTile coletavelAcertado = helperInGame.getColetavelInGameByGoName(gameObjectColetado.name);
        coletavelAcertado.desligar();

        int score = contador.contarColetado(coletavelAcertado);

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetadoDto infoColetadoDto = new InformacoesColetadoDto();
        infoColetadoDto.addInfosDisplayColetados(coletavelAcertado.getSprite(), contador.getResultCombinacao());
        infoColetadoDto.addInfosDisplayScore(score, contador.getIndiceOrdem());
        infoColetadoDto.addInfoFimDeJogo(contador.getInfoFimDeJogo());

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
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        if (helperInGame.temColetavelInGameByNome(goColetado.name))
        {
            ColetavelTile coletado = helperInGame.getColetavelInGameByGoName(goColetado.name);            
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
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            coletavelImantado = helperInGame.getColetavelInGameByGoName(evento.nomeColetado);
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
            int qtdAtivados = board.subirBoard();
            contador.adicionarColetaveisExtras(qtdAtivados);            
        }        
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFim evento)
    {        
        tuboDeDescarte.devolver(contador.getResultCombinacao(), evento, contador.getColetados());                
        board.devolver(contador.getResultCombinacao(), evento, contador.getColetados());        
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
