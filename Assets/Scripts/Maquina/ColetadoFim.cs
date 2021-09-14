public class ColetadoFim 
{
    private static readonly int ESTADO_NORMAL    = 0;
    private static readonly int ESTADO_BOARD     = 1;
    private static readonly int ESTADO_TUBOSAIDA = 2;

    private int estadoAtual;
    public bool[] clear { get; private set; }


    private ColetadoFim(int estadoAtual, bool[] clears)        
    {
        this.estadoAtual = estadoAtual;
        this.clear = clears;
    }

    //public bool devolverBoard()
    //{
    //    return clear[0] && clear[1] && clear[2];
    //}

    //public bool reajustarContador()
    //{
    //    int contadorClear = 0;
    //    if (clear[0]) contadorClear++;
    //    if (clear[1]) contadorClear++;
    //    if (clear[2]) contadorClear++;

    //    return contadorClear == 1;
    //}

    //public int getPrimeiroIndiceParaLimpar()
    //{
    //    if (clear[0]) return 0;
    //    if (clear[1]) return 1;
    //    return 2;
    //}

    public static ColetadoFim ofNormal(bool[] clears)
    {
        return new ColetadoFim(ESTADO_NORMAL, clears);        
    }

    public static ColetadoFim ofPup(PowerUpEntidade.TIPO tipo, bool[] clears)
    {
        if(tipo == PowerUpEntidade.TIPO.ROLLBACK)
        {
            return new ColetadoFim(ESTADO_BOARD, clears);
        }
        else if(tipo == PowerUpEntidade.TIPO.DESCARTE)
        {
            return new ColetadoFim(ESTADO_TUBOSAIDA, clears);
        }
        else
        {
            return ofNormal(clears);
        }
    }
}
