public class LevelTutorialPowerUpIgual : AbstractLevelTutorialPowerUp
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {-1, -1,  0, -1, -1,  1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        return new PowerUpsParaLevel(2)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.IGUAL })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.IGUAL });
    }

    public override AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        TutorialPowerUpIgual tutorial = new TutorialPowerUpIgual(allGameManagers, mainDto);
        return new MainGameEventosPowerUp(allGameManagers, tutorial);
    }
}
