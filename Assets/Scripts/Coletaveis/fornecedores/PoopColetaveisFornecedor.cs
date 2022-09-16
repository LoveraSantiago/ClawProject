public class PoopColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{   
    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(100, 62),
            new ColetavelEntidade(101, 63),
            new ColetavelEntidade(102, 64),
            new ColetavelEntidade(103, 65),
            new ColetavelEntidade(104, 66),
            new ColetavelEntidade(105, 67),
            new ColetavelEntidade(106, 68),
            new ColetavelEntidade(107, 69),
            new ColetavelEntidade(108, 70),
            new ColetavelEntidade(109, 71)
        };
    }

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        return null;
    }
}
