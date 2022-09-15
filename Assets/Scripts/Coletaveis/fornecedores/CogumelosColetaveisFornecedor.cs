public class CogumelosColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "cogumelos";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(90, 53),
            new ColetavelEntidade(91, 54),
            new ColetavelEntidade(92, 55),
            new ColetavelEntidade(93, 56),
            new ColetavelEntidade(94, 57),
            new ColetavelEntidade(95, 58),
            new ColetavelEntidade(96, 59),
            new ColetavelEntidade(97, 60),
            new ColetavelEntidade(98, 61)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
