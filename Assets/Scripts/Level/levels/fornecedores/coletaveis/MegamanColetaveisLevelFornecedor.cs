public class MegamanColetaveisLevelFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(80, 50, "Kalinka", "kalinka", MapaEnum.MEGAMAN),
            new ColetavelEntidade(81, 51, "Megaman", "megaman", MapaEnum.MEGAMAN),
            new ColetavelEntidade(82, 52, "Tadashi", "tadashi", MapaEnum.MEGAMAN)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
