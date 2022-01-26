using System;

public class ContadorTimer 
{
    public enum Contagem { NORMAL, REGRESSIVA, CONTINUA };
    private ContadorDeTempo contadorDeTempo;

    public void definirContador(TipoContagemTempoDto tipoContagemTempo, Executor executorTimerRestart)
    {
        switch (tipoContagemTempo.contagem)
        {
            case Contagem.NORMAL:
            {
                contadorDeTempo = new ContadorDeTempoFramePositivo();
                break;
            }
            case Contagem.REGRESSIVA:
            {
                contadorDeTempo = new ContadorDeTempoFrameNegativo(tipoContagemTempo.tempo);
                break;
            }
            case Contagem.CONTINUA:
            {
                contadorDeTempo = new ContadorTimerContinuo(tipoContagemTempo.tempo, executorTimerRestart);
                break;
            }
        }        
    }

    public void iniciarContagemTempo()
    {
        contadorDeTempo.iniciarContagem();
    }

    public void pause()
    {
        contadorDeTempo.pause();
    }

    public void continuar()
    {
        contadorDeTempo.continuar();
    }

    public bool isTimeOver()
    {
        return contadorDeTempo.isTimeOver();
    }

    public bool isNearTimeOver()
    {
        return contadorDeTempo.isNearTimeOver();
    }

    public void passarTempoAosScores(DisplayTimerDigitos digitos)
    {
        TimeSpan timeSpan = contadorDeTempo.processarContagem();

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
