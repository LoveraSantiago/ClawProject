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
            {5, 3, 3, 3, 3, 3, 3},
            {2, 5, 2, 2, 2, 2, -1},
            {1, 1, 1, 5, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }   
}
