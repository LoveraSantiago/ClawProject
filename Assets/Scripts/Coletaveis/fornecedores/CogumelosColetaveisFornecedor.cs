public class CogumelosColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(90, 53, "Congumelo1", "cogumelo1", MapaEnum.COGUMELOS),
            new ColetavelEntidade(91, 54, "Congumelo2", "cogumelo2", MapaEnum.COGUMELOS),
            new ColetavelEntidade(92, 55, "Congumelo3", "cogumelo3", MapaEnum.COGUMELOS),
            new ColetavelEntidade(93, 56, "Congumelo4", "cogumelo4", MapaEnum.COGUMELOS),
            new ColetavelEntidade(94, 57, "Congumelo5", "cogumelo5", MapaEnum.COGUMELOS),
            new ColetavelEntidade(95, 58, "Congumelo6", "cogumelo6", MapaEnum.COGUMELOS),
            new ColetavelEntidade(96, 59, "Congumelo7", "cogumelo7", MapaEnum.COGUMELOS),
            new ColetavelEntidade(97, 60, "Congumelo8", "cogumelo8", MapaEnum.COGUMELOS),
            new ColetavelEntidade(98, 61, "Congumelo9", "cogumelo9", MapaEnum.COGUMELOS)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
