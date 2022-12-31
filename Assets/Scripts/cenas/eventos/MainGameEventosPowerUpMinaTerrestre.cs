public class MainGameEventosPowerUpMinaTerrestre : AbstractMainGameEventosTutorial
{
    private TutorialPowerUpMinaTerrestre tutorial;

    public MainGameEventosPowerUpMinaTerrestre(AllGameManagers allGameManagers, TutorialPowerUpMinaTerrestre tutorial)
        :base(allGameManagers)
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
