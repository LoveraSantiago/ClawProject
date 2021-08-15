public class ColetadoFim 
{
    public bool[] clear;

    public ColetadoFim(bool clear1, bool clear2, bool clear3)
    {
        clear = new bool[] { clear1, clear2, clear3 };
    }

    public bool devolverBoard()
    {
        return clear[0] && clear[1] && clear[2];
    }
}
