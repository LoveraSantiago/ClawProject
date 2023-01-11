public class MainGameEventosPowerUpIgual : AbstractMainGameEventosTutorial
{    
    private TutorialPowerUpIgual tutorial;

    public MainGameEventosPowerUpIgual(AllGameManagers allGameManagers, TutorialPowerUpIgual tutorial)
        :base(allGameManagers)
    { 
        this.tutorial = tutorial;
    }

    public override void iniciar()
    {
        tutorial.iniciar();
    }
}
