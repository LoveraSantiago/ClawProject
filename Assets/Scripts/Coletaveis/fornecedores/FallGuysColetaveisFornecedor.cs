public class FallGuysColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[]{
            new ColetavelEntidade(40, 23, "FG1", "fg1", MapaEnum.FALLGUYS),
            new ColetavelEntidade(41, 24, "FG2", "fg2", MapaEnum.FALLGUYS),
            new ColetavelEntidade(42, 25, "FG3", "fg3", MapaEnum.FALLGUYS),
            new ColetavelEntidade(43, 26, "FG4", "fg4", MapaEnum.FALLGUYS),
            new ColetavelEntidade(44, 27, "FG5", "fg5", MapaEnum.FALLGUYS),
            new ColetavelEntidade(45, 28, "FG6", "fg6", MapaEnum.FALLGUYS),
            new ColetavelEntidade(46, 29, "FG7", "fg7", MapaEnum.FALLGUYS),
            new ColetavelEntidade(47, 30, "FG8", "fg8", MapaEnum.FALLGUYS),
            new ColetavelEntidade(48, 31, "FG9", "fg9", MapaEnum.FALLGUYS),
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
