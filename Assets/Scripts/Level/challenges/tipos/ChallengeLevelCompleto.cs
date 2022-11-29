public class ChallengeLevelCompleto : Challenge
{
    private string texto;

    public ChallengeLevelCompleto()
    {
        texto = "Colete todos os itens";
    }

    public ChallengeLevelCompleto(string texto)
    {
        this.texto = texto;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel(texto);
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return true;
    }
}
