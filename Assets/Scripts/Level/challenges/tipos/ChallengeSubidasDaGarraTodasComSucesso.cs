public class ChallengeSubidasDaGarraTodasComSucesso : Challenge
{    
    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Todas as descidas da garra devem coletar");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.subidasDaGarra < resultadoLevelsDto.resultadosColetaveis.totalColetaveis;
    }
}
