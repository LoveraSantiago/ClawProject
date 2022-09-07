public class FornecedorLevelsTestes : AbstractFornecedor10Leveis
{
    protected override AbstractLevel getLevelPrimeiro()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelSegundo()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelTerceiro()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelQuarto()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelQuinto()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelSexto()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelSetimo()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelOitavo()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelNono()
    {
        return getLevelTeste();
    }

    protected override AbstractLevel getLevelDecimo()
    {
        return getLevelTeste();
    }

    private AbstractLevel getLevelTeste()
    {
        return new LevelTeste();
    }
}
