using System.Collections;
using UnityEngine;

public class DisplayTimer : AcaoTempoEsgotado.ProdutorEvento,
                            Executor
{  
    private float tempoInicial;
    private bool isPausado;
        
    private ContadorTimer contadorTimer;    
    private DisplayTimerDigitos digitos;

    private Coroutine coroutineBlink;    

    private ProdutorDeEvento<TempoEsgotado> produtorDeEventoTempoEsgotado;

    public DisplayTimer(DisplayTimerDto displayDto)
    {   
        digitos = new DisplayTimerDigitos(displayDto);
        
        produtorDeEventoTempoEsgotado = new ProdutorDeEvento<TempoEsgotado>();
        contadorTimer = new ContadorTimer();        
    }

    public void configuradoPeloLevel(DisplayTimerDto displayDto, AbstractLevel levelEscolhido)
    {
        contadorTimer.definirContador(levelEscolhido.getTempoContagem(), this);        
        digitos.passarCoresAosDisplayDigitos(displayDto, levelEscolhido);        
    }

    public void execute()
    {
        pause();
        produtorDeEventoTempoEsgotado.produziuEvento(new TempoEsgotado(true));
    }

    public void iniciarContagemTempo()
    {
        contadorTimer.iniciarContagemTempo();
    }

    public void update()
    {    
        if(Time.frameCount % 2 == 0 && !isPausado)//Contabilizando tempo a cada 2frames
        {
            atualizarTempo();
            if (contadorTimer.isTimeOver())
            {
                produtorDeEventoTempoEsgotado.produziuEvento(new TempoEsgotado(false));
                Utils.MonoBehaviour.StopCoroutine(coroutineBlink);
                coroutineBlink = null;
            }
        }
    }

    public void pause()
    {
        if (!isPausado)
        {
            isPausado = true;
            contadorTimer.pause();
        }
    }

    public void continuar()
    {
        if (isPausado)
        {
            isPausado = false;
            contadorTimer.continuar();
        }
    }  

    private void atualizarTempo()
    {
        contadorTimer.passarTempoAosScores(digitos);
        if(contadorTimer.isNearTimeOver() && coroutineBlink == null)
        {            
            coroutineBlink = Utils.MonoBehaviour.StartCoroutine(blinkarTimer());         
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

    ProdutorDeEvento<TempoEsgotado> AcaoTempoEsgotado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoTempoEsgotado;
    }    
}
