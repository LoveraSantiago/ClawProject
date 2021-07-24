using UnityEngine;

public class ColetavelManager : ConsumidorDeEventoTrigger,
                                AcaoColetado.ProdutorEvento,                                
                                AcaoImantadoPelaGarra.ConsumidorEvento,
                                AcaoSubidaDaGarra.ConsumidorEvento,                                
                                AcaoPowerUpInicio.ConsumidorEvento,
                                AcaoPowerUpFim.ConsumidorEvento,
                                AcaoElevadorFim.ConsumidorEvento
{
    private bool powerUpEmAcao;
    private bool devolverParaBoard;

    private ColetaveisDto coletaveisDto;
    private ColetavelTile coletavelImantado;
    
    private Board board;
    private PoolDeColetaveis poolDeColetaveis;
    private ContadorDeColetaveis contadorDeColetaveis;
    private TuboDeSaida tudoDeSaida;

    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeInformacoesDoColetado;
    private MonoBehaviour monoBehaviour;

    public ColetavelManager(ColetaveisDto coletaveisDto, MonoBehaviour monoBehaviour)
    {
        this.coletaveisDto = coletaveisDto;
        this.monoBehaviour = monoBehaviour;        

        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarPoolDeColetaveis(coletaveisDto);

        board = new Board(coletaveisDto.BoardDto);
        contadorDeColetaveis = new ContadorDeColetaveis();
        tudoDeSaida = new TuboDeSaida(coletaveisDto.TuboDto);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        board.configuradoPeloLevel(level);
        devolverParaBoard = level.devolverParaBoard();
    }

    public void start()//TODO TALVEZ START POSSA SER CHAMADO PELO CONFIGURADOPELOLEVEL
    {
        powerUpEmAcao = false;
        int qtdColetaveisDoBoard = board.create(poolDeColetaveis);
        contadorDeColetaveis.configurarTotalColetaveis(qtdColetaveisDoBoard, devolverParaBoard);
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
        ColetavelTile coletavelAcertado = poolDeColetaveis.getColetavelPeloNome(gameObjectColetado.name);
        coletavelAcertado.desligar();        

        contadorDeColetaveis.adicionarColetado(coletavelAcertado);

        board.devolver(contadorDeColetaveis.getArrayBoard(), monoBehaviour);
        tudoDeSaida.devolver(contadorDeColetaveis.getArrayTubo(), monoBehaviour);
        poolDeColetaveis.inativarColetaveis(contadorDeColetaveis.getArrayTubo());

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
        ColetavelTile coletado = poolDeColetaveis.getColetavelPeloNome(goColetado.name);        
        if(coletado.isVelocidadeYPositiva() && !powerUpEmAcao)
        {            
            processarColetado(goColetado.gameObject);
        }
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER FIM         

    void AcaoImantadoPelaGarra.ConsumidorEvento.consumirEvento(InformacoesColetadoImantado evento)
    {
        coletavelImantado = poolDeColetaveis.getColetavelPeloNome(evento.nomeColetado);
        coletavelImantado.imantar();
    }

    void AcaoSubidaDaGarra.ConsumidorEvento.consumirEvento(ContagemSubidaGarra evento)
    {
        processarDesimantado();
    }

    void AcaoPowerUpInicio.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {        
        powerUpEmAcao = true;
        processarDesimantado();
    }        

    void AcaoPowerUpFim.ConsumidorEvento.consumirEvento(PowerUpInfoFim evento)
    {     
        if (evento.preFinalizar && evento.hasColetavel)
        {
            processarColetado(evento.coletavelTile.getGoColetavel());
        }
        else if (evento.finalizar)
        {
            powerUpEmAcao = false;
        }
    }
    
    void AcaoElevadorFim.ConsumidorEvento.consumirEvento(ElevadorFim evento)
    {
        if (!evento.finalizou)
        {
            int qtdAtivados = board.ativarColetaveisSub();
            contadorDeColetaveis.adicionarColetaveisExtras(qtdAtivados);
        }
        else
        {
            board.createSub(poolDeColetaveis);
        }
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeInformacoesDoColetado;
    }
}
