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
        throw new System.NotImplementedException();
    }
}
