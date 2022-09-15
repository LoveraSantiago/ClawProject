public class FrutasColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(10, 1),
            new ColetavelEntidade(11, 2),
            new ColetavelEntidade(12, 3),
            new ColetavelEntidade(13, 4),
            new ColetavelEntidade(14, 5),
            new ColetavelEntidade(15, 6),
            new ColetavelEntidade(16, 7),
            new ColetavelEntidade(17, 8)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        switch (coletavelEntidade.id)
        {
            case 10: return new LevelLeite(); 
            case 11: return new LevelMaca();
            case 12: return new LevelLaranja();
            case 13: return new LevelPao();
            case 14: return new LevelAspargo(); 
            case 15: return new LevelCoco();
            case 16: return new LevelEstrelaMarinha();
        }
        return null;
    }
}
