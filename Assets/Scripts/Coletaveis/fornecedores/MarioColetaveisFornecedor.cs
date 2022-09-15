public class MarioColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
   protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(70, 45),
            new ColetavelEntidade(71, 46),
            new ColetavelEntidade(72, 47),
            new ColetavelEntidade(73, 48),
            new ColetavelEntidade(74, 49)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
