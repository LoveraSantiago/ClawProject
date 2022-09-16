public class DinosColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(20, 9),
            new ColetavelEntidade(21, 10),
            new ColetavelEntidade(22, 11),
            new ColetavelEntidade(23, 12),
            new ColetavelEntidade(24, 13)
        };
    }

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        return null;
    }
}
