public class FornecedorLevelsParqueDeDiversoes : AbstractFornecedor10Leveis
{
    protected override AbstractLevel getLevelPrimeiro()
    {
        return new parque_diversoes.Level1();
    }

    protected override AbstractLevel getLevelSegundo()
    {
        return new parque_diversoes.Level2();
    }

    protected override AbstractLevel getLevelTerceiro()
    {
        return new parque_diversoes.Level3();
    }

    protected override AbstractLevel getLevelQuarto()
    {
        return new parque_diversoes.Level4();
    }

    protected override AbstractLevel getLevelQuinto()
    {
        return new parque_diversoes.Level5();
    }

    protected override AbstractLevel getLevelSexto()
    {
        return new parque_diversoes.Level6();
    }

    protected override AbstractLevel getLevelSetimo()
    {
        return new parque_diversoes.Level7();
    }

    protected override AbstractLevel getLevelOitavo()
    {
        return new parque_diversoes.Level8();
    }

    protected override AbstractLevel getLevelNono()
    {
        return new parque_diversoes.Level9();
    }

    protected override AbstractLevel getLevelDecimo()
    {
        return new parque_diversoes.Level10();
    }
}
