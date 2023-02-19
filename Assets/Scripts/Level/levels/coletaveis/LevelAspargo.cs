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
            {6, 6, 6, 6, 6, 6, 4},
            {6, 6, 6, 6, 6, 4, -1},
            {6, 6, 6, 6, 6, 4, 6},
            {6, 6, 6, 6, 6, 6, 0},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }      
}
