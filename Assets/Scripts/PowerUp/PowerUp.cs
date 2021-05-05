public class PowerUp 
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

    public PowerUp(NAME name, int duracao, string nomeSprite)
    {
        this.name = name;
        this.duracao = duracao;
        this.nomeSprite = nomeSprite;
        this.isClicavel = true;
        this.area = AREA.NONE;
    }

    public PowerUp(NAME name, AREA area, string nomeSprite)
    {
        this.name = name;
        this.duracao = 0;
        this.nomeSprite = nomeSprite;
        this.isClicavel = false;
        this.area = area;
    }

    private static PowerUp bombaDaGarra;
    private static PowerUp missilDaGarra;
    private static PowerUp minaTerrestre;

    private static PowerUp getBombaDaGarra()
    {
        if(bombaDaGarra == null)
        {
            bombaDaGarra = new PowerUp(NAME.BOMBA_DA_GARRA, 9, "bomba");
        }
        return bombaDaGarra;
    }

    private static PowerUp getMissilDaGarra()
    {
        if(missilDaGarra == null)
        {
            missilDaGarra = new PowerUp(NAME.MISSIL_DA_GARRA, 9, "nuclear-bomba-btn");
        }
        return missilDaGarra;
    }

    private static PowerUp getMinaTerrestre()
    {
        if(minaTerrestre == null)
        {
            minaTerrestre = new PowerUp(NAME.MISSIL_DA_GARRA, 9, "mina-terrestre", false);
        }
        return minaTerrestre;
    }

    public static PowerUp getPowerUpByEnum(NAME name)
    {
        switch (name)
        {
            case NAME.BOMBA_DA_GARRA: return getBombaDaGarra();
            case NAME.MISSIL_DA_GARRA: return getMissilDaGarra();
            case NAME.MINA_TERRESTRE: return getMinaTerrestre();
        }
        return null;
    }
}
