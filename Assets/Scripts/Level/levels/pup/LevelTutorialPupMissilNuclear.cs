public class LevelTutorialPupMissilNuclear : AbstractLevelTutorialPowerUp
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {0, 1, 2, 3, 2, 1, 0},
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MISSIL_NUCLEAR })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MISSIL_NUCLEAR });
    }

    public override AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        TutorialPowerUpMissilNuclear tutorial = new TutorialPowerUpMissilNuclear(allGameManagers, mainDto);
        return new MainGameEventosPowerUpMissilNuclear(allGameManagers, tutorial);
    }
}
