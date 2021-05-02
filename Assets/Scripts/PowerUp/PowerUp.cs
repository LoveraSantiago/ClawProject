public class PowerUp 
{
    public enum TIPO
    {
        BOMBA_DA_GARRA, NONE
    }    

    public TIPO tipo   { get; private set; }    
    public int duracao { get; private set; }
    public string nomeSprite { get; private set; }
    public bool isClicavel { get; private set; }

    public PowerUp(TIPO tipo, int duracao, string nomeSprite, bool clicavel)
    {
        this.tipo = tipo;
        this.duracao = duracao;
        this.nomeSprite = nomeSprite;
    }

    private static PowerUp bombaDaGarra;

    private static PowerUp getBombaDaGarra()
    {
        if(bombaDaGarra == null)
        {
            bombaDaGarra = new PowerUp(TIPO.BOMBA_DA_GARRA, 5, "bomba", true);
        }
        return bombaDaGarra;
    }

    public static PowerUp getPowerUpByEnum(TIPO tipo)
    {
        switch (tipo)
        {
            case TIPO.BOMBA_DA_GARRA:
            {
                return getBombaDaGarra();
            }
        }
        return null;
    }
}
