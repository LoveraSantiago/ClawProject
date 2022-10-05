public class ContextoEstaticoLevels 
{
    private int indiceLevelAtual;
    private int challenge;

    public void addInfosParaLevelEmAndamento(int indiceLevelAtual, int challenge)
    {
        //Debug.Log("Level recebendo indice " + indiceLevelAtual);
        this.indiceLevelAtual = indiceLevelAtual;
        this.challenge        = challenge;
    }

    public int getChallenge()
    {
        return challenge;
    }

    public void salvarLevelAtual(int challenge)
    {
        this.challenge = challenge;
        PlayerPrefsMapas.salvarIndiceLevelLiberado(indiceLevelAtual + 1);
        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;
        PlayerPrefsMapas.salvarChallengeDoMapa(mapaEntidade, indiceLevelAtual - 1, challenge);
    }
}
