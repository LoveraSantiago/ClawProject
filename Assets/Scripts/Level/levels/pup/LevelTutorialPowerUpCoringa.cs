public class LevelTutorialPowerUpCoringa : AbstractLevelTutorialPowerUp
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.CORINGA })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.CORINGA });
    }

    public override AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        TutorialPowerUpCoringa tutorial = new TutorialPowerUpCoringa(allGameManagers, mainDto);
        return new MainGameEventosPowerUp(allGameManagers, tutorial);
    }
}
