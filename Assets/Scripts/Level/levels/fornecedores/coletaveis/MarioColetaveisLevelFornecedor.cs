public class MarioColetaveisLevelFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(70, 45, "Kopa"    , "kopa"    , MapaEnum.MARIO),
            new ColetavelEntidade(71, 46, "Luigi"   , "luigi"   , MapaEnum.MARIO),
            new ColetavelEntidade(72, 47, "Mario"   , "mario"   , MapaEnum.MARIO),
            new ColetavelEntidade(73, 48, "Princesa", "princesa", MapaEnum.MARIO),
            new ColetavelEntidade(74, 49, "Todi"    , "todi"    , MapaEnum.MARIO)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
