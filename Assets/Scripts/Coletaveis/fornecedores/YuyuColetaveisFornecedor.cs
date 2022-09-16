public class YuyuColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(50, 32),
            new ColetavelEntidade(51, 33),
            new ColetavelEntidade(52, 34),
            new ColetavelEntidade(53, 35),
        };
    }

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        return null;
    }
}
