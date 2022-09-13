public class PoopColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "poops";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(100, 62, "Poop 1",  "poop1"),
            new ColetavelEntidade(101, 63, "Poop 2",  "poop2"),
            new ColetavelEntidade(102, 64, "Poop 3",  "poop3"),
            new ColetavelEntidade(103, 65, "Poop 4",  "poop4"),
            new ColetavelEntidade(104, 66, "Poop 5",  "poop5"),
            new ColetavelEntidade(105, 67, "Poop 6",  "poop6"),
            new ColetavelEntidade(106, 68, "Poop 7",  "poop7"),
            new ColetavelEntidade(107, 69, "Poop 8",  "poop8"),
            new ColetavelEntidade(108, 70, "Poop 9",  "poop9"),
            new ColetavelEntidade(109, 71, "Poop 10", "poop10")
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
