using UnityEngine;

public class DisplayTimerDigito 
{    
    private int[] arrayLigado;

    private Color corOriginal;
    
    private SingleDisplayTimerDto sDisplayDto;

    public DisplayTimerDigito(SingleDisplayTimerDto sDisplayDto)
    {
        this.sDisplayDto = sDisplayDto;
        corOriginal = sDisplayDto.Segmentos[0].color;
        mostrarDigito(0);
    }

    public void mostrarDigito(int digito)
    {
        desligarPosicoes(arrayLigado);

        arrayLigado = getArrayParaLigar(digito);
        ligarPosicoes(arrayLigado);
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

    private int[] getArrayParaLigar(int digito)
    {
        switch (digito)
        {
            case 0: return ARRAY_ZERO;
            case 1: return ARRAY_HUM;
            case 2: return ARRAY_DOIS;
            case 3: return ARRAY_TRES;
            case 4: return ARRAY_QUATRO;
            case 5: return ARRAY_CINCO;
            case 6: return ARRAY_SEIS;
            case 7: return ARRAY_SETE;
            case 8: return ARRAY_OITO;
            case 9: return ARRAY_NOVE;
        }
        return ARRAY_ZERO;
    }

    private static int[] ARRAY_ZERO   = new int[] { 0, 1, 2, 3, 4, 5};
    private static int[] ARRAY_HUM    = new int[] { 1, 2};
    private static int[] ARRAY_DOIS   = new int[] { 0, 1, 3, 4, 6 };
    private static int[] ARRAY_TRES   = new int[] { 0, 1, 2, 3, 6 };
    private static int[] ARRAY_QUATRO = new int[] { 1, 2, 5, 6};
    private static int[] ARRAY_CINCO  = new int[] { 0, 2, 3, 5, 6 };
    private static int[] ARRAY_SEIS   = new int[] { 0, 2, 3, 4 ,5 , 6 };
    private static int[] ARRAY_SETE   = new int[] { 0, 1, 2 };
    private static int[] ARRAY_OITO   = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    private static int[] ARRAY_NOVE   = new int[] { 0, 1, 2, 5, 6 };
}
