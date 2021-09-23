public class PowerUpEnums 
{
    public enum TIPO
    {
        BOMBA_DA_GARRA, MISSIL_NUCLEAR, MINA_TERRESTRE, MISSIL_TELEGUIADO,
        TELEPORTE, ASAS, ROLLBACK, DESCARTE, NONE
    }

    public enum AREA
    {
        CHAO, NONE
    }

    public class FAMILIA
    {
        public static readonly string EXPLOSIVOS = "EXPLOSIVOS";
        public static readonly string TRANSMUTACAO = "TRANSMUTAÇÃO";
        public static readonly string LEVITACAO = "LEVITAÇÂO";
        public static readonly string MECANISMO = "MECANISMO";
    }

    public enum INTERACAOGARRA
    {
        MOVIMENTO, PARADO, NAO_INTERACAO
    }
}
