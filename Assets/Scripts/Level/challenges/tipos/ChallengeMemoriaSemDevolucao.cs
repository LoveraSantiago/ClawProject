public class ChallengeMemoriaSemDevolucao : Challenge
{
    public ChallengeMemoriaSemDevolucao(AbstractLevelOvo abstractLevelOvo)
    {
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Nao cometa nenhum erro ao adivinhar as combinacoes");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.resultadosColetaveis.coletaveisDevolvidos.listaDeTrincaDeDescartados.Count == 0;
    }
}
