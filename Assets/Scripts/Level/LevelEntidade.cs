public class LevelEntidade 
{
    private static LevelEntidade[] ARRAY_LEVELS_ENTIDADE;

    public Level level { get; private set; }    
    public Fornecedor<AbstractLevel> supplierLevel { get; private set; }

    public LevelEntidade(Level level, Fornecedor<AbstractLevel> supplierLevel)
    {
        this.level = level;        
        this.supplierLevel = supplierLevel;
    }    

    public static LevelEntidade[] getLevelsEntidades()
    {
        if(ARRAY_LEVELS_ENTIDADE == null)
        {
            ARRAY_LEVELS_ENTIDADE = new LevelEntidade[] {

            new LevelEntidade(Level.HUM   , null),
            new LevelEntidade(Level.DOIS  , null),
            new LevelEntidade(Level.TRES  , null),
            new LevelEntidade(Level.QUATRO, null),
            new LevelEntidade(Level.CINCO , null),
            new LevelEntidade(Level.SEIS  , null),
            new LevelEntidade(Level.SETE  , null),
            new LevelEntidade(Level.OITO  , null),

            new LevelEntidade(Level.CACANIQUEL_PUP_G, LevelCacaNiquelPowerUpGeral.getFornecedor()),
            new LevelEntidade(Level.CACANIQUEL_PUP_I, LevelCacaNiquelPowerUpIndividual.getFornecedor()),

            new LevelEntidade(Level.PUP, LevelPowerUp.getFornecedor()),

            new LevelEntidade(Level.COLETAVEL_PAO           , null),
            new LevelEntidade(Level.COLETAVEL_MACA          , null),
            new LevelEntidade(Level.COLETAVEL_LEITE         , null),
            new LevelEntidade(Level.COLETAVEL_COCO          , null),
            new LevelEntidade(Level.COLETAVEL_ASPARGO       , null),
            new LevelEntidade(Level.COLETAVEL_LARANJA       , null),
            new LevelEntidade(Level.COLETAVEL_ESTRELAMARINHA, null)
        };
        }
        return ARRAY_LEVELS_ENTIDADE;
    }    
}
