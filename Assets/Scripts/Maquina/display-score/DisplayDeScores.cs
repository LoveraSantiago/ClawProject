using UnityEngine;
using System.Collections.Generic;

public class DisplayDeScores : ArcoIrisConjunto
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

        MaterialGlow materialGlow = new MaterialGlow(displayDeScoresDto.MaterialGlowDisplay);
        displayCentena = new DisplayScoreDigito(singleDisplays[0], materialGlow);
        displayDezena  = new DisplayScoreDigito(singleDisplays[1], materialGlow);
        displayUnidade = new DisplayScoreDigito(singleDisplays[2], materialGlow);

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
        finalizarCoroutineArcoIris();
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

    private void finalizarCoroutineArcoIris()
    {
        orquestrador.desligarGlows();
    }

    public void ligar()
    {
        displayCentena.ligarGlowSucesso();
        displayDezena.ligarGlowSucesso();
        displayUnidade.ligarGlowSucesso();
    }

    public void desligar()
    {
        displayCentena.desligarGlow();
        displayDezena.desligarGlow();
        displayUnidade.desligarGlow();
    }

    public void passarCor(Color cor)
    {
        displayCentena.getMaterialGlow().setCorNoMaterial(cor);
    }
}
