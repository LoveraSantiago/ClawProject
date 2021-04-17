using UnityEngine;

public class DisplayDeScores : ConsumidorDeEvento<PowerUpInfo>
{ 
    private DisplayDigito displayCentena;
    private DisplayDigito displayDezena;
    private DisplayDigito displayUnidade;

    //private DisplayDeScoreDto displayDeScoresDto;
    private OrquestradorDisplayDigitos orquestrador;
    private MonoBehaviour monoBehaviour;

    public DisplayDeScores(DisplayDeScoreDto displayDeScoresDto, MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
        //this.displayDeScoresDto = displayDeScoresDto;

        GameObject[] displayScores = displayDeScoresDto.GosDisplayScores;
        displayCentena = new DisplayDigito(displayScores[0]);
        displayDezena = new DisplayDigito(displayScores[1]);
        displayUnidade = new DisplayDigito(displayScores[2]);

        orquestrador = new OrquestradorDisplayDigitos(displayDeScoresDto, displayCentena, displayDezena, displayUnidade);
    }
   
    public void mostrarScore(int score, bool result)
    {
        int scoreTotal = score;
        int centena = scoreTotal / 100;

        scoreTotal -= centena * 100;
        int dezena =scoreTotal / 10;

        scoreTotal -= dezena * 10;
        int unidade = scoreTotal;
        if (result)
        {
            monoBehaviour.StartCoroutine(orquestrador.blinkarScoreSucesso(centena, dezena, unidade));
        }
        else
        {
            monoBehaviour.StartCoroutine(orquestrador.blinkarScore(centena, dezena, unidade));
        }
    }

    private void mostrarContagemRegressiva(int duracao)
    {
        int scoreCentena = displayCentena.digito;
        int scoreDezena = displayDezena.digito;
        int scoreUnidade = displayUnidade.digito;

        monoBehaviour.StartCoroutine(orquestrador.mostrarContagemRegressivo(duracao, scoreCentena, scoreDezena, scoreUnidade));
    }     
    
    public void finalizarContatemRegressiva()
    {
        orquestrador.finalizarContatemRegressiva();
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
