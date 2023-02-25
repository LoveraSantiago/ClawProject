public class LevelCoco : AbstractLevelColetavel
{
    public LevelCoco() : base(new MaquinaCorFrescorEnergetica()){}

    public override string getLevelTitle()
    {
        return "Level Coco";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {0, 1, 2, 5, 3, 4, 6},
             {5, 6, 4, 0, 1, 5, -1},
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
        return new PowerUpsParaLevel(1)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.TELEPORTE });
    }
}
