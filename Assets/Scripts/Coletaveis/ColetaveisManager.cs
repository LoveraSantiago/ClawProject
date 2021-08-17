using UnityEngine;

public class ColetaveisManager : ConsumidorDeEventoTrigger,
                                AcaoColetado.ProdutorEvento,                              
                                AcaoBoardElevadoFim.ProdutorEvento,
                                AcaoColetadoFim.ConsumidorEvento,
                                AcaoImantadoPelaGarra.ConsumidorEvento,
                                AcaoSubidaDaGarra.ConsumidorEvento,                                
                                AcaoPowerUp.ConsumidorEvento,                                
                                AcaoTempoEsgotado.ConsumidorEvento
{
    private bool powerUpEmAcao;    

    private ColetaveisDto coletaveisDto;
    private ColetavelTile coletavelImantado;
    
    private BoardManager boardManager;
    private PoolDeColetaveis poolDeColetaveis;
    private ContadorDeColetaveis contadorDeColetaveis;
    private TuboDeSaida tuboDeSaida;

    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeInformacoesDoColetado;
    private MonoBehaviour monoBehaviour;

    public ColetaveisManager(ColetaveisDto coletaveisDto, MonoBehaviour monoBehaviour)
    {
        this.coletaveisDto = coletaveisDto;
        this.monoBehaviour = monoBehaviour;        

        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarPoolDeColetaveis(coletaveisDto);

        boardManager = new BoardManager(coletaveisDto.BoardDto);
        contadorDeColetaveis = new ContadorDeColetaveis(coletaveisDto.PontosColetados, coletaveisDto.PontosAcerto);
        tuboDeSaida = new TuboDeSaida(coletaveisDto.TuboDto);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetadoDto>();

        ColetavelTile.configReferenciaColliderColetado(coletaveisDto.ReferenciaColliderColetado);
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        boardManager.configuradoPeloLevel(level);
        tuboDeSaida.configuradoPeloLevel(level.devolverParaBoard());
    }

    public void start()//TODO TALVEZ START POSSA SER CHAMADO PELO CONFIGURADOPELOLEVEL
    {
        powerUpEmAcao = false;
        int qtdColetaveisDoBoard = boardManager.create(poolDeColetaveis);
        contadorDeColetaveis.configurarTotalColetaveis(qtdColetaveisDoBoard);
        coletavelImantado = poolDeColetaveis.getColetavelPeloNome("1");//PEGANDO UM COLETAVEL DEFAULT P EVITAR NULL CHECK
    }    

    private void configurarSensorDeColetado(GameObject goSensorDeColetado)
    {
        DetectorDeTriggers detectorDeTrigger = goSensorDeColetado.GetComponent<DetectorDeTriggers>();
        detectorDeTrigger.registrarConsumidorDeTrigger(this);
    }

    private void configurarPoolDeColetaveis(ColetaveisDto coletaveisDto)
    {
        Coletavel.configurar(coletaveisDto.Tile, coletaveisDto.BoardDto.StartBoard, coletaveisDto.Caracteres);
        poolDeColetaveis = new PoolDeColetaveis();
        ColetavelQuery.inicializarDicionarioDeColetaveisInGame(poolDeColetaveis);
    }

    private void processarColetado(GameObject gameObjectColetado)
    {
        contadorDeColetaveis.subtrairColetavel();
        ColetavelTile coletavelAcertado = poolDeColetaveis.getColetavelPeloNome(gameObjectColetado.name);
        coletavelAcertado.desligar();        

        contadorDeColetaveis.adicionarColetado(coletavelAcertado);
        poolDeColetaveis.inativarColetavel(coletavelAcertado);

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetadoDto infoColetadoDto = new InformacoesColetadoDto();
        infoColetadoDto.addInfosDisplayColetados(coletavelAcertado.getSprite(), contadorDeColetaveis.getResult());
        infoColetadoDto.addInfosDisplayScore(contadorDeColetaveis.getScore());
        infoColetadoDto.addInfosPosicao(gameObjectColetado.transform.position);
        infoColetadoDto.addInfoFinalizado(contadorDeColetaveis.hasFinished());

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
            if(coletado.isTouchingCentroDaGarra() && !powerUpEmAcao)
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

    void AcaoPowerUp.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio())
        {
            powerUpEmAcao = true;
            processarDesimantado();
        }
        else if (evento.isFinalizar())
        {
            powerUpEmAcao = false;
        }
        else if (evento.isPreFinalizar() && evento.hasColetavel())
        {
            processarColetado(evento.coletavelTile.getGoColetavel());
        }
    }            
    
    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        if (evento.restart)
        {
            int qtdAtivados = boardManager.subirBoard(poolDeColetaveis, monoBehaviour);
            contadorDeColetaveis.adicionarColetaveisExtras(qtdAtivados);            
        }        
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFim evento)
    {
        boardManager.devolver(evento.devolverBoard(), contadorDeColetaveis.getColetados(), monoBehaviour);
        tuboDeSaida .devolver(evento.clear, contadorDeColetaveis.getColetados(), monoBehaviour);        
        contadorDeColetaveis.reajustarContagem(evento);
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeInformacoesDoColetado;
    }

    ProdutorDeEvento<BoardAcaoFim> AcaoBoardElevadoFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return ((AcaoBoardElevadoFim.ProdutorEvento)boardManager).getProdutorDeEventoColetado();
    }
}
