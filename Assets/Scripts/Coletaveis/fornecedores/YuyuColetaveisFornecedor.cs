public class YuyuColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "yuyu";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(50, 32, "Yusuke"  , "hiei"    ),
            new ColetavelEntidade(51, 33, "Kuwabara", "kurama"  ),
            new ColetavelEntidade(52, 34, "Hiei"    , "kuwabara"),
            new ColetavelEntidade(53, 35, "Kurama"  , "yusuke"  ),
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
