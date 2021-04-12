public class PowerUp 
{
    public enum TIPO
    {
        BOMBA_DA_GARRA
    }

    public enum BOTAO
    {
        CLIQUE, DRAG
    }

    public TIPO tipo { get; private set; }
    public BOTAO botao { get; private set; }

    public PowerUp(TIPO tipo, BOTAO botao)
    {
        this.tipo = tipo;
        this.botao = botao;
    }

    public static PowerUp BombaDaGarra { get { return new PowerUp(TIPO.BOMBA_DA_GARRA, BOTAO.CLIQUE); } }            
}
