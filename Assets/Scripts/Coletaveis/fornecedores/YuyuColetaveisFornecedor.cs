public class YuyuColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(50, 32, "Yusuke"  , "hiei"    , MapaEnum.YUYU),
            new ColetavelEntidade(51, 33, "Kuwabara", "kurama"  , MapaEnum.YUYU),
            new ColetavelEntidade(52, 34, "Hiei"    , "kuwabara", MapaEnum.YUYU),
            new ColetavelEntidade(53, 35, "Kurama"  , "yusuke"  , MapaEnum.YUYU),
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
