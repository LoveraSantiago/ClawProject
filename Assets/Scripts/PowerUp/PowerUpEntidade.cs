public class PowerUpEntidade 
{
    public enum NAME
    {
        BOMBA_DA_GARRA, MISSIL_DA_GARRA, MINA_TERRESTRE, NONE
    }

    public enum AREA
    {
        CHAO, NONE
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

    private static PowerUpEntidade bombaDaGarra;
    private static PowerUpEntidade missilDaGarra;
    private static PowerUpEntidade minaTerrestre;

    private static PowerUpEntidade getBombaDaGarra()
    {
        if(bombaDaGarra == null)
        {
            bombaDaGarra = new PowerUpEntidade(NAME.BOMBA_DA_GARRA, 9, "bomba");
        }
        return bombaDaGarra;
    }

    private static PowerUpEntidade getMissilDaGarra()
    {
        if(missilDaGarra == null)
        {
            missilDaGarra = new PowerUpEntidade(NAME.MISSIL_DA_GARRA, 9, "nuclear-bomba-btn");
        }
        return missilDaGarra;
    }

    private static PowerUpEntidade getMinaTerrestre()
    {
        if(minaTerrestre == null)
        {
            minaTerrestre = new PowerUpEntidade(NAME.MISSIL_DA_GARRA, 3, AREA.CHAO, "mina-terrestre");
        }
        return minaTerrestre;
    }

    public static PowerUpEntidade getPowerUpEntidadeByEnum(NAME name)
    {
        switch (name)
        {
            case NAME.BOMBA_DA_GARRA:  return getBombaDaGarra();
            case NAME.MISSIL_DA_GARRA: return getMissilDaGarra();
            case NAME.MINA_TERRESTRE:  return getMinaTerrestre();
        }
        return null;
    }
}
