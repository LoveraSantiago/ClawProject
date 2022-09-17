using UnityEngine;
using System.Collections;

public class ColetaveisManager : ConsumidorDeEventoTrigger,
                                AcaoColetado.ProdutorEvento,                              
                                AcaoBoardElevadoFim.ProdutorEvento,
                                AcaoColetadoFim.ConsumidorEvento,
                                AcaoInfoDaGarra.ConsumidorEvento,                                
                                AcaoPowerUpAcionado.ConsumidorEvento,                                
                                AcaoTempoEsgotado.ConsumidorEvento
{    
    private Coletavel coletavelImantado;
    
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
        configurarGaiolas(coletaveisDto);
    }

    public void configuradoPeloLevel(AbstractLevel level, ColetaveisDto coletaveisDto)
    {
        board.configuradoPeloLevel(level, coletaveisDto.BoardDto);
        tuboDeDescarte.configuradoPeloLevel(level.devolverParaBoard());
        contador.configuradoPeloLevel(level);
    }

    public IEnumerator start()
    {
        yield return board.create();
        
        int qtdColetaveisDoBoard = HelperColetaveisInGame.getQtdColetaveisInGame();
        contador.iniciar(qtdColetaveisDoBoard);        
        coletavelImantado = HelperColetaveisInGame.getColetavelInGameByGoName("1");//PEGANDO UM COLETAVEL DEFAULT P EVITAR NULL CHECK    
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
        HelperColetaveisInGame.configurar();
        Coletavel.configurar(coletaveisDto.ReferenciaColliderColetado, coletaveisDto);
    }

    private void configurarGaiolas(ColetaveisDto coletaveisDto)
    {
        Gaiola.configurar(coletaveisDto.GoMainGaiola);
        HelperGaiolasInGame.configurar();
    }

    private void processarColetado(GameObject gameObjectColetado)
    {   
        Coletavel coletavelAcertado = HelperColetaveisInGame.getColetavelInGameByGoName(gameObjectColetado.name);
        coletavelAcertado.desligar();

        int score = contador.contarColetado(coletavelAcertado);

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetadoDto infoColetadoDto = new InformacoesColetadoDto()
            .addInfosDisplayColetados(coletavelAcertado.getSprite(), contador.getResultCombinacao())
            .addInfosDisplayScore(score, contador.getIndiceOrdem())
            .addInfoFimDeJogo(contador.getInfoFimDeJogo());

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
        if (HelperColetaveisInGame.temColetavelInGameByNome(goColetado.name))
        {
            Coletavel coletado = HelperColetaveisInGame.getColetavelInGameByGoName(goColetado.name);            
            if(coletado.isTouchingCentroDaGarra())
            {            
                processarColetado(goColetado.gameObject);
            }
        }
    }
    //IMPLEMENTACAO INTERFACE CONSUMIDORDEEVENTOTRIGGER FIM         

    void AcaoInfoDaGarra.ConsumidorEvento.consumirEvento(InformacoesDaGarraDto evento)
    {
        processarDesimantado();
        if (evento.isImantadoInfo)
        {            
            coletavelImantado = HelperColetaveisInGame.getColetavelInGameByGoName(evento.nomeColetado);
            coletavelImantado.imantar();
        }       
    }   

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
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
            processarColetado(evento.coletavel.getGOColetavel());
        }        
        else if (evento.isFinalizar)
        {
            detectorDeTrigger.ligarTrigger();
        }
    }            
    
    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotadoDto evento)
    {
        if (evento.restart)
        {
            int qtdAtivados = board.subirBoard();
            contador.adicionarColetaveisExtras(qtdAtivados);            
        }        
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        //Debug.Log("Evento acao coletado fim chamado");
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
