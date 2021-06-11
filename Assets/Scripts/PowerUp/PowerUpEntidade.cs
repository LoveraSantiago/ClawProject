public class PowerUpEntidade 
{
    public enum NAME
    {
        BOMBA_DA_GARRA, MISSIL_NUCLEAR, MINA_TERRESTRE, MISSIL_TELEGUIADO, TELEPORTE, ASAS, NONE
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
    public string nomeSpriteBtn { get; private set; }
    public bool isClicavel { get; private set; }
    public AREA area { get; private set; }

    public PowerUpEntidade()
    {   
    }    

    public PowerUpEntidade configNomes(NAME nomeEntidade, string nomeSpriteBtn)
    {
        name = nomeEntidade;
        this.nomeSpriteBtn = nomeSpriteBtn;
        return this;
    }

    public PowerUpEntidade configIsClicavel(bool clicavel)
    {
        isClicavel = clicavel;
        return this;
    }

    public PowerUpEntidade configDuracao(int duracao)
    {
        this.duracao = duracao;
        return this;
    }

    public PowerUpEntidade configArea()
    {
        return configArea(AREA.NONE);
    }

    public PowerUpEntidade configArea(AREA area)
    {
        this.area = area;
        return this;
    }
}
