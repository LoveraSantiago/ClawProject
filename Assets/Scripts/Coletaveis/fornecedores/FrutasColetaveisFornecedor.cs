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

    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        switch (indice)
        {
            case 0: return new LevelLeite(); 
            case 1: return new LevelMaca();
            case 2: return new LevelLaranja();
            case 3: return new LevelPao();
            case 4: return new LevelAspargo(); 
            case 5: return new LevelCoco();
            case 6: return new LevelEstrelaMarinha();
        }
        return null;
    }
}
