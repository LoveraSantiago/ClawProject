public class FornecedorLevelsParqueDeDiversoes : AbstractFornecedor10Leveis
{
    protected override AbstractLevel getLevelPrimeiro()
    {
        return new Level1();
    }

    protected override AbstractLevel getLevelSegundo()
    {
        return new Level2();
    }

    protected override AbstractLevel getLevelTerceiro()
    {
        return new Level3();
    }

    protected override AbstractLevel getLevelQuarto()
    {
        return new Level4();
    }

    protected override AbstractLevel getLevelQuinto()
    {
        return new Level5();
    }

    protected override AbstractLevel getLevelSexto()
    {
        return new Level6();
    }

    protected override AbstractLevel getLevelSetimo()
    {
        return new Level7();
    }

    protected override AbstractLevel getLevelOitavo()
    {
        return new Level8();
    }

    protected override AbstractLevel getLevelNono()
    {
        return new Level1();
    }

    protected override AbstractLevel getLevelDecimo()
    {
        return new Level1();
    }
}
