using UnityEngine;

public class DisplayTimerDigito 
{
    private bool blink;
    private Vector4 digito;
    private Material materialDisplay;

    public DisplayTimerDigito()
    {
    }

    public void configuradoPeloLevel(Material materialDisplay, SingleDisplayTimerDto sDisplayDto, CorDisplayTimerDto coresDisplay)
    {
        colorirPlaca(sDisplayDto, coresDisplay.CorPlaca);
        sDisplayDto.Segmentos.color = Color.white;

        this.materialDisplay = new Material(materialDisplay);
        this.materialDisplay.SetColor("_cor_desligado", coresDisplay.CorDigito);
        sDisplayDto.Segmentos.sharedMaterial = this.materialDisplay;

        mostrarDigito(0);
    }

    public void mostrarDigito(int digito)
    {   
        this.digito = Digitos7Segmentos.getSegmentosDigito(digito);
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
        ligarPosicoes(Digitos7Segmentos.getSegmentosOff());
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
