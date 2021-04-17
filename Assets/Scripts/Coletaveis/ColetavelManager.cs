using UnityEngine;

public class ColetavelManager : ConsumidorDeEventoTrigger,
                                ConsumidorDeEvento<string>,
                                ConsumidorDeEvento<int>,
                                ConsumidorDeEvento<PowerUpInfo>,
                                ConsumidorDeEvento<Utils.EventoVazioPowerUpFim>
{
    private bool powerUpEmAcao;

    private ColetaveisDto coletaveisDto;
    private Coletavel coletavelImantado;
    
    private Board board;
    private PoolDeColetaveis poolDeColetaveis;
    private ContadorDeColetaveis contadorDeColetaveis;
    private ColetaveisParaTuboDeSaida coletaveisSaidaTubo;

    public ProdutorDeEvento<InformacoesColetado> produtorDeInformacoesDoColetado { get; private set; }
    private MonoBehaviour monoBehaviour;

    public ColetavelManager(ColetaveisDto coletaveisDto, MonoBehaviour monoBehaviour)
    {
        this.coletaveisDto = coletaveisDto;
        this.monoBehaviour = monoBehaviour;

        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarPoolDeColetaveis(coletaveisDto);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetado>();
        board = new Board(coletaveisDto.BoardDto);        
        contadorDeColetaveis   = new ContadorDeColetaveis(board.getTotalColetaveis());
        coletaveisSaidaTubo    = new ColetaveisParaTuboDeSaida(coletaveisDto.TuboDto);

        powerUpEmAcao = false;
    }   

    public void start()
    {
        board.Create(poolDeColetaveis);
    }    

    private void configurarSensorDeColetado(GameObject goSensorDeColetado)
    {
        DetectorDeTriggers detectorDeTrigger = goSensorDeColetado.GetComponent<DetectorDeTriggers>();
        detectorDeTrigger.registrarConsumidorDeTrigger(this);
    }

    private void configurarPoolDeColetaveis(ColetaveisDto coletaveisDto)
    {
        Coletavel.configurarMainTile(coletaveisDto.Tile, coletaveisDto.BoardDto.startBoard);
        poolDeColetaveis = new PoolDeColetaveis();
    }

    private void processarColetado(GameObject gameObjectColetado)
    {
        Coletavel coletavelAcertado = poolDeColetaveis.getColetavelPeloNome(gameObjectColetado.name);
        coletavelAcertado.desligar();        

        contadorDeColetaveis.adicionarColetado(coletavelAcertado);

        board.devolver(contadorDeColetaveis.getArrayBoard(), monoBehaviour);
        coletaveisSaidaTubo.devolver(contadorDeColetaveis.getArrayTubo(), monoBehaviour);

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetado infoColetado = new InformacoesColetado();
        infoColetado.addInfosDisplayColetados(coletavelAcertado.getSprite(), contadorDeColetaveis.hasResetColetados(), contadorDeColetaveis.getResult());
        infoColetado.addInfosDisplayScore(contadorDeColetaveis.getScore());
        infoColetado.addInfosPosicao(gameObjectColetado.transform.position);

        produtorDeInformacoesDoColetado.produziuEvento(infoColetado);         
    }

    public void fixedUpdate() { }    

    private void processarImantado(string nomeColetado)
    {        
        coletavelImantado = poolDeColetaveis.getColetavelPeloNome(nomeColetado);
        coletavelImantado.imantar();
    }

    private void processarDesimantado()
    {
        coletavelImantado.desimantar();
    }    

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER INICIO
    //É DISPARADO QDO SENSOR PEGA UM COLETAVEL QUE A VELOCIDADE Y É POSITIVA
    public void consumirEvento(Collider2D goColetado)
    {
        if(goColetado.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0 &&
            !powerUpEmAcao)
        {            
            processarColetado(goColetado.gameObject);
        }
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER FIM

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<STRING> INICIO    
    public void consumirEvento(string nomeColetavel)
    {
        processarImantado(nomeColetavel);
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<STRING> FIM

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INT> INICIO    
    public void consumirEvento(int evento)
    {
        processarDesimantado();
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<INT> FIM    

    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<POWERUPINFO> INICIO    
    public void consumirEvento(PowerUpInfo powerUpInfo)
    {
        powerUpEmAcao = true;
    }

    public void consumirEvento(Utils.EventoVazioPowerUpFim evento)
    {
        powerUpEmAcao = false;
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTO<POWERUPINFO> FIM    

    public ConsumidorDeEvento<string> getConsumidorDeColetavelParaImantar()
    {
        return this;
    }

    public ConsumidorDeEvento<int> getConsumidorDeContagemSubidaDaGarra()
    {
        return this;
    }

    public ConsumidorDeEvento<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return this;
    }

    public ConsumidorDeEvento<Utils.EventoVazioPowerUpFim> getConsumidorDePowerUpFim()
    {
        return this;
    }
}
