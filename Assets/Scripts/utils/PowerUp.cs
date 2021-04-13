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

    public TIPO tipo   { get; private set; }
    public BOTAO botao { get; private set; }
    public int duracao { get; private set; }

    public PowerUp(TIPO tipo, BOTAO botao, int duracao)
    {
        this.tipo = tipo;
        this.botao = botao;
        this.duracao = duracao;
    }

    public static PowerUp BombaDaGarra { get { return new PowerUp(TIPO.BOMBA_DA_GARRA, BOTAO.CLIQUE, 5); } }            
}
