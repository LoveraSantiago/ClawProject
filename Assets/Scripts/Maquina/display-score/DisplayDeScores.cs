using UnityEngine;

public class DisplayDeScores : AcaoColetado.ConsumidorEvento
{
    private int scoreCentenaAtual;
    private int scoreDezenaAtual;
    private int scoreUnidadeAtual;

    private DisplayScoreDigito displayCentena;
    private DisplayScoreDigito displayDezena;
    private DisplayScoreDigito displayUnidade;

    private OrquestradorDisplayDigitos orquestrador;
    private Coroutine coroutineAtual;
    private SomMaquina somMaquina;

    public DisplayDeScores(DisplayDeScoreDto displayDeScoresDto, SomMaquina somMaquina)
    {        
        SingleDisplayScoreDto[] singleDisplays = displayDeScoresDto.SingleDisplayScoreDto;        
        displayCentena = new DisplayScoreDigito(singleDisplays[0]);
        displayDezena  = new DisplayScoreDigito(singleDisplays[1]);
        displayUnidade = new DisplayScoreDigito(singleDisplays[2]);

        orquestrador = new OrquestradorDisplayDigitos(displayDeScoresDto, displayCentena, displayDezena, displayUnidade);
        this.somMaquina = somMaquina;
    }

    public void configuradoPeloLevel(DisplayDeScoreDto displayDeScoresDto)
    {
        ConfiguradorDeDisplayScoreDigito configuradorDisplayDigito = new ConfiguradorDeDisplayScoreDigito(displayCentena, displayDezena, displayUnidade);
        configuradorDisplayDigito.configurar(displayDeScoresDto);
    }
    
    private void mostrarScore(int score, bool result)
    {
        splitarScore(score);
        if (result)
        {            
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                orquestrador.blinkarScoreSucesso(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual, somMaquina));
        }
        else
        {         
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(
                orquestrador.blinkarScore(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual, somMaquina));
        }
    }

    public void piscarAsteriscos()
    {
        //Debug.Log("PiscarAstericos");
        finalizarCoroutineAtual();
        coroutineAtual = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(orquestrador.blinkarAsteriscos());
    }

    public void finalizarContagemRegressiva()
    {
        somMaquina.stopSomMaqAlarmePowerUp();
        finalizarCoroutineAtual();        
        orquestrador.passarScore(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual);
    }

    public void iniciarContagemRegressiva(int duracao)
    {
        armazenarScoreAtual();
        somMaquina.playSomMaqAlarmePowerUp();
        coroutineAtual = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(orquestrador.mostrarContagemRegressivo(duracao));                
    }     

    private void splitarScore(int score)
    {
        int scoreTotal = score;
        scoreCentenaAtual = scoreTotal / 100;

        scoreTotal -= scoreCentenaAtual * 100;
        scoreDezenaAtual = scoreTotal / 10;

        scoreTotal -= scoreDezenaAtual * 10;
        scoreUnidadeAtual = scoreTotal;
    }

    private void armazenarScoreAtual()
    {
        scoreCentenaAtual = displayCentena.digito;
        scoreDezenaAtual  = displayDezena.digito;
        scoreUnidadeAtual = displayUnidade.digito;
    }
    
    private void finalizarCoroutineAtual()
    {
        ContextoEstaticoUtils.monoBehaviour.StopCoroutine(coroutineAtual);        
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {   
        mostrarScore(evento.score, evento.resultCombinacao);
    }
}
