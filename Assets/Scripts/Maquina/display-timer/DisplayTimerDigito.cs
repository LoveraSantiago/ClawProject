using UnityEngine;

public class DisplayTimerDigito 
{
    private static SegmentosTimer segmentos = new SegmentosTimer();

    private bool blink;
    private Vector4 digito;
    private Material materialDisplay;

    public DisplayTimerDigito(Material materialDisplay)
    {
        this.materialDisplay = new Material(materialDisplay);
    }

    public void configuradoPeloLevel(SingleDisplayTimerDto sDisplayDto, Color corDigito, Color corPlaca)
    {
        colorirPlaca(sDisplayDto, corPlaca);
        sDisplayDto.Segmentos.color = Color.white;
        materialDisplay.SetColor("_cor_desligado", corDigito);
        sDisplayDto.Segmentos.sharedMaterial = materialDisplay;
        mostrarDigito(0);
    }

    public void mostrarDigito(int digito)
    {   
        this.digito = segmentos.getSegmentosDigito(digito);
        if (!blink)
        {
            ligarPosicoes(this.digito);
        }
    }    

    public void estadoBlink(bool blink)
    {
        this.blink = blink;
        if (blink)
        {
            desligarPosicoes();
        }
        else
        {
            ligarPosicoes(digito);
        }
    }

    private void desligarPosicoes()
    {
        ligarPosicoes(segmentos.getSegmentosOff());
    }

    private void ligarPosicoes(Vector4 digito)
    {
        materialDisplay.SetVector("_digitos", digito);        
    }  

    private void colorirPlaca(SingleDisplayTimerDto sDisplayDto, Color corPlaca)
    {
        if (sDisplayDto.PlacaIndividual != null)
        {
            sDisplayDto.PlacaIndividual.color = corPlaca;
        }
    }
}
