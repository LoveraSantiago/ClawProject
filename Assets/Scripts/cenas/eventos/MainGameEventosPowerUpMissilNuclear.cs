public class MainGameEventosPowerUpMissilNuclear : AbstractMainGameEventosTutorial
{
    private TutorialPowerUpMissilNuclear tutorial;

    public MainGameEventosPowerUpMissilNuclear(AllGameManagers allGameManagers, TutorialPowerUpMissilNuclear tutorial)
        : base(allGameManagers)
    {
        this.tutorial = tutorial;
    }

    public override void iniciar()
    {
        tutorial.iniciar();
    }

    protected override AcaoPowerUpAcionado configurarAcaoPowerUpAcionado()
    {
        AcaoPowerUpAcionado acaoPowerUpAcionado = base.configurarAcaoPowerUpAcionado();
        acaoPowerUpAcionado.adicionarConsumidor(tutorial);
        return acaoPowerUpAcionado;
    }

    protected override AcaoColetado configurarAcaoColetado()
    {
        AcaoColetado acaoColetado = base.configurarAcaoColetado();

        AcaoColetado acaoColetadoTutorial = new AcaoColetado();
        acaoColetadoTutorial.configurarProdutor(tutorial)
            .adicionarConsumidor(allGameManagers.getModalResultadosManager());

        return acaoColetado;
    }
}
