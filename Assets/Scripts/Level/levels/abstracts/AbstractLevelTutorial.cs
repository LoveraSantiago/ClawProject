public abstract class AbstractLevelTutorial : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL;
    }

    public abstract Tutorial getTutorial();
}
