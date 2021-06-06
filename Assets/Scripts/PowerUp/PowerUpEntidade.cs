public class PowerUpEntidade 
{
    public enum NAME
    {
        BOMBA_DA_GARRA, MISSIL_NUCLEAR, MINA_TERRESTRE, MISSIL_TELEGUIADO, TELEPORTE, NONE
    }

    public enum AREA
    {
        CHAO, NONE
    }

    public enum INTERACAOGARRA
    {
        MOVIMENTO, PARADO, NAO_INTERACAO
    }

    public NAME name   { get; private set; }    
    public int duracao { get; private set; }
    public string nomeSprite { get; private set; }
    public bool isClicavel { get; private set; }
    public AREA area { get; private set; }

    public PowerUpEntidade(NAME name, int duracao, string nomeSprite)
    {
        this.name = name;
        this.duracao = duracao;
        this.nomeSprite = nomeSprite;
        this.isClicavel = true;
        this.area = AREA.NONE;
    }

    public PowerUpEntidade(NAME name, int duracao, AREA area, string nomeSprite)
    {
        this.name = name;
        this.duracao = duracao;
        this.nomeSprite = nomeSprite;
        this.isClicavel = false;
        this.area = area;
    }    
}
