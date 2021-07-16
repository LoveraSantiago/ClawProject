using System.Collections;
using UnityEngine;

public class DisplayTimer
{  
    private float tempoInicial;    
        
    private ContadorTimer contadorTimer;    
    private DisplayTimerGlow glowDisplay;
    
    private DisplayTimerDigitos digitos;

    private Coroutine coroutineBlink;
    private MonoBehaviour monoBehaviour;

    public ProdutorDeEvento<bool> produtorDeEventoTempoEsgotado { get; private set; }

    public DisplayTimer(DisplayTimerDto displayDto, MonoBehaviour monoBehaviour)
    {   
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
        if(Time.frameCount % 2 == 0)//Contabilizando tempo a cada 5frames
        {
            atualizarTempo();
            if (contadorTimer.isTimeOver())
            {
                produtorDeEventoTempoEsgotado.produziuEvento(true);
                monoBehaviour.StopCoroutine(coroutineBlink);
                coroutineBlink = null;
            }
        }
    }

    private void atualizarTempo()
    {
        contadorTimer.passarTempoAosScores(digitos);
        if(contadorTimer.isNearTimeOver() && coroutineBlink == null)
        {            
            coroutineBlink = monoBehaviour.StartCoroutine(blinkarTimer());         
        }
    }

    private IEnumerator blinkarTimer()
    {
        while (contadorTimer.isNearTimeOver())
        {
            digitos.blinkar(true);
            yield return new WaitForSeconds(0.25f);
            digitos.blinkar(false);
            yield return new WaitForSeconds(0.25f);
        }
        yield return null;
    }

    public ArcoIrisConjunto getDisplayTimerGlow()
    {
        return glowDisplay;
    }
}
