using System;

public class ContadorTimer 
{
    public enum Contagem { NORMAL, REGRESSIVA, CONTINUA };
    private TipoContadorTimer tipoContadorTimer;

    public void definirContador(
        TipoContagemTempoDto tipoContagemTempo, ProdutorDeEvento<TempoEsgotado> produtorDeEventoTempoEsgotado, Executor executorTimerRestart)
    {
        switch (tipoContagemTempo.contagem)
        {
            case Contagem.NORMAL:
            {
                tipoContadorTimer = new ContadorTimerPositivo();
                break;
            }
            case Contagem.REGRESSIVA:
            {
                tipoContadorTimer = new ContadorTimerNegativo(tipoContagemTempo.tempo);
                break;
            }
            case Contagem.CONTINUA:
            {
                tipoContadorTimer = new ContadorTimerContinuo(
                    tipoContagemTempo.tempo, produtorDeEventoTempoEsgotado, executorTimerRestart);
                break;
            }
        }        
    }

    public void iniciarContagemTempo()
    {
        tipoContadorTimer.iniciarContagem();
    }

    public void pause()
    {
        tipoContadorTimer.pause();
    }

    public void continuar()
    {
        tipoContadorTimer.continuar();
    }

    public bool isTimeOver()
    {
        return tipoContadorTimer.isTimeOver();
    }

    public bool isNearTimeOver()
    {
        return tipoContadorTimer.isNearTimeOver();
    }

    public void passarTempoAosScores(DisplayTimerDigitos digitos)
    {
        TimeSpan timeSpan = tipoContadorTimer.processarContagem();

        double segundos = timeSpan.Seconds;
        int dezenaSegundos = (int)(segundos / 10);
        int unidadeSegundos = (int)(segundos - (dezenaSegundos * 10));

        if (unidadeSegundos == digitos.segundosUnidadeAtual) return;
        digitos.setSegundosUnidade(unidadeSegundos);

        if (dezenaSegundos == digitos.segundosDezenaAtual) return;
        digitos.setSegundosDezena(dezenaSegundos);

        double minutos = timeSpan.Minutes;
        int dezenaMinutos = (int)(minutos / 10);
        int unidadeMinutos = (int)(minutos - (dezenaMinutos * 10));

        if (unidadeMinutos == digitos.minutosUnidadeAtual) return;
        digitos.setMinutosUnidade(unidadeMinutos);

        if (dezenaMinutos == digitos.minutosDezenaAtual) return;
        digitos.setMinutosDezena(dezenaMinutos);
    }   
}
