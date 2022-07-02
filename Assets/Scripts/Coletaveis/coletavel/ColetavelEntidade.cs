public class ColetavelEntidade 
{
    private static ColetavelEntidade[] ARRAY_COLETAVEIS_ENTIDADES;
    private static FAMILIA[] ARRAY_FAMILIAS;

    public enum FAMILIA { DEFAULTS, FRUTAS, DINO, BOLAS, FALLGUYS, YUYU,
                          GELEIA, MARIO}

    public int id { get; private set; }//Deve ser unico
    public string nome { get; private set; }
    public string nomeSprite { get; private set; }//Deve ser unico
    public FAMILIA familia { get; private set; }    
    public Level level { get; private set; }

    private ColetavelEntidade(int id, string nome, string nomeSprite, FAMILIA familia)
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
            ARRAY_FAMILIAS = new FAMILIA[]{ FAMILIA.FRUTAS, FAMILIA.DINO };
        }
        return ARRAY_FAMILIAS;
    }

    private static void inicializarColetaveisEntidades()
    {
        ARRAY_COLETAVEIS_ENTIDADES = new ColetavelEntidade[] {
            new ColetavelEntidade(0, "vazio" , "tile-vazio"      , FAMILIA.DEFAULTS),//Range de 0 a 9 pra defaults
            new ColetavelEntidade(1, "random", "tile-random"     , FAMILIA.DEFAULTS),
            new ColetavelEntidade(2, "ovo"   , "capsula-completa", FAMILIA.DEFAULTS),

            new ColetavelEntidade(10, "Leite"          , "characters_0001", FAMILIA.FRUTAS, Level.COLETAVEL_LEITE),//Range de 10 a 19 frutas
            new ColetavelEntidade(11, "Maca"           , "characters_0002", FAMILIA.FRUTAS, Level.COLETAVEL_MACA),
            new ColetavelEntidade(12, "Laranja"        , "characters_0003", FAMILIA.FRUTAS, Level.COLETAVEL_LARANJA),
            new ColetavelEntidade(13, "Pao"            , "characters_0004", FAMILIA.FRUTAS, Level.COLETAVEL_PAO),
            new ColetavelEntidade(14, "Aspargo"        , "characters_0005", FAMILIA.FRUTAS, Level.COLETAVEL_ASPARGO),
            new ColetavelEntidade(15, "Coco"           , "characters_0006", FAMILIA.FRUTAS, Level.COLETAVEL_COCO),
            new ColetavelEntidade(16, "Estrela Marinha", "characters_0007", FAMILIA.FRUTAS, Level.COLETAVEL_ESTRELAMARINHA),
            new ColetavelEntidade(17, "Abobora"        , "aboborav3"      , FAMILIA.FRUTAS, Level.COLETAVEL_ESTRELAMARINHA),

            new ColetavelEntidade(20, "Triceratops"      , "triceratops256"      , FAMILIA.DINO),//Range de 20 a 29 dinos
            new ColetavelEntidade(21, "T-Rex"            , "trex256"             , FAMILIA.DINO),
            new ColetavelEntidade(22, "Pterodatilo"      , "pterodatilo256"      , FAMILIA.DINO),
            new ColetavelEntidade(23, "Parassauro"       , "parassauro256"       , FAMILIA.DINO),
            new ColetavelEntidade(24, "Pachicefalossauro", "pachicefalossauro256", FAMILIA.DINO),

            new ColetavelEntidade(30, "Bola de Beisebol"       , "baseball"        , FAMILIA.BOLAS),
            new ColetavelEntidade(31, "Bola de Basquete"       , "basket"          , FAMILIA.BOLAS),
            new ColetavelEntidade(32, "Bola de Bilhar"         , "bilhar"          , FAMILIA.BOLAS),
            new ColetavelEntidade(33, "Bocha"                  , "bocha"           , FAMILIA.BOLAS),
            new ColetavelEntidade(34, "Bola de Leite"          , "boladeleite"     , FAMILIA.BOLAS),
            new ColetavelEntidade(35, "Bola de Boliche"        , "boliche"         , FAMILIA.BOLAS),
            new ColetavelEntidade(36, "Bola de Capotao"        , "football"        , FAMILIA.BOLAS),
            new ColetavelEntidade(37, "Bola de Futebol"        , "footbolamericano", FAMILIA.BOLAS),
            new ColetavelEntidade(38, "Bola de Tenis"          , "tenis"           , FAMILIA.BOLAS),

            new ColetavelEntidade(40, "FG1", "fg1", FAMILIA.FALLGUYS),
            new ColetavelEntidade(41, "FG2", "fg2", FAMILIA.FALLGUYS),
            new ColetavelEntidade(42, "FG3", "fg3", FAMILIA.FALLGUYS),
            new ColetavelEntidade(43, "FG4", "fg4", FAMILIA.FALLGUYS),
            new ColetavelEntidade(44, "FG5", "fg5", FAMILIA.FALLGUYS),
            new ColetavelEntidade(45, "FG6", "fg6", FAMILIA.FALLGUYS),
            new ColetavelEntidade(46, "FG7", "fg7", FAMILIA.FALLGUYS),
            new ColetavelEntidade(47, "FG8", "fg8", FAMILIA.FALLGUYS),
            new ColetavelEntidade(48, "FG9", "fg9", FAMILIA.FALLGUYS),

            new ColetavelEntidade(50, "Yusuke"  , "hiei"    , FAMILIA.YUYU),
            new ColetavelEntidade(51, "Kuwabara", "kurama"  , FAMILIA.YUYU),
            new ColetavelEntidade(52, "Hiei"    , "kuwabara", FAMILIA.YUYU),
            new ColetavelEntidade(53, "Kurama"  , "yusuke"  , FAMILIA.YUYU),

            new ColetavelEntidade(60, "Geleia 1"  , "geleia1"  , FAMILIA.GELEIA),
            new ColetavelEntidade(61, "Geleia 2"  , "geleia2"  , FAMILIA.GELEIA),
            new ColetavelEntidade(62, "Geleia 3"  , "geleia3"  , FAMILIA.GELEIA),
            new ColetavelEntidade(63, "Geleia 4"  , "geleia4"  , FAMILIA.GELEIA),
            new ColetavelEntidade(64, "Geleia 5"  , "geleia5"  , FAMILIA.GELEIA),
            new ColetavelEntidade(65, "Geleia 6"  , "geleia6"  , FAMILIA.GELEIA),
            new ColetavelEntidade(66, "Geleia 7"  , "geleia7"  , FAMILIA.GELEIA),
            new ColetavelEntidade(67, "Geleia 8"  , "geleia8"  , FAMILIA.GELEIA),
            new ColetavelEntidade(68, "Geleia 9"  , "geleia9"  , FAMILIA.GELEIA),

            new ColetavelEntidade(70, "Kopa"    , "kopa"    , FAMILIA.MARIO),
            new ColetavelEntidade(71, "Luigi"   , "luigi"   , FAMILIA.MARIO),
            new ColetavelEntidade(72, "Mario"   , "mario"   , FAMILIA.MARIO),
            new ColetavelEntidade(73, "Princesa", "princesa", FAMILIA.MARIO),
            new ColetavelEntidade(74, "Todi"    , "todi"    , FAMILIA.MARIO),
            
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
