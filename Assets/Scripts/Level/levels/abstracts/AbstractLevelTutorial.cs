public abstract class AbstractLevelTutorial : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL;
    }
    
    public abstract MainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto);

    public abstract int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo);
}
