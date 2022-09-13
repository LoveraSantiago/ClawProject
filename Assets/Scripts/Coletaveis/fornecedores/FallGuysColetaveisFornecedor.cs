public class FallGuysColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "fg";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[]{
            new ColetavelEntidade(40, 23, "FG1", "fg1"),
            new ColetavelEntidade(41, 24, "FG2", "fg2"),
            new ColetavelEntidade(42, 25, "FG3", "fg3"),
            new ColetavelEntidade(43, 26, "FG4", "fg4"),
            new ColetavelEntidade(44, 27, "FG5", "fg5"),
            new ColetavelEntidade(45, 28, "FG6", "fg6"),
            new ColetavelEntidade(46, 29, "FG7", "fg7"),
            new ColetavelEntidade(47, 30, "FG8", "fg8"),
            new ColetavelEntidade(48, 31, "FG9", "fg9"),
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
