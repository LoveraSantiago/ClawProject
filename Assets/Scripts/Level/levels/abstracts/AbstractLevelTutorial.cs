public abstract class AbstractLevelTutorial : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL;
    }

    public abstract Tutorial getTutorial();

    public abstract int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo);
}
