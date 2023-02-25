public class LevelLaranja : AbstractLevelColetavel
{
    public LevelLaranja() : base(new MaquinaCorOutonoNatural()){}

    public override string getLevelTitle()
    {
        return "Level Laranja";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {5, 5, 5, 5, 5, 5, 5},
             {1, 1, 2, 2, 1, 1, -1},
            {-1, -1, 1, 2, 1, -1, -1},
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA });
    }
}
