public class ColetavelEntidade 
{
    private static ColetavelEntidade[] ARRAY_COLETAVEIS_ENTIDADES;
    private static FAMILIA[] ARRAY_FAMILIAS;

    public enum FAMILIA { DEFAULTS, FRUTAS, DINO, BOLAS, FALLGUYS, YUYU,
                          GELEIA, MARIO, MEGAMAN, COGUMELOS, POOPS}

    public int id { get; private set; }//Deve ser unico
    public int ordem { get; private set; }
    public string nome { get; private set; }
    public string nomeSprite { get; private set; }//Deve ser unico
    public FAMILIA familia { get; private set; }    
    public Level level { get; private set; }

    private ColetavelEntidade(int id, int ordem, string nome, string nomeSprite, FAMILIA familia)
        :this(id, ordem, nome, nomeSprite, familia, Level.NONE){}

    public ColetavelEntidade(int id, int ordem, string nome, string nomeSprite, FAMILIA familia, Level level)
    {
        this.id         = id;
        this.nome       = nome;
        this.nomeSprite = nomeSprite;
        this.familia    = familia;
        this.level      = level;
        this.ordem      = ordem;
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
            new ColetavelEntidade(0, -1, "vazio" , "tile-vazio"      , FAMILIA.DEFAULTS),//Range de 0 a 9 pra defaults
            new ColetavelEntidade(1, -1, "random", "tile-random"     , FAMILIA.DEFAULTS),
            new ColetavelEntidade(2, -1, "ovo"   , "capsula-completa", FAMILIA.DEFAULTS),

            new ColetavelEntidade(10, 1, "Leite"          , "characters_0001", FAMILIA.FRUTAS, Level.COLETAVEL_LEITE),//Range de 10 a 19 frutas
            new ColetavelEntidade(11, 2, "Maca"           , "characters_0002", FAMILIA.FRUTAS, Level.COLETAVEL_MACA),
            new ColetavelEntidade(12, 3, "Laranja"        , "characters_0003", FAMILIA.FRUTAS, Level.COLETAVEL_LARANJA),
            new ColetavelEntidade(13, 4, "Pao"            , "characters_0004", FAMILIA.FRUTAS, Level.COLETAVEL_PAO),
            new ColetavelEntidade(14, 5, "Aspargo"        , "characters_0005", FAMILIA.FRUTAS, Level.COLETAVEL_ASPARGO),
            new ColetavelEntidade(15, 6, "Coco"           , "characters_0006", FAMILIA.FRUTAS, Level.COLETAVEL_COCO),
            new ColetavelEntidade(16, 7, "Estrela Marinha", "characters_0007", FAMILIA.FRUTAS, Level.COLETAVEL_ESTRELAMARINHA),
            new ColetavelEntidade(17, 8, "Abobora"        , "aboborav3"      , FAMILIA.FRUTAS, Level.COLETAVEL_ESTRELAMARINHA),

            new ColetavelEntidade(20, 9, "Triceratops"      , "triceratops256"      , FAMILIA.DINO),//Range de 20 a 29 dinos
            new ColetavelEntidade(21, 10, "T-Rex"            , "trex256"             , FAMILIA.DINO),
            new ColetavelEntidade(22, 11, "Pterodatilo"      , "pterodatilo256"      , FAMILIA.DINO),
            new ColetavelEntidade(23, 12, "Parassauro"       , "parassauro256"       , FAMILIA.DINO),
            new ColetavelEntidade(24, 13, "Pachicefalossauro", "pachicefalossauro256", FAMILIA.DINO),

            new ColetavelEntidade(30, 14, "Bola de Beisebol"       , "baseball"        , FAMILIA.BOLAS),
            new ColetavelEntidade(31, 15, "Bola de Basquete"       , "basket"          , FAMILIA.BOLAS),
            new ColetavelEntidade(32, 16, "Bola de Bilhar"         , "bilhar"          , FAMILIA.BOLAS),
            new ColetavelEntidade(33, 17, "Bocha"                  , "bocha"           , FAMILIA.BOLAS),
            new ColetavelEntidade(34, 18, "Bola de Leite"          , "boladeleite"     , FAMILIA.BOLAS),
            new ColetavelEntidade(35, 19, "Bola de Boliche"        , "boliche"         , FAMILIA.BOLAS),
            new ColetavelEntidade(36, 20,  "Bola de Capotao"        , "football"        , FAMILIA.BOLAS),
            new ColetavelEntidade(37, 21, "Bola de Futebol"        , "footbolamericano", FAMILIA.BOLAS),
            new ColetavelEntidade(38, 22, "Bola de Tenis"          , "tenis"           , FAMILIA.BOLAS),

            new ColetavelEntidade(40, 23, "FG1", "fg1", FAMILIA.FALLGUYS),
            new ColetavelEntidade(41, 24, "FG2", "fg2", FAMILIA.FALLGUYS),
            new ColetavelEntidade(42, 25, "FG3", "fg3", FAMILIA.FALLGUYS),
            new ColetavelEntidade(43, 26, "FG4", "fg4", FAMILIA.FALLGUYS),
            new ColetavelEntidade(44, 27, "FG5", "fg5", FAMILIA.FALLGUYS),
            new ColetavelEntidade(45, 28, "FG6", "fg6", FAMILIA.FALLGUYS),
            new ColetavelEntidade(46, 29, "FG7", "fg7", FAMILIA.FALLGUYS),
            new ColetavelEntidade(47, 30, "FG8", "fg8", FAMILIA.FALLGUYS),
            new ColetavelEntidade(48, 31, "FG9", "fg9", FAMILIA.FALLGUYS),

            new ColetavelEntidade(50, 32, "Yusuke"  , "hiei"    , FAMILIA.YUYU),
            new ColetavelEntidade(51, 33, "Kuwabara", "kurama"  , FAMILIA.YUYU),
            new ColetavelEntidade(52, 34, "Hiei"    , "kuwabara", FAMILIA.YUYU),
            new ColetavelEntidade(53, 35, "Kurama"  , "yusuke"  , FAMILIA.YUYU),

            new ColetavelEntidade(60, 36, "Geleia 1"  , "geleia1"  , FAMILIA.GELEIA),
            new ColetavelEntidade(61, 37, "Geleia 2"  , "geleia2"  , FAMILIA.GELEIA),
            new ColetavelEntidade(62, 38, "Geleia 3"  , "geleia3"  , FAMILIA.GELEIA),
            new ColetavelEntidade(63, 39, "Geleia 4"  , "geleia4"  , FAMILIA.GELEIA),
            new ColetavelEntidade(64, 40, "Geleia 5"  , "geleia5"  , FAMILIA.GELEIA),
            new ColetavelEntidade(65, 41, "Geleia 6"  , "geleia6"  , FAMILIA.GELEIA),
            new ColetavelEntidade(66, 42, "Geleia 7"  , "geleia7"  , FAMILIA.GELEIA),
            new ColetavelEntidade(67, 43, "Geleia 8"  , "geleia8"  , FAMILIA.GELEIA),
            new ColetavelEntidade(68, 44, "Geleia 9"  , "geleia9"  , FAMILIA.GELEIA),

            new ColetavelEntidade(70, 45, "Kopa"    , "kopa"    , FAMILIA.MARIO),
            new ColetavelEntidade(71, 46, "Luigi"   , "luigi"   , FAMILIA.MARIO),
            new ColetavelEntidade(72, 47, "Mario"   , "mario"   , FAMILIA.MARIO),
            new ColetavelEntidade(73, 48, "Princesa", "princesa", FAMILIA.MARIO),
            new ColetavelEntidade(74, 49, "Todi"    , "todi"    , FAMILIA.MARIO),

            new ColetavelEntidade(80, 50, "Kalinka", "kalinka", FAMILIA.MEGAMAN),
            new ColetavelEntidade(81, 51, "Megaman", "megaman", FAMILIA.MEGAMAN),
            new ColetavelEntidade(82, 52, "Tadashi", "tadashi", FAMILIA.MEGAMAN),

            new ColetavelEntidade(90, 53, "Congumelo1", "cogumelo1", FAMILIA.COGUMELOS),
            new ColetavelEntidade(91, 54, "Congumelo2", "cogumelo2", FAMILIA.COGUMELOS),
            new ColetavelEntidade(92, 55, "Congumelo3", "cogumelo3", FAMILIA.COGUMELOS),
            new ColetavelEntidade(93, 56, "Congumelo4", "cogumelo4", FAMILIA.COGUMELOS),
            new ColetavelEntidade(94, 57, "Congumelo5", "cogumelo5", FAMILIA.COGUMELOS),
            new ColetavelEntidade(95, 58, "Congumelo6", "cogumelo6", FAMILIA.COGUMELOS),
            new ColetavelEntidade(96, 59, "Congumelo7", "cogumelo7", FAMILIA.COGUMELOS),
            new ColetavelEntidade(97, 60, "Congumelo8", "cogumelo8", FAMILIA.COGUMELOS),
            new ColetavelEntidade(98, 61, "Congumelo9", "cogumelo9", FAMILIA.COGUMELOS),

            new ColetavelEntidade(100, 62, "Poop 1",  "poop1", FAMILIA.POOPS),
            new ColetavelEntidade(101, 63, "Poop 2",  "poop2", FAMILIA.POOPS),
            new ColetavelEntidade(102, 64, "Poop 3",  "poop3", FAMILIA.POOPS),
            new ColetavelEntidade(103, 65, "Poop 4",  "poop4", FAMILIA.POOPS),
            new ColetavelEntidade(104, 66, "Poop 5",  "poop5", FAMILIA.POOPS),
            new ColetavelEntidade(105, 67, "Poop 6",  "poop6", FAMILIA.POOPS),
            new ColetavelEntidade(106, 68, "Poop 7",  "poop7", FAMILIA.POOPS),
            new ColetavelEntidade(107, 69, "Poop 8",  "poop8", FAMILIA.POOPS),
            new ColetavelEntidade(108, 70, "Poop 9",  "poop9", FAMILIA.POOPS),
            new ColetavelEntidade(109, 71, "Poop 10", "poop10", FAMILIA.POOPS),
            
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
