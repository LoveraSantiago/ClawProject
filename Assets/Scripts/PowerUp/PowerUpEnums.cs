public class PowerUpEnums 
{
    public enum TIPO
    {
        BOMBA_DA_GARRA, MISSIL_NUCLEAR, MINA_TERRESTRE, MISSIL_TELEGUIADO,
        IGUAL, TELEPORTE, CORINGA,
        MINI_ASAS, ASAS, BURACO_NEGRO,
        MOLA,
        ROLLBACK, DESCARTE, NONE
    }

    public enum AREA
    {
        CHAO, NONE
    }

    public class FAMILIA
    {
        public static readonly string EXPLOSIVOS   = "EXPLOSIVOS";
        public static readonly string TRANSMUTACAO = "TRANSMUTAÇÃO";
        public static readonly string LEVITACAO    = "LEVITAÇÃO";
        public static readonly string MECANISMO    = "MECANISMO";
        public static readonly string IMPULSO      = "IMPULSO";
    }  
}
