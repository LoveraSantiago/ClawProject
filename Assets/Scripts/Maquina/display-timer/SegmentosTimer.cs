using UnityEngine;

public class SegmentosTimer 
{                                                       //0A, BC, DE, FG
    private readonly Vector4 DIGITO_ZERO   = new Vector4( 01, 11, 11, 10 );
    private readonly Vector4 DIGITO_HUM    = new Vector4( 00, 11, 00, 00 );
    private readonly Vector4 DIGITO_DOIS   = new Vector4( 01, 10, 11, 01 );
    private readonly Vector4 DIGITO_TRES   = new Vector4( 01, 11, 10, 01 );
    private readonly Vector4 DIGITO_QUATRO = new Vector4( 00, 11, 00, 11 );
    private readonly Vector4 DIGITO_CINCO  = new Vector4( 01, 01, 10, 11 );
    private readonly Vector4 DIGITO_SEIS   = new Vector4( 01, 01, 11, 11 );
    private readonly Vector4 DIGITO_SETE   = new Vector4( 01, 11, 00, 10 );
    private readonly Vector4 DIGITO_OITO   = new Vector4( 01, 11, 11, 11 );
    private readonly Vector4 DIGITO_NOVE   = new Vector4( 01, 11, 10, 11 );
    private readonly Vector4 DIGITO_OFF    = new Vector4(00, 00, 00, 00);

    public Vector4 getSegmentosDigito(int digito)
    {
        switch (digito)
        {
            case 0: return DIGITO_ZERO;
            case 1: return DIGITO_HUM;
            case 2: return DIGITO_DOIS;
            case 3: return DIGITO_TRES;
            case 4: return DIGITO_QUATRO;
            case 5: return DIGITO_CINCO;
            case 6: return DIGITO_SEIS;
            case 7: return DIGITO_SETE;
            case 8: return DIGITO_OITO;
            case 9: return DIGITO_NOVE;
        }
        return DIGITO_ZERO;
    }

    public Vector4 getSegmentosOff()
    {
        return DIGITO_OFF;
    }
}


