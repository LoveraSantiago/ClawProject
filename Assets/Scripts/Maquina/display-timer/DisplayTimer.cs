using System.Collections;
using UnityEngine;

public class DisplayTimer : AcaoTempoEsgotado.ProdutorEvento,
                            AcaoColetado.ConsumidorEvento,
                            AcaoColetadoFim.ConsumidorEvento,
                            Executor
{  
    private float tempoInicial;
    private bool isPausado;
        
    private ContadorTimer contadorTimer;    
    private DisplayTimerDigitos digitos;

    private Coroutine coroutineBlink;    

    private ProdutorDeEvento<TempoEsgotadoDto> produtorDeEventoTempoEsgotado;

    public DisplayTimer(DisplayTimerDto displayDto)
    {   
        digitos = new DisplayTimerDigitos(displayDto);
        
        produtorDeEventoTempoEsgotado = new ProdutorDeEvento<TempoEsgotadoDto>();
        contadorTimer = new ContadorTimer();        
    }

    public void configuradoPeloLevel(DisplayTimerDto displayDto, Materiais7SegmentosDto materiais7SegsDto, AbstractLevel levelEscolhido)
    {
        contadorTimer.definirContador(levelEscolhido.getTempoContagem(), this);        
        digitos.passarCoresAosDisplayDigitos(displayDto, materiais7SegsDto, levelEscolhido);        
    }

    public void execute()
    {
        pause();
        produtorDeEventoTempoEsgotado.produziuEvento(new TempoEsgotadoDto(true));
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
                produtorDeEventoTempoEsgotado.produziuEvento(new TempoEsgotadoDto(false));
                ContextoEstaticoUtils.MonoBehaviour.StopCoroutine(coroutineBlink);
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
            coroutineBlink = ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(blinkarTimer());         
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

    ProdutorDeEvento<TempoEsgotadoDto> AcaoTempoEsgotado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoTempoEsgotado;
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        continuar();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        pause();
    }
}
