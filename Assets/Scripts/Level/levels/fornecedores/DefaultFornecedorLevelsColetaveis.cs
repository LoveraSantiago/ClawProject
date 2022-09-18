public class DefaultFornecedorLevelsColetaveis : AbstractFornecedorColetaveisLevels
{
    private static DefaultFornecedorLevelsColetaveis instance;    

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        return null;
    }

    public static DefaultFornecedorLevelsColetaveis getInstace()
    {
        if (instance == null)
        {
            instance = new DefaultFornecedorLevelsColetaveis();
        }
        return instance;
    }
}
