public class PowerUp 
{
    public enum TIPO
    {
        BOMBA_DA_GARRA, NONE
    }    

    public TIPO tipo   { get; private set; }    
    public int duracao { get; private set; }

    public PowerUp(TIPO tipo, int duracao)
    {
        this.tipo = tipo;
     
        this.duracao = duracao;
    }

    public static PowerUp BombaDaGarra { get { return new PowerUp(TIPO.BOMBA_DA_GARRA, 5); } }            
    public static PowerUp PowerUpVazio { get { return new PowerUp(TIPO.NONE, 0); } }
}
