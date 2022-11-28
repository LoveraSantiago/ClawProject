public abstract class AbstractLevelTutorial : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL;
    }
    
    public abstract MainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers);

    public abstract int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo);
}
