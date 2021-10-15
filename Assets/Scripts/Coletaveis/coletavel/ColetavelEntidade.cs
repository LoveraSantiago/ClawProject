public class ColetavelEntidade 
{
    public enum FAMILIA { DEFAULTS, FRUTAS, FAKE}

    public int id { get; private set; }//Deve ser unico
    public string nome { get; private set; }
    public string nomeSprite { get; private set; }//Deve ser unico
    public FAMILIA familia { get; private set; }    

    public ColetavelEntidade(int id, string nome, string nomeSprite, FAMILIA familia)
    {
        this.id = id;
        this.nome = nome;
        this.nomeSprite = nomeSprite;
        this.familia = familia;
    }

    public static ColetavelEntidade[] ARRAY_COLETAVEIS_ENTIDADES = new ColetavelEntidade[] {
        new ColetavelEntidade(0, "vazio" , "tile-vazio" , FAMILIA.DEFAULTS),//Range de 0 a 9 pra defaults
        new ColetavelEntidade(1, "random", "tile-random", FAMILIA.DEFAULTS),

        new ColetavelEntidade(10, "Leite"          , "characters_0001", FAMILIA.FRUTAS),//Range de 10 a 19 frutas
        new ColetavelEntidade(11, "Maca"           , "characters_0002", FAMILIA.FRUTAS),
        new ColetavelEntidade(12, "Laranja"        , "characters_0003", FAMILIA.FRUTAS),
        new ColetavelEntidade(13, "Pao"            , "characters_0004", FAMILIA.FRUTAS),
        new ColetavelEntidade(14, "Aspargo"       , "characters_0005", FAMILIA.FRUTAS),
        new ColetavelEntidade(15, "Coco"           , "characters_0006", FAMILIA.FRUTAS),
        new ColetavelEntidade(16, "Estrelamarinha?", "characters_0007", FAMILIA.FRUTAS),

        new ColetavelEntidade(16, "Fake1", "tile-random", FAMILIA.FAKE),
        new ColetavelEntidade(17, "Fake2", "tile-random", FAMILIA.FAKE),
        new ColetavelEntidade(18, "Fake3", "tile-random", FAMILIA.FAKE),
        new ColetavelEntidade(19, "Fake4", "tile-random", FAMILIA.FAKE),
        new ColetavelEntidade(20, "Fake5", "tile-random", FAMILIA.FAKE),
        new ColetavelEntidade(21, "Fake6", "tile-random", FAMILIA.FAKE),
        new ColetavelEntidade(22, "Fake7", "tile-random", FAMILIA.FAKE),
    };

    public bool isVazio()
    {
        return id == 0;
    }

    public bool isRandom()
    {
        return id == 1;
    }
}
