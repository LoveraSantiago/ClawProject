public class ColetavelEntidade 
{
    private static ColetavelEntidade[] ARRAY_COLETAVEIS_ENTIDADES;
    private static FAMILIA[] ARRAY_FAMILIAS;

    public enum FAMILIA { DEFAULTS, FRUTAS, FAKE}

    public int id { get; private set; }//Deve ser unico
    public string nome { get; private set; }
    public string nomeSprite { get; private set; }//Deve ser unico
    public FAMILIA familia { get; private set; }    
    public Level level { get; private set; }

    public ColetavelEntidade(int id, string nome, string nomeSprite, FAMILIA familia)
        :this(id, nome, nomeSprite, familia, Level.NONE){}

    public ColetavelEntidade(int id, string nome, string nomeSprite, FAMILIA familia, Level level)
    {
        this.id = id;
        this.nome = nome;
        this.nomeSprite = nomeSprite;
        this.familia = familia;
        this.level = level;
    }

    public static ColetavelEntidade[] getColetaveisEntidades()
    {
        if(ARRAY_COLETAVEIS_ENTIDADES == null)
        {
            inicializarColetaveisEntidades();
        }
        return ARRAY_COLETAVEIS_ENTIDADES;
    }

    public static FAMILIA[] getFamiliasDeColetaveis()
    {
        if(ARRAY_FAMILIAS == null)
        {
            ARRAY_FAMILIAS = new FAMILIA[]{ FAMILIA.FRUTAS, FAMILIA.FAKE };
        }
        return ARRAY_FAMILIAS;
    }

    private static void inicializarColetaveisEntidades()
    {
        ARRAY_COLETAVEIS_ENTIDADES = new ColetavelEntidade[] {
            new ColetavelEntidade(0, "vazio" , "tile-vazio" , FAMILIA.DEFAULTS),//Range de 0 a 9 pra defaults
            new ColetavelEntidade(1, "random", "tile-random", FAMILIA.DEFAULTS),
            new ColetavelEntidade(2, "ovo", "capsula-completa", FAMILIA.DEFAULTS),

            new ColetavelEntidade(10, "Leite"          , "characters_0001", FAMILIA.FRUTAS, Level.COLETAVEL_LEITE),//Range de 10 a 19 frutas
            new ColetavelEntidade(11, "Maca"           , "characters_0002", FAMILIA.FRUTAS, Level.COLETAVEL_MACA),
            new ColetavelEntidade(12, "Laranja"        , "aboborav3"      , FAMILIA.FRUTAS, Level.COLETAVEL_LARANJA),
            new ColetavelEntidade(13, "Pao"            , "characters_0004", FAMILIA.FRUTAS, Level.COLETAVEL_PAO),
            new ColetavelEntidade(14, "Aspargo"        , "characters_0005", FAMILIA.FRUTAS, Level.COLETAVEL_ASPARGO),
            new ColetavelEntidade(15, "Coco"           , "characters_0006", FAMILIA.FRUTAS, Level.COLETAVEL_COCO),
            new ColetavelEntidade(16, "Estrela Marinha", "characters_0007", FAMILIA.FRUTAS, Level.COLETAVEL_ESTRELAMARINHA),

            new ColetavelEntidade(17, "Fake1", "tile-random-temp1", FAMILIA.FAKE),
            new ColetavelEntidade(18, "Fake2", "tile-random-temp2", FAMILIA.FAKE),
            new ColetavelEntidade(19, "Fake3", "tile-random-temp3", FAMILIA.FAKE),
            new ColetavelEntidade(20, "Fake4", "tile-random-temp4", FAMILIA.FAKE),
            new ColetavelEntidade(21, "Fake5", "tile-random-temp5", FAMILIA.FAKE),
            new ColetavelEntidade(22, "Fake6", "tile-random-temp6", FAMILIA.FAKE),
            new ColetavelEntidade(23, "Fake7", "tile-random-temp7", FAMILIA.FAKE),
        };
    }

    public bool isVazio()
    {
        return id == 0;
    }

    public bool isRandom()
    {
        return id == 1;
    }
}
