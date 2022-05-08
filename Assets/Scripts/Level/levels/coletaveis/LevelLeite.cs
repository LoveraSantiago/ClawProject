public class LevelLeite : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {10, 10, 10, 11, 12, 13, 14},
            {13, 14, 15, 16, 16, 15, 0},
            {12, 11, 12, 13, 14, 15, 16},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 10;
    }

    public override bool isLevelAlbedo0Timers()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLeite();
    }
    
    public class FornecedorLeite : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelLeite();
        }
    }

}
