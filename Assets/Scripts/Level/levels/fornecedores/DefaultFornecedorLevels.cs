public class DefaultFornecedorLevels : AbstractFornecedorLevels
{
    private static DefaultFornecedorLevels instance;

    public override int getQtdLevels()
    {
        return 0;
    }

    protected override AbstractLevel getLevelPorIndice(int level)
    {
        return null;
    }

    public static DefaultFornecedorLevels getInstance()
    {
        if(instance == null)
        {
            instance = new DefaultFornecedorLevels();
        }
        return instance;
    }
}
