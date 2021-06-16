using UnityEngine;
using System.Collections.Generic;

public class DisplayDeScores 
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
    private Coroutine coroutineArcoIris;

    public DisplayDeScores(DisplayDeScoreDto displayDeScoresDto, MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;

        SingleDisplayScoreDto[] singleDisplays = displayDeScoresDto.SingleDisplayScoreDto;        
        displayCentena = new DisplayScoreDigito(singleDisplays[0], displayDeScoresDto.MaterialGlowDisplay);
        displayDezena  = new DisplayScoreDigito(singleDisplays[1], displayDeScoresDto.MaterialGlowDisplay);
        displayUnidade = new DisplayScoreDigito(singleDisplays[2], displayDeScoresDto.MaterialGlowDisplay);

        orquestrador = new OrquestradorDisplayDigitos(displayDeScoresDto, displayCentena, displayDezena, displayUnidade);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        string hexCor = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_SCORES1];
        string hexLed = dicionarioDeCores[ConstantesCoresMaquina.LEDS1];
        displayCentena.configuradoPeloLevel(hexCor, hexLed);

        hexCor = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_SCORES2];
        hexLed = dicionarioDeCores[ConstantesCoresMaquina.LEDS2];
        displayDezena.configuradoPeloLevel(hexCor, hexLed);

        hexCor = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_SCORES3];
        hexLed = dicionarioDeCores[ConstantesCoresMaquina.LEDS3];
        displayUnidade.configuradoPeloLevel(hexCor, hexLed);
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
        //Debug.Log("PiscarAstericos");
        finalizarCoroutineAtual();
        coroutineAtual = monoBehaviour.StartCoroutine(orquestrador.blinkarAsteriscos());
    }

    public void finalizarContagemRegressiva()
    {
        finalizarCoroutineAtual();
        finalizarCoroutineArcoIris();
        orquestrador.passarScore(scoreCentenaAtual, scoreDezenaAtual, scoreUnidadeAtual);
    }

    public void iniciarContagemRegressiva(int duracao)
    {
        armazenarScoreAtual();
        coroutineAtual = monoBehaviour.StartCoroutine(orquestrador.mostrarContagemRegressivo(duracao));
        orquestrador.ligarGlows();
        coroutineArcoIris = monoBehaviour.StartCoroutine(orquestrador.ligarGlowArcoIris());
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
        monoBehaviour.StopCoroutine(coroutineAtual);        
    }    

    private void finalizarCoroutineArcoIris()
    {
        orquestrador.desligarGlows();
        monoBehaviour.StopCoroutine(coroutineArcoIris);
    }
}
