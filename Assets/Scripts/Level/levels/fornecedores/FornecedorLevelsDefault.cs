public class FornecedorLevelsDefault : AbstractFornecedorLevels
{
    private static FornecedorLevelsDefault level;

    public override int getQtdLevels()
    {
        return 0;
    }

    protected override AbstractLevel getLevelPorIndice(int level)
    {
        return null;
    }

    public static FornecedorLevelsDefault getInstance()
    {
        if(level == null)
        {
            level = new FornecedorLevelsDefault();
        }
        return level;
    }
}
