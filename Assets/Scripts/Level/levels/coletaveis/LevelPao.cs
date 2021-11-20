public class LevelPao : LevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {13, 11, 12, 13, 14, 15, 13},
            {16, 15, 14, 12, 11, 10, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };        
    }

    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorPao();
    }

    public class FornecedorPao : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelPao();
        }
    }
}
