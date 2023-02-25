public class LevelAbobora : AbstractLevelColetavel
{
    public LevelAbobora() : base(new MaquinaCorAzulEVerdesBrincantes()){}

    public override string getLevelTitle()
    {
        return "Level Abobora";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {0, 1, 2, 7, 3, 4, 5},
             {5, 4, 3, 2, 1, 0, -1},
            {-1, -1, 7, -1, 7, -1, -1},
             {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        return new PowerUpsParaLevel(1)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MOLA });
    }
}
