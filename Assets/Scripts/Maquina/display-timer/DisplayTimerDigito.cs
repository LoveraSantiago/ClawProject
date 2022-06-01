using UnityEngine;

public class DisplayTimerDigito 
{
    private bool blink;
    private int digitoAtual;
    private Material7Digitos material7Digitos;

    public void configuradoPeloLevel(Material materialDisplay, SingleDisplayTimerDto sDisplayDto, CorDisplayTimerDto coresDisplay)
    {
        colorirPlaca(sDisplayDto, coresDisplay.CorPlaca);
        sDisplayDto.Segmentos.color = Color.white;

        material7Digitos = new Material7Digitos(materialDisplay);
        material7Digitos.addCorDesligado(coresDisplay.CorDigito);        
        sDisplayDto.Segmentos.sharedMaterial = material7Digitos.material;

        mostrarDigito(0);
    }

    public void mostrarDigito(int digito)
    {
        digitoAtual = digito;
        if (!blink)
        {
            ligarPosicoes(digito);
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
            ligarPosicoes(digitoAtual);
        }
    }

    private void desligarPosicoes()
    {
        material7Digitos.desligarDigitos();
    }

    private void ligarPosicoes(int digito)
    {
        material7Digitos.addDigito(digito);        
    }  

    private void colorirPlaca(SingleDisplayTimerDto sDisplayDto, Color corPlaca)
    {
        if (sDisplayDto.PlacaIndividual != null)
        {
            sDisplayDto.PlacaIndividual.color = corPlaca;
        }
    }
}
