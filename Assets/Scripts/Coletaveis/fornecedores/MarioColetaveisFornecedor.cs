public class MarioColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "mario";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(70, 45, "Kopa"    , "kopa"    ),
            new ColetavelEntidade(71, 46, "Luigi"   , "luigi"   ),
            new ColetavelEntidade(72, 47, "Mario"   , "mario"   ),
            new ColetavelEntidade(73, 48, "Princesa", "princesa"),
            new ColetavelEntidade(74, 49, "Todi"    , "todi"    )
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
