public class ContextoEstaticoLevels 
{
    private int indiceLevelAtual;

    public void receberIndiceLevelAtual(int indiceLevelAtual)
    {
        this.indiceLevelAtual = indiceLevelAtual;
    }

    public void salvarLevelAtual()
    {
        PlayerPrefsMapas.salvarIndiceLevelLiberado(indiceLevelAtual + 1);
    }
}
