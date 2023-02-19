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
            {5, 5, 2, 2, 2, 5, 5},
            {1, 1, 1, 1, 1, 1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }    
}
