using UnityEngine;

public class ColetavelManager : ConsumidorDeEventoTrigger,
                                ConsumidorDeEvento<string>,
                                ConsumidorDeEvento<int>
{
    private ColetaveisDto coletaveisDto;
    private Coletavel coletavelImantado;

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

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetado>();
        board = new Board(coletaveisDto.BoardDto);        
        contadorDeColetaveis   = new ContadorDeColetaveis(board.getTotalColetaveis());
        coletaveisSaidaTubo    = new ColetaveisParaTuboDeSaida(coletaveisDto.TuboDto);        
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

    public ProdutorDeEvento<InformacoesColetado> getProdutorDeInfoColetado()
    {
        return produtorDeInformacoesDoColetado;
    }

    public ConsumidorDeEvento<string> getConsumidorDeColetavelParaImantar()
    {
        return this;
    }

    public ConsumidorDeEvento<int> getConsumidorDeContagemSubidaDaGarra()
    {
        return this;
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //É DISPARADO QDO SENSOR PEGA UM COLETAVEL QUE A VELOCIDADE Y É POSITIVA
    public void consumirEvento(Collider2D goColetado)
    {
        if(goColetado.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0)
        {            
            processarColetado(goColetado.gameObject);
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //É DISPARADO QDO SENSOR PEGA UM COLETAVEL QUE A VELOCIDADE Y É POSITIVA
    public void consumirEvento(string nomeColetavel)
    {
        processarImantado(nomeColetavel);
    }

    public void consumirEvento(int evento)
    {
        processarDesimantado();
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM
}
