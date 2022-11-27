public abstract class AbstractLevelTutorial : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL;
    }
    
    public abstract MainGameEventosTutorial getMainGameEventos(MainGameManagers mainGameManagers);

    public abstract int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo);
}
