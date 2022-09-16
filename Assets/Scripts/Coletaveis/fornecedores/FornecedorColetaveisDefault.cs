public class FornecedorColetaveisDefault : AbstractFornecedorColetaveisLevels
{
    private static FornecedorColetaveisDefault instance;

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] { };
    }

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        return null;
    }

    public static FornecedorColetaveisDefault getInstace()
    {
        if (instance == null)
        {
            instance = new FornecedorColetaveisDefault();
        }
        return instance;
    }
}
