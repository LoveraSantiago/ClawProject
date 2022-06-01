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

    public DisplayDeScores(DisplayDeScoreDto displayDeScoresDto)
    {        
        SingleDisplayScoreDto[] singleDisplays = displayDeScoresDto.SingleDisplayScoreDto;        
        displayCentena = new DisplayScoreDigito(singleDisplays[0]);
        displayDezena  = new DisplayScoreDigito(singleDisplays[1]);
        displayUnidade = new DisplayScoreDigito(singleDisplays[2]);

        orquestrador = new OrquestradorDisplayDigitos(displayDeScoresDto, displayCentena, displayDezena, displayUnidade);
    }

    public void configuradoPeloLevel(DisplayDeScoreDto displayDeScoresDto, AbstractLevel levelEscolhido)
    {
        ConfiguradorDeDisplayScoreDigito configuradorDisplayDigito = new ConfiguradorDeDisplayScoreDigito(displayCentena, displayDezena, displayUnidade);
        configuradorDisplayDigito.configurar(displayDeScoresDto, levelEscolhido);
    }
    
    public void mostrarScore(int score, bool result)
    {
        splitarScore(score);
        if (result)
        {
            Utils.MonoBehaviour.StartCoroutine(orquestrador.blinkarScoreSucesso(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual));
        }
        else
        {
            Utils.MonoBehaviour.StartCoroutine(orquestrador.blinkarScore(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual));
        }
    }

    public void piscarAsteriscos()
    {
        //Debug.Log("PiscarAstericos");
        finalizarCoroutineAtual();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(orquestrador.blinkarAsteriscos());
    }

    public void finalizarContagemRegressiva()
    {
        finalizarCoroutineAtual();        
        orquestrador.passarScore(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual);
    }

    public void iniciarContagemRegressiva(int duracao)
    {
        armazenarScoreAtual();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(orquestrador.mostrarContagemRegressivo(duracao));                
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
        Utils.MonoBehaviour.StopCoroutine(coroutineAtual);        
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {   
        mostrarScore(evento.score, evento.resultCombinacao);
    }
}
