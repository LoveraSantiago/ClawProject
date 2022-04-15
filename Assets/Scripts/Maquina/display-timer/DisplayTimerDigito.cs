using UnityEngine;

public class DisplayTimerDigito 
{
    private static SegmentosTimer segmentos = new SegmentosTimer();
    //private static SegmentoTimerHdr segmentHdr;

    private int[] arrayLigado;
    private bool blink;
    private Color corOriginal;

    private SingleDisplayTimerDto sDisplayDto;

    public DisplayTimerDigito(SingleDisplayTimerDto sDisplayDto)
    {
        this.sDisplayDto = sDisplayDto;
    }

    public void configuradoPeloLevel(Color corDigito, Color corPlaca)
    {
        corOriginal = corDigito;
        colorirPlaca(corPlaca);
        sDisplayDto.Segmentos.color = corOriginal;        
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
            //SpriteRenderer sprRenderer = sDisplayDto.Segmentos[array[contador]];
            //sprRenderer.color = corOriginal;
            //sprRenderer.material = segmentHdr.originalMaterial;
        }
    }

    private void ligarPosicoes(int[] array)
    {
        for (int contador = 0; contador < array.Length; contador++)
        {
            //SpriteRenderer sprRenderer = sDisplayDto.Segmentos[array[contador]];
            //sprRenderer.color = Color.red;
            //sprRenderer.material = segmentHdr.getMaterialSegmento(array[contador]);
        }
    }  

    private void colorirPlaca(Color corPlaca)
    {
        if (sDisplayDto.PlacaIndividual != null)
        {
            sDisplayDto.PlacaIndividual.color = corPlaca;
        }
    }

    //public static void configurar(DisplayTimerDto displayTimerDto)
    //{
    //    segmentos = new SegmentosTimer();
    //    //segmentHdr = new SegmentoTimerHdr(displayTimerDto);
    //}
}
