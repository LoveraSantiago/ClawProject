using UnityEngine;

public class DisplayDeScores : ConsumidorDeEvento<InformacoesColetado>,
                               ConsumidorDeEvento<PowerUp>
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
   
    private void mostrarScore(int score, bool result)
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

    private void mostrarContagemRegressiva()
    {
        int scoreCentena = displayCentena.digito;
        int scoreDezena = displayDezena.digito;
        int scoreUnidade = displayUnidade.digito;
    }

    private void processarPowerUp(PowerUp powerUp)
    {
        if (powerUp.tipo == PowerUp.TIPO.BOMBA_DA_GARRA)
        {
            mostrarContagemRegressiva();
        }
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> INICIO
    //CONSOME EVENTO DISPARADO PELO COLETAVEIS MANAGER AO COLETAR UM COLETAVEL
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        mostrarScore(infoColetado.score, infoColetado.resultCombinacao);        
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUp> INICIO
    public void consumirEvento(PowerUp evento)
    {
        
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUp> INICIO

    public ConsumidorDeEvento<InformacoesColetado> getDisplayScoreConsumidor()
    {
        return this;
    }

    public ConsumidorDeEvento<PowerUp> getConsumidorDePowerUp()
    {
        return this;
    }
}
