public class MainGameEventosTutorialLevel1 : AbstractMainGameEventosTutorial
{
    private TutorialLevel1 tutorial;

    public MainGameEventosTutorialLevel1(AllGameManagers allGameManagers, TutorialLevel1 tutorial)
        : base(allGameManagers)
    {
        this.tutorial = tutorial;
    }

    public override void iniciar()
    {
        tutorial.iniciar();
    }

    protected override AcaoColetadoFim configurarAcaoColetadoFim()
    {
        AcaoColetadoFim acaoColetadoFim = base.configurarAcaoColetadoFim();
        acaoColetadoFim.adicionarConsumidor(tutorial);
        return acaoColetadoFim;
    }     
}
