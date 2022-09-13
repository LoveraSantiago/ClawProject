public class CogumelosColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "cogumelos";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(90, 53, "Congumelo1", "cogumelo1"),
            new ColetavelEntidade(91, 54, "Congumelo2", "cogumelo2"),
            new ColetavelEntidade(92, 55, "Congumelo3", "cogumelo3"),
            new ColetavelEntidade(93, 56, "Congumelo4", "cogumelo4"),
            new ColetavelEntidade(94, 57, "Congumelo5", "cogumelo5"),
            new ColetavelEntidade(95, 58, "Congumelo6", "cogumelo6"),
            new ColetavelEntidade(96, 59, "Congumelo7", "cogumelo7"),
            new ColetavelEntidade(97, 60, "Congumelo8", "cogumelo8"),
            new ColetavelEntidade(98, 61, "Congumelo9", "cogumelo9")
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
