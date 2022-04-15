public class SegmentosTimer 
{                                                   // A, B, C, D, E, F, G
    private readonly int[] ARRAY_ZERO   = new int[7] { 1, 1, 1, 1, 1, 1, 0 };
    private readonly int[] ARRAY_HUM    = new int[7] { 0, 1, 1, 0, 0, 0, 0 };
    private readonly int[] ARRAY_DOIS   = new int[7] { 1, 1, 0, 1, 1, 0, 1 };
    private readonly int[] ARRAY_TRES   = new int[7] { 1, 1, 1, 1, 0, 0, 1 };
    private readonly int[] ARRAY_QUATRO = new int[7] { 0, 1, 1, 0, 0, 1, 1 };
    private readonly int[] ARRAY_CINCO  = new int[7] { 1, 0, 1, 1, 0, 1, 1 };
    private readonly int[] ARRAY_SEIS   = new int[7] { 1, 0, 1, 1, 1, 1, 1 };
    private readonly int[] ARRAY_SETE   = new int[7] { 1, 1, 1, 0, 0, 1, 0 };
    private readonly int[] ARRAY_OITO   = new int[7] { 1, 1, 1, 1, 1, 1, 1 };
    private readonly int[] ARRAY_NOVE   = new int[7] { 1, 1, 1, 1, 0, 1, 1 };

    public int[] getArrayParaLigar(int digito)
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
}
