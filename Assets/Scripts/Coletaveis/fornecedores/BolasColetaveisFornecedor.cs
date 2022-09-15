public class BolasColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "bolas";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(30, 14),
            new ColetavelEntidade(31, 15),
            new ColetavelEntidade(32, 16),
            new ColetavelEntidade(33, 17),
            new ColetavelEntidade(34, 18),
            new ColetavelEntidade(35, 19),
            new ColetavelEntidade(36, 20),
            new ColetavelEntidade(37, 21),
            new ColetavelEntidade(38, 22)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
