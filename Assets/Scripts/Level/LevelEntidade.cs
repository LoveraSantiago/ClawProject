public class LevelEntidade 
{
    public Level level { get; private set; }
    public string alias { get; private set; }
    public Fornecedor<AbstractLevel> supplierLevel { get; private set; }

    public LevelEntidade(Level level, string alias, Fornecedor<AbstractLevel> supplierLevel)
    {
        this.level = level;
        this.alias = alias;
        this.supplierLevel = supplierLevel;
    }

    public static LevelEntidade[] ARRAY_LEVELS_ENTIDADE = new LevelEntidade[] {

        new LevelEntidade(Level.HUM   , "1", Level1.getFornecedor()),
        new LevelEntidade(Level.DOIS  , "2", Level2.getFornecedor()),
        new LevelEntidade(Level.TRES  , "3", Level3.getFornecedor()),
        new LevelEntidade(Level.QUATRO, "4", Level4.getFornecedor()),

        new LevelEntidade(Level.PUP, "TreinoPup", LevelPup.getFornecedor()),

        new LevelEntidade(Level.COLETAVEL, "Coletavel", LevelColetavel.getFornecedor()),

        new LevelEntidade(Level.CACANIQUEL_PUP_G, "CacaNiquelGeral"     , LevelCacaNiquelPupGeral.getFornecedor()),
        new LevelEntidade(Level.CACANIQUEL_PUP_I, "CacaNiquelIndividual", LevelCacaNiquelPupIndividual.getFornecedor()),
    };
}
