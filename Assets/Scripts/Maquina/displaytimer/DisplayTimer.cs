using System;
using System.Collections;
using UnityEngine;

public class DisplayTimer
{  
    private float tempoInicial;    
        
    private DisplayTimerGlow glowDisplay;
    private DisplayTimerDigito2Pontos displayTimer2Pontos;
    private DisplayTimerDigitos digitos;

    private Coroutine coroutineBlink;
    private MonoBehaviour monoBehaviour;

    private ContadorTimer contadorTimer;
    public ProdutorDeEvento<bool> produtorDeEventoTempoEsgotado { get; private set; }

    public DisplayTimer(DisplayTimerDto displayDto, MonoBehaviour monoBehaviour)
    {
        
        displayTimer2Pontos = new DisplayTimerDigito2Pontos(displayDto.SingleDisplay[4]);

        digitos = new DisplayTimerDigitos(displayDto);
        
        produtorDeEventoTempoEsgotado = new ProdutorDeEvento<bool>();
        glowDisplay = new DisplayTimerGlow(displayDto);        
        this.monoBehaviour = monoBehaviour;
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        if (levelEscolhido.isTempoContagemNormal())
        {
            contadorTimer = new ContadorTimerPositivo();
        }
        else
        {
            contadorTimer = new ContadorTimerNegativo(levelEscolhido.getTempoContagem());
        }
        digitos.passarCoresAosDisplayDigitos(levelEscolhido.getDicionarioDeCores());        
    }

    public void iniciarContagemTempo()
    {
        contadorTimer.iniciarContagem();
    }

    public void update()
    {    
        if(Time.frameCount % 5 == 0)//Contabilizando tempo a cada 5frames
        {
            atualizarTempo();
            if (contadorTimer.isTimeOver())
            {
                produtorDeEventoTempoEsgotado.produziuEvento(true);
                monoBehaviour.StopCoroutine(coroutineBlink);
            }
        }
    }

    private void atualizarTempo()
    {
        passarTempoAosScores();
        if(contadorTimer.isNearTimeOver() && !glowDisplay.getEstadoBlink())
        {
            glowDisplay.ativarBlink();
            coroutineBlink = monoBehaviour.StartCoroutine(blinkarTimer());
            glowDisplay.ligarGlowFail();
        }
    }

    private void passarTempoAosScores()
    {
        TimeSpan timeSpan = contadorTimer.processarContagem();

        double segundos = timeSpan.Seconds;
        int dezenaSegundos = (int)(segundos / 10);
        int unidadeSegundos = (int)(segundos - (dezenaSegundos * 10));

        if (unidadeSegundos == digitos.segundosUnidadeAtual) return;
        digitos.setSegundosUnidade(unidadeSegundos);        

        if (dezenaSegundos == digitos.segundosDezenaAtual) return;
        digitos.setSegundosDezena(dezenaSegundos);        

        double minutos = timeSpan.Minutes;
        int dezenaMinutos = (int) (minutos / 10);
        int unidadeMinutos = (int) (minutos - (dezenaMinutos * 10));

        if (unidadeMinutos == digitos.minutosUnidadeAtual) return;
        digitos.setMinutosUnidade(unidadeMinutos);        

        if (dezenaMinutos == digitos.minutosDezenaAtual) return;
        digitos.setMinutosDezena(dezenaMinutos);        
    }

    private IEnumerator blinkarTimer()
    {
        while (contadorTimer.isNearTimeOver())
        {
            glowDisplay.ligarGlowFail();
            yield return new WaitForSeconds(0.5f);
            glowDisplay.desligarGlow();
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    public ArcoIrisConjunto getDisplayTimerGlow()
    {
        return glowDisplay;
    }
}
