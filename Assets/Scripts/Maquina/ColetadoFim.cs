public class ColetadoFim 
{
    public bool[] clear;

    public ColetadoFim(bool clear1, bool clear2, bool clear3)
    {
        clear = new bool[] { clear1, clear2, clear3 };
    }

    public ColetadoFim(bool[] clears)
        :this(clears[0], clears[1], clears[2])
    {
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
