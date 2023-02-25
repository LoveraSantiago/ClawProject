public class LevelAspargo : AbstractLevelColetavel
{
    public LevelAspargo() : base(new MaquinaCorAreiaEMar()){}

    public override string getLevelTitle()
    {
        return "Level Aspargo";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {6, 6, 6, 6, 6, 6, 6},
             {-1, 6, 4, 4, 6, -1, -1},
            {-1, -1, 6, 4, 6, -1, -1},
             {-1, -1, 6, 6, -1, -1, 0},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        return new PowerUpsParaLevel(1)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MISSIL_NUCLEAR });
    }
}
