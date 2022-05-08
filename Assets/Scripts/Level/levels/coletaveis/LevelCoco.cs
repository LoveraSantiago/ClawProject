public class LevelCoco : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {15, 13, 13, 13, 13, 13, 13},
            {12, 15, 12, 12, 12, 12, 0},
            {11, 11, 11, 15, 11, 11, 11},
            {10, 10, 10, 10, 10, 10, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 15;
    }

    public override bool isLevelAlbedo0Timers()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorCoco();
    }    

    public class FornecedorCoco : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelCoco();
        }
    }
}
