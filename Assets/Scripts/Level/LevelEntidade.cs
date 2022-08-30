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
            ARRAY_LEVELS_ENTIDADE = FactoryLevelEntidade.factory();
        }
        return ARRAY_LEVELS_ENTIDADE;
    }    
}
