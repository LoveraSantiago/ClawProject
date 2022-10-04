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

    public void salvarLevelAtual()
    {
        PlayerPrefsMapas.salvarIndiceLevelLiberado(indiceLevelAtual + 1);
    }
}
