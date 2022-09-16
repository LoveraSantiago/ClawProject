public class FallGuysColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[]{
            new ColetavelEntidade(40, 23),
            new ColetavelEntidade(41, 24),
            new ColetavelEntidade(42, 25),
            new ColetavelEntidade(43, 26),
            new ColetavelEntidade(44, 27),
            new ColetavelEntidade(45, 28),
            new ColetavelEntidade(46, 29),
            new ColetavelEntidade(47, 30),
            new ColetavelEntidade(48, 31),
        };
    }

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        return null;
    }
}
