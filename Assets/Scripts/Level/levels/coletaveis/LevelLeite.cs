public class LevelLeite : AbstractLevelColetavel
{
    public LevelLeite() : base(new MaquinaCorChocolateComMorango()){}

    public override string getLevelTitle()
    {
        return "Level Leite";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {0, 0, 0, 1, 2, 3, 4},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }    

}
