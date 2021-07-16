using System.Collections;
using UnityEngine;

public class DisplayTimer
{  
    private float tempoInicial;    
        
    private ContadorTimer contadorTimer;    
    private DisplayTimerGlow glowDisplay;
    private DisplayTimerDigito2Pontos displayTimer2Pontos;
    private DisplayTimerDigitos digitos;

    private Coroutine coroutineBlink;
    private MonoBehaviour monoBehaviour;

    public ProdutorDeEvento<bool> produtorDeEventoTempoEsgotado { get; private set; }

    public DisplayTimer(DisplayTimerDto displayDto, MonoBehaviour monoBehaviour)
    {
        
        displayTimer2Pontos = new DisplayTimerDigito2Pontos(displayDto.SingleDisplay[4]);
        digitos = new DisplayTimerDigitos(displayDto);
        
        produtorDeEventoTempoEsgotado = new ProdutorDeEvento<bool>();
        glowDisplay = new DisplayTimerGlow(displayDto);
        contadorTimer = new ContadorTimer();
        this.monoBehaviour = monoBehaviour;
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        contadorTimer.definirContador(levelEscolhido.isTempoContagemNormal(), levelEscolhido.getTempoContagem());        
        digitos.passarCoresAosDisplayDigitos(levelEscolhido.getDicionarioDeCores());        
    }

    public void iniciarContagemTempo()
    {
        contadorTimer.iniciarContagemTempo();
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
        contadorTimer.passarTempoAosScores(digitos);
        if(contadorTimer.isNearTimeOver() && !glowDisplay.getEstadoBlink())
        {
            glowDisplay.ativarBlink();
            coroutineBlink = monoBehaviour.StartCoroutine(blinkarTimer());
            glowDisplay.ligarGlowFail();
        }
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
