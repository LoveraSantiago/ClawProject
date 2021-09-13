public class ColetadoFim 
{
    public bool[] clear;   

    public ColetadoFim(bool[] clears)        
    {
        this.clear = clears;
    }

    public bool devolverBoard()
    {
        return clear[0] && clear[1] && clear[2];
    }

    public bool reajustarContador()
    {
        int contadorClear = 0;
        if (clear[0]) contadorClear++;
        if (clear[1]) contadorClear++;
        if (clear[2]) contadorClear++;

        return contadorClear == 1;
    }

    public int getPrimeiroIndiceParaLimpar()
    {
        if (clear[0]) return 0;
        if (clear[1]) return 1;
        return 2;
    }
}
