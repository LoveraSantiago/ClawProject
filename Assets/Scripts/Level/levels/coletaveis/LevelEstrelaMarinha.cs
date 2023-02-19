public class LevelEstrelaMarinha : AbstractLevelColetavel
{
    public LevelEstrelaMarinha() : base(new MaquinaCorIcebergGelada()){}

    public override string getLevelTitle()
    {
        return "Level EstrelaMarinha";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]{
            {6, 5, 5, 5, 5, 5, 5},
            {4, 4, 4, 4, 4, 4, -1},
            {3, 3, 3, 3, 3, 3, 6},
            {2, 2, 2, 2, 2, 2, -1},
            {6, 1, 1, 1, 1, 1, 1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }          
}
