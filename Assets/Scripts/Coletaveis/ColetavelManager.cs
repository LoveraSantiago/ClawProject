using UnityEngine;

public class ColetavelManager : ConsumidorDeEventoTrigger
{
    private ColetaveisDto coletaveisDto;
    private ContadorDeColetaveis contadorDeColetaveis;
    private ColetaveisParaBoard coletaveisDeVoltaBoard;
    private ColetaveisParaTuboDeSaida coletaveisSaidaTubo;
    private Board board;

    private ProdutorDeEvento<InformacoesColetado> produtorDeInformacoesDoColetado;

    public ColetavelManager(ColetaveisDto coletaveisDto, MonoBehaviour monoBehaviour)
    {
        this.coletaveisDto = coletaveisDto;

        configurarSensorDeColetado(coletaveisDto.SensorDeColetado);

        produtorDeInformacoesDoColetado = new ProdutorDeEvento<InformacoesColetado>();
        board = new Board(coletaveisDto.BoardDto);        
        contadorDeColetaveis   = new ContadorDeColetaveis(board.getTotalColetaveis());
        coletaveisDeVoltaBoard = new ColetaveisParaBoard();
        coletaveisSaidaTubo    = new ColetaveisParaTuboDeSaida(coletaveisDto, monoBehaviour);
    }   

    public void start()
    {
        board.Create();
    }

    private void configurarSensorDeColetado(GameObject goSensorDeColetado)
    {
        DetectorDeTriggers detectorDeTrigger = goSensorDeColetado.GetComponent<DetectorDeTriggers>();
        detectorDeTrigger.registrarConsumidorDeTrigger(this);
    }

    private void processarColetado(GameObject gameObjectColetado)
    {
        Sprite sprite = gameObjectColetado.GetComponent<SpriteRenderer>().sprite;
        gameObjectColetado.SetActive(false);

        contadorDeColetaveis.adicionarColetado(gameObjectColetado.name);

        board.devolver(contadorDeColetaveis.getArrayBoard());
        coletaveisSaidaTubo.devolver(contadorDeColetaveis.getArrayTubo(), coletaveisDto.DelayQuedaTubo);

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetado infoColetado = new InformacoesColetado();
        infoColetado.addInfosDisplayColetados(sprite, contadorDeColetaveis.hasResetColetados(), contadorDeColetaveis.getResult());
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
