public class ChallengeMemoriaComMaxDevolucao : Challenge
{
    private int qtdErrosEsperado;

    public ChallengeMemoriaComMaxDevolucao(AbstractLevelOvo abstractLevelOvo, int qtdErrosEsperado)
    {
        this.qtdErrosEsperado = qtdErrosEsperado;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Cometa ate " + qtdErrosEsperado.ToString() +" erros ao adivinhar as combinacoes");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return resultadoLevelsDto.resultadosColetaveis.coletaveisDevolvidos.listaDeTrincaDeDescartados.Count <= qtdErrosEsperado;
    }
}
