public class LevelTutorialPowerUpMinaTerrestre : AbstractLevelTutorialPowerUp
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE });
    }

    public override AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        TutorialPowerUpMinaTerrestre tutorial = new TutorialPowerUpMinaTerrestre(allGameManagers, mainDto);
        return new MainGameEventosPowerUp(allGameManagers, tutorial);
    }
}
