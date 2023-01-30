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
    public enum ESTADO 
    { 
        INICIO, PREFINALIZAR, FINALIZAR, EXPIRADO,
        ALVO1_SELECIONADO, ALVO2_SELECIONADO, ALVO3_SELECIONADO
    }

    public class FAMILIA
    {
        public const string EXPLOSIVOS   = "EXPLOSIVOS";
        public const string TRANSMUTACAO = "TRANSMUTAÇÃO";
        public const string LEVITACAO    = "LEVITAÇÃO";
        public const string MECANISMO    = "MECANISMO";
        public const string IMPULSO      = "IMPULSO";
    }

}
