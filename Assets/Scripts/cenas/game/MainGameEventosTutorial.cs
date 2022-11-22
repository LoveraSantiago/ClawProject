public class MainGameEventosTutorial : MainGameEventos
{
    private Tutorial tutorial;

    public MainGameEventosTutorial(MainGameManagers mainGameManagers, Tutorial tutorial)
        :base(mainGameManagers)
    {
        this.tutorial = tutorial;
    }

    protected override AcaoColetadoFim configurarAcaoColetadoFim()
    {
        AcaoColetadoFim acaoColetadoFim = base.configurarAcaoColetadoFim();
        acaoColetadoFim.adicionarConsumidor(tutorial);
        return acaoColetadoFim;
    }
}
