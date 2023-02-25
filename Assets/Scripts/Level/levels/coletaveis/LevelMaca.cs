using System.Collections.Generic;

public class LevelMaca : AbstractLevelColetavel
{
    public LevelMaca() : base(new MaquinaCorBonitaRefrescante()){}

    public override string getLevelTitle()
    {
        return "Level Maca";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {0, 2, 3, 1, 4, 5, 6},
             {6, 1, 5, 2, 0, 1, -1},
            {3, -1, 4, -1, 5, -1, -1},
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.ASAS });
    }
}
