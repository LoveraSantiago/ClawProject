using UnityEngine;

public class DisplayTimerDigito 
{    
    private static SegmentosTimer segmentos = new SegmentosTimer();

    private int[] arrayLigado;
    private bool blink;
    private Color corOriginal;

    private SingleDisplayTimerDto sDisplayDto;

    public DisplayTimerDigito(SingleDisplayTimerDto sDisplayDto)
    {
        this.sDisplayDto = sDisplayDto;
    }

    public void configuradoPeloLevel(Color corDigito)
    {
        corOriginal = corDigito;        
        for(int contador = 0; contador < sDisplayDto.Segmentos.Length; contador++)
        {
            sDisplayDto.Segmentos[contador].color = corDigito;
        }
        mostrarDigito(0);
    }

    public void mostrarDigito(int digito)
    {
        desligarPosicoes(arrayLigado);

        arrayLigado = segmentos.getArrayParaLigar(digito);
        if (!blink)
        {
            ligarPosicoes(arrayLigado);
        }
    }

    public void estadoBlink(bool blink)
    {
        this.blink = blink;
        if (blink)
        {
            desligarPosicoes(arrayLigado);
        }
        else
        {
            ligarPosicoes(arrayLigado);
        }
    }

    private void desligarPosicoes(int[] array)
    {
        if (array == null) return;
        for (int contador = 0; contador < array.Length; contador++)
        {
            sDisplayDto.Segmentos[array[contador]].color = corOriginal;
        }
    }

    private void ligarPosicoes(int[] array)
    {
        for (int contador = 0; contador < array.Length; contador++)
        {
            sDisplayDto.Segmentos[array[contador]].color = Color.red; 
        }
    }   
}
