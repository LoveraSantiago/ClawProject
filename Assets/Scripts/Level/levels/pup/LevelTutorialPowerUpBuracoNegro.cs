public class LevelTutorialPowerUpBuracoNegro : AbstractLevelTutorialPowerUp
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            { 4, -1,  4,  4, -1, -1,  4},
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BURACO_NEGRO })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BURACO_NEGRO });
    }

    public override AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        TutorialPowerUpBuracoNegro tutorial = new TutorialPowerUpBuracoNegro(allGameManagers, mainDto);
        return new MainGameEventosPowerUp(allGameManagers, tutorial);
    }
}
