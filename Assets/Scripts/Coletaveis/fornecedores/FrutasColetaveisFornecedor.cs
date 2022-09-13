public class FrutasColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "frutas";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(10, 1, "Leite"          , "characters_0001"),
            new ColetavelEntidade(11, 2, "Maca"           , "characters_0002"),
            new ColetavelEntidade(12, 3, "Laranja"        , "characters_0003"),
            new ColetavelEntidade(13, 4, "Pao"            , "characters_0004"),
            new ColetavelEntidade(14, 5, "Aspargo"        , "characters_0005"),
            new ColetavelEntidade(15, 6, "Coco"           , "characters_0006"),
            new ColetavelEntidade(16, 7, "Estrela Marinha", "characters_0007"),
            new ColetavelEntidade(17, 8, "Abobora"        , "aboborav3"      )
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
