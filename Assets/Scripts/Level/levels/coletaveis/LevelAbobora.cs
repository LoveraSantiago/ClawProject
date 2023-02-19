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
            {0, 0, 0, 1, 2, 3, 4},
            {3, 4, 5, 6, 6, 5, -1},
            {2, 1, 2, 3, 4, 5, 6},
            {-1, 7, 7, 7, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }        
}
