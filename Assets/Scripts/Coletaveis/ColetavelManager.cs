using UnityEngine;

public class ColetavelManager : ConsumidorDeEventoTrigger
{
    private ColetaveisDto coletaveisDto;

    private Board board;
    private PoolDeColetaveis poolDeColetaveis;
    private ContadorDeColetaveis contadorDeColetaveis;
    private ColetaveisParaTuboDeSaida coletaveisSaidaTubo;

    private ProdutorDeEvento<InformacoesColetado> produtorDeInformacoesDoColetado;

    public ColetavelManager(ColetaveisDto coletaveisDto, MonoBehaviour monoBehaviour)
    {
        this.coletaveisDto = coletaveisDto;

        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);
        configurarPoolDeColetaveis(coletaveisDto);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetado>();
        board = new Board(coletaveisDto.BoardDto);        
        contadorDeColetaveis   = new ContadorDeColetaveis(board.getTotalColetaveis());
        coletaveisSaidaTubo    = new ColetaveisParaTuboDeSaida(coletaveisDto.TuboDto, monoBehaviour);
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

        board.devolver(contadorDeColetaveis.getArrayBoard());
        coletaveisSaidaTubo.devolver(contadorDeColetaveis.getArrayTubo());

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetado infoColetado = new InformacoesColetado();
        infoColetado.addInfosDisplayColetados(coletavelAcertado.getSprite(), contadorDeColetaveis.hasResetColetados(), contadorDeColetaveis.getResult());
        infoColetado.addInfosDisplayScore(contadorDeColetaveis.getScore());
        infoColetado.addInfosPosicao(gameObjectColetado.transform.position);

        produtorDeInformacoesDoColetado.produziuEvento(infoColetado);         
    }

    public void fixedUpdate() { }    

    public ProdutorDeEvento<InformacoesColetado> getProdutorDeInfoColetado()
    {
        return produtorDeInformacoesDoColetado;
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //É DISPARADO QDO SENSOR PEGA UM COLETAVEL QUE A VELOCIDADE Y É POSITIVA
    public void consumirEvento(Collider2D goColetado)
    {
        if (goColetado.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y > 0)
        {            
            processarColetado(goColetado.gameObject);
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM
}
