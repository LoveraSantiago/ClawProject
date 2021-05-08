using UnityEngine;

public class DisplayDeScores : ConsumidorDeEvento<PowerUpInfo>
{
    private int scoreCentenaAtual;
    private int scoreDezenaAtual;
    private int scoreUnidadeAtual;

    private DisplayScoreDigito displayCentena;
    private DisplayScoreDigito displayDezena;
    private DisplayScoreDigito displayUnidade;

    private OrquestradorDisplayDigitos orquestrador;
    private MonoBehaviour monoBehaviour;

    private Coroutine coroutineAtual;    

    public DisplayDeScores(DisplayDeScoreDto displayDeScoresDto, MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;

        GameObject[] displayScores = displayDeScoresDto.GosDisplayScores;
        displayCentena = new DisplayScoreDigito(displayScores[0]);
        displayDezena  = new DisplayScoreDigito(displayScores[1]);
        displayUnidade = new DisplayScoreDigito(displayScores[2]);

        orquestrador = new OrquestradorDisplayDigitos(displayDeScoresDto, displayCentena, displayDezena, displayUnidade);
    }
    
    public void mostrarScore(int score, bool result)
    {
        splitarScore(score);
        if (result)
        {
            monoBehaviour.StartCoroutine(orquestrador.blinkarScoreSucesso(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual));
        }
        else
        {
            monoBehaviour.StartCoroutine(orquestrador.blinkarScore(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual));
        }
    }

    public void piscarAsteriscos()
    {
        Debug.Log("PiscarAstericos");
        cancelarCoroutine();
        coroutineAtual = monoBehaviour.StartCoroutine(orquestrador.blinkarAsteriscos());
    }

    public void mostrarPontuacaoAcumulada()
    {
        cancelarCoroutine();
        orquestrador.passarScore(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual);
    }

    private void mostrarContagemRegressiva(int duracao)
    {
        armazenarScoreAtual();
        coroutineAtual = monoBehaviour.StartCoroutine(orquestrador.mostrarContagemRegressivo(duracao));
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
    
    private void cancelarCoroutine()
    {
        monoBehaviour.StopCoroutine(coroutineAtual);        
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> INICIO
    public void consumirEvento(PowerUpInfo evento)
    {
        mostrarContagemRegressiva(evento.duracaoTempo);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> INICIO   

    public ConsumidorDeEvento<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return this;
    }
}
