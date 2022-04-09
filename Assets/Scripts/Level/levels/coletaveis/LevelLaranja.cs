public class LevelLaranja : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {15, 15, 12, 12, 12, 15, 15},
            {11, 11, 11, 11, 11, 11, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 12;
    }

    public override bool isAlbedo1()
    {
        return false;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLaranja();
    }   

    public class FornecedorLaranja : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelLaranja();
        }
    }
}
