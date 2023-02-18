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
            {3, 2, 5, 1, 4, 4, 5},
            {0, 6, 1, 1, 3, 0, -1},
            {-1, -1, 0, 0, 2, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }    
}
