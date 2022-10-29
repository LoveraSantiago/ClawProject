public class ChallengeSubidasDaGarraMenorQueColetaveis : Challenge
{
    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Finalize o level com menos subidas da garra do que o total de coletaveis");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.subidasDaGarra < resultadoLevelsDto.resultadosColetaveis.totalColetaveisDescartados;
    }
}
