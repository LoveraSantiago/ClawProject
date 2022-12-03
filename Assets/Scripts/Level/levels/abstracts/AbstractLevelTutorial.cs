public abstract class AbstractLevelTutorial : AbstractLevel
{
    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL;
    }
    
    public abstract AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto);

    public abstract int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo);

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeLevelCompleto("Aprenda seguindo o tutorial"),
            new ChallengeLevelCompleto("Ative um power up"),
            new ChallengeLevelCompleto("Se divertir completamente")
        };
    }
}
