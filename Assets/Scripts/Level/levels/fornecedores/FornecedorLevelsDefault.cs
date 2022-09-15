public class FornecedorLevelsDefault : AbstractFornecedorLevels
{
    private static FornecedorLevelsDefault instance;

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
        if(instance == null)
        {
            instance = new FornecedorLevelsDefault();
        }
        return instance;
    }
}
