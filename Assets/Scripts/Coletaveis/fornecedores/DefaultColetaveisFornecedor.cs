public class DefaultColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(0, -1, "vazio" , "tile-vazio"      , MapaEnum.DEFAULTS),
            new ColetavelEntidade(1, -1, "random", "tile-random"     , MapaEnum.DEFAULTS),
            new ColetavelEntidade(2, -1, "ovo"   , "capsula-completa", MapaEnum.DEFAULTS),
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
