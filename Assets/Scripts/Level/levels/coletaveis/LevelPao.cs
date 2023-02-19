public class LevelPao : AbstractLevelColetavel
{
    public LevelPao() : base(new MaquinaCorVibrantePrimaria()){}

    public override string getLevelTitle()
    {
        return "Level Pao";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {3, 1, 2, 3, 4, 5, 3},
            {6, 5, 4, 2, 1, 0, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };        
    }  
}
