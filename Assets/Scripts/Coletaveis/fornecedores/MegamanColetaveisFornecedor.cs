public class MegamanColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(80, 50),
            new ColetavelEntidade(81, 51),
            new ColetavelEntidade(82, 52)
        };
    }

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        return null;
    }
}
