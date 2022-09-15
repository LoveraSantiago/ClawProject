public class GeleiaColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "geleia";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(60, 36),
            new ColetavelEntidade(61, 37),
            new ColetavelEntidade(62, 38),
            new ColetavelEntidade(63, 39),
            new ColetavelEntidade(64, 40),
            new ColetavelEntidade(65, 41),
            new ColetavelEntidade(66, 42),
            new ColetavelEntidade(67, 43),
            new ColetavelEntidade(68, 44)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }    
}
