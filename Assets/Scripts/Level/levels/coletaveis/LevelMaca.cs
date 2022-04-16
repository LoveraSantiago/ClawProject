public class LevelMaca : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {13, 12, 15, 11, 14, 14, 15},
            {0, 16, 11, 11, 13, 0, 0},
            {0, 0, 10, 10, 12, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 11;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorMaca();
    }    

    public class FornecedorMaca : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelMaca();
        }
    }

}
