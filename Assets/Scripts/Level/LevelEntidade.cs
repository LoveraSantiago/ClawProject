public class LevelEntidade 
{
    private static LevelEntidade[] ARRAY_LEVELS_ENTIDADE;

    public Level level { get; private set; }
    public string alias { get; private set; }
    public Fornecedor<AbstractLevel> supplierLevel { get; private set; }

    public LevelEntidade(Level level, string alias, Fornecedor<AbstractLevel> supplierLevel)
    {
        this.level = level;
        this.alias = alias;
        this.supplierLevel = supplierLevel;
    }    

    public static LevelEntidade[] getLevelsEntidades()
    {
        if(ARRAY_LEVELS_ENTIDADE == null)
        {
            inicializarLevelsEntidades();
        }
        return ARRAY_LEVELS_ENTIDADE;
    }

    private static void inicializarLevelsEntidades()
    {
        ARRAY_LEVELS_ENTIDADE = new LevelEntidade[] {

            new LevelEntidade(Level.HUM   , "1", Level1.getFornecedor()),
            new LevelEntidade(Level.DOIS  , "2", Level2.getFornecedor()),
            new LevelEntidade(Level.TRES  , "3", Level3.getFornecedor()),
            new LevelEntidade(Level.QUATRO, "4", Level4.getFornecedor()),

            new LevelEntidade(Level.PUP, "TreinoPup", LevelPup.getFornecedor()),

            new LevelEntidade(Level.COLETAVEL, "Coletavel", LevelColetavel.getFornecedor()),

            new LevelEntidade(Level.COLETAVEL_PAO, "LevelPao", LevelPao.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_MACA, "LevelMaca", LevelMaca.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_LEITE, "LevelLeite", LevelLeite.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_COCO, "LevelCoco", LevelCoco.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_ASPARGO, "LevelAspargo", LevelAspargo.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_LARANJA, "LevelLaranja", LevelLaranja.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_ESTRELAMARINHA, "LevelEstrelaMarinha", LevelEstrelaMarinha.getFornecedor()),

            new LevelEntidade(Level.CACANIQUEL_PUP_G, "CacaNiquelGeral"     , LevelCacaNiquelPupGeral.getFornecedor()),
            new LevelEntidade(Level.CACANIQUEL_PUP_I, "CacaNiquelIndividual", LevelCacaNiquelPupIndividual.getFornecedor()),
        };
    }
}
