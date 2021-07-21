using UnityEngine;

public class ColetavelManager : AcaoColetado.ProdutorEvento,
                                ConsumidorDeEventoTrigger,
                                Consumidor<string>,
                                Consumidor<int>,
                                Consumidor<PowerUpInfo>,
                                Consumidor<PowerUpInfoFim>,
                                Consumidor<bool>
{
    private bool powerUpEmAcao;
    private bool devolverParaBoard;

    private ColetaveisDto coletaveisDto;
    private ColetavelTile coletavelImantado;
    
    private Board board;
    private PoolDeColetaveis poolDeColetaveis;
    private ContadorDeColetaveis contadorDeColetaveis;
    private ColetaveisParaTuboDeSaida coletaveisSaidaTubo;

    private ProdutorDeEvento<InformacoesColetado> produtorDeInformacoesDoColetado;
    private MonoBehaviour monoBehaviour;

    public ColetavelManager(ColetaveisDto coletaveisDto, MonoBehaviour monoBehaviour)
    {
        this.coletaveisDto = coletaveisDto;
        this.monoBehaviour = monoBehaviour;        

        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarPoolDeColetaveis(coletaveisDto);

        board = new Board(coletaveisDto.BoardDto);

        contadorDeColetaveis   = new ContadorDeColetaveis();
        coletaveisSaidaTubo    = new ColetaveisParaTuboDeSaida(coletaveisDto.TuboDto);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetado>();
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        board.configuradoPeloLevel(level);
        devolverParaBoard = level.devolverParaBoard();
    }

    public void start()//TODO TALVEZ START POSSA SER CHAMADO PELO CONFIGURADOPELOLEVEL
    {
        powerUpEmAcao = false;
        board.create(poolDeColetaveis);
        contadorDeColetaveis.configurarTotalColetaveis(board.getTotalColetaveis(), devolverParaBoard);
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
        coletaveisSaidaTubo.devolver(contadorDeColetaveis.getArrayTubo(), monoBehaviour);
        poolDeColetaveis.inativarColetaveis(contadorDeColetaveis.getArrayTubo());

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetado infoColetado = new InformacoesColetado();
        infoColetado.addInfosDisplayColetados(coletavelAcertado.getSprite(), contadorDeColetaveis.getResult());
        infoColetado.addInfosDisplayScore(contadorDeColetaveis.getScore());
        infoColetado.addInfosPosicao(gameObjectColetado.transform.position);
        infoColetado.addInfoFinalizado(contadorDeColetaveis.hasFinished());

        produtorDeInformacoesDoColetado.produziuEvento(infoColetado);         
    }    

    private void processarImantado(string nomeColetado)
    {        
        coletavelImantado = poolDeColetaveis.getColetavelPeloNome(nomeColetado);
        coletavelImantado.imantar();
    }

    private void processarDesimantado()
    {
        coletavelImantado.desimantar();
    }    

    private void processarInicioPowerUp(PowerUpInfo pupInfo)
    {
        powerUpEmAcao = true;
        processarDesimantado();
    }

    private void processarPreFimDePowerUp(PowerUpInfoFim pupPreFim)
    {
        if (pupPreFim.hasColetavel)
        {
            processarColetado(pupPreFim.coletavelTile.getGoColetavel());
        }
    }

    private void processarFimDePowerUp()
    {
        powerUpEmAcao = false;
    }

    private void processarEventoElevador()
    {

    }

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER INICIO
    //É DISPARADO QDO SENSOR PEGA UM COLETAVEL QUE A VELOCIDADE Y É POSITIVA
    public void consumir(Collider2D goColetado)
    {
        //Debug.Log("Nome Coletado: " + goColetado.name);
        if(goColetado.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0 &&
            !powerUpEmAcao)
        {            
            processarColetado(goColetado.gameObject);
        }
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER FIM

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<STRING> INICIO    
    public void consumir(string nomeColetavel)
    {
        processarImantado(nomeColetavel);
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<STRING> FIM

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INT> INICIO    
    public void consumir(int evento)
    {
        processarDesimantado();
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INT> FIM    

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<POWERUPINFO> INICIO    
    public void consumir(PowerUpInfo powerUpInfo)
    {
        processarInicioPowerUp(powerUpInfo);
    }

    public void consumir(PowerUpInfoFim powerUpInfoFim)
    {
        if (powerUpInfoFim.preFinalizar)
        {
            processarPreFimDePowerUp(powerUpInfoFim);
        }
        if (powerUpInfoFim.finalizar)
        {
            processarFimDePowerUp();
        }
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<POWERUPINFO> FIM    

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<bool> INICIO    
    public void consumir(bool evento)
    {
        processarEventoElevador();
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<bool> FIM    

    //CONSUMIDORES DE EVENTOS INICIO
    public Consumidor<string> getConsumidorDeColetavelParaImantar()
    {
        return this;
    }

    public Consumidor<int> getConsumidorDeContagemSubidaDaGarra()
    {
        return this;
    }

    public Consumidor<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return this;
    }

    public Consumidor<PowerUpInfoFim> getConsumidorDePowerUpFim()
    {
        return this;
    }

    public Consumidor<bool> getConsumidorEventoElevador()
    {
        return this;
    }
    //CONSUMIDORES DE EVENTOS FIM  

    ProdutorDeEvento<InformacoesColetado> AcaoColetado.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeInformacoesDoColetado;
    }
}
