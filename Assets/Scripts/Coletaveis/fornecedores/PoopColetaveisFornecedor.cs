public class PoopColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(100, 62, "Poop 1",  "poop1", MapaEnum.POOPS),
            new ColetavelEntidade(101, 63, "Poop 2",  "poop2", MapaEnum.POOPS),
            new ColetavelEntidade(102, 64, "Poop 3",  "poop3", MapaEnum.POOPS),
            new ColetavelEntidade(103, 65, "Poop 4",  "poop4", MapaEnum.POOPS),
            new ColetavelEntidade(104, 66, "Poop 5",  "poop5", MapaEnum.POOPS),
            new ColetavelEntidade(105, 67, "Poop 6",  "poop6", MapaEnum.POOPS),
            new ColetavelEntidade(106, 68, "Poop 7",  "poop7", MapaEnum.POOPS),
            new ColetavelEntidade(107, 69, "Poop 8",  "poop8", MapaEnum.POOPS),
            new ColetavelEntidade(108, 70, "Poop 9",  "poop9", MapaEnum.POOPS),
            new ColetavelEntidade(109, 71, "Poop 10", "poop10", MapaEnum.POOPS)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
