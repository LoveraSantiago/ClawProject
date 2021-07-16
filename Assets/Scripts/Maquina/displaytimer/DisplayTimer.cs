using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTimer
{    
    private int segundosUnidadeAtual;
    private int segundosDezenaAtual;
    private int minutosUnidadeAtual;
    private int minutosDezenaAtual;

    private float tempoInicial;    
    
    private SpriteRenderer placaTimer;
    private DisplayTimerGlow glowDisplay;
    private DisplayTimerDigito[] displayTimerDigito;
    private DisplayTimerDigito2Pontos displayTimer2Pontos;

    private Coroutine coroutineBlink;
    private MonoBehaviour monoBehaviour;

    private ContadorTimer contadorTimer;
    public ProdutorDeEvento<bool> produtorDeEventoTempoEsgotado { get; private set; }

    public DisplayTimer(DisplayTimerDto displayDto, MonoBehaviour monoBehaviour)
    {
        placaTimer = displayDto.SprRendererPlaca;
        displayTimer2Pontos = new DisplayTimerDigito2Pontos(displayDto.SingleDisplay[4]);

        displayTimerDigito = new DisplayTimerDigito[4];
        displayTimerDigito[0] = new DisplayTimerDigito(displayDto.SingleDisplay[0]);
        displayTimerDigito[1] = new DisplayTimerDigito(displayDto.SingleDisplay[1]);
        displayTimerDigito[2] = new DisplayTimerDigito(displayDto.SingleDisplay[2]);
        displayTimerDigito[3] = new DisplayTimerDigito(displayDto.SingleDisplay[3]);        
        
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

        Dictionary<string, string> dicionarioDeCores = levelEscolhido.getDicionarioDeCores();
        string corTimerHex = dicionarioDeCores[ConstantesCoresMaquina.DISPLAY_TIMER];
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquina.DIGITOS_TIMERS];

        placaTimer.color = Utils.getCorByHex(corTimerHex);
        
        Color corDigito = Utils.getCorByHex(corDigitosHex);
        displayTimerDigito[0].configuraradoPeloLevel(corDigito);
        displayTimerDigito[1].configuraradoPeloLevel(corDigito);
        displayTimerDigito[2].configuraradoPeloLevel(corDigito);
        displayTimerDigito[3].configuraradoPeloLevel(corDigito);
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

        if (unidadeSegundos == segundosUnidadeAtual) return;
        segundosUnidadeAtual = unidadeSegundos;
        displayTimerDigito[3].mostrarDigito(unidadeSegundos);

        if (dezenaSegundos == segundosDezenaAtual) return;
        segundosDezenaAtual = dezenaSegundos;
        displayTimerDigito[2].mostrarDigito(dezenaSegundos);

        double minutos = timeSpan.Minutes;
        int dezenaMinutos = (int) (minutos / 10);
        int unidadeMinutos = (int) (minutos - (dezenaMinutos * 10));

        if (unidadeMinutos == minutosUnidadeAtual) return;
        minutosUnidadeAtual = unidadeMinutos;
        displayTimerDigito[1].mostrarDigito(unidadeMinutos);

        if (dezenaMinutos == minutosDezenaAtual) return;
        minutosDezenaAtual = dezenaMinutos;
        displayTimerDigito[0].mostrarDigito(dezenaMinutos);
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
