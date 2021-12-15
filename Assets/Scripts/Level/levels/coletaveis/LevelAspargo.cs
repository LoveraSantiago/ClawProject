public class LevelAspargo : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {16, 16, 16, 16, 16, 16, 14},
            {16, 16, 16, 16, 16, 14, 0},
            {16, 16, 16, 16, 16, 14, 16},
            {16, 16, 16, 16, 16, 16, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 14;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorAspargo();
    }
    
    public class FornecedorAspargo : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelAspargo();
        }
    }
}
