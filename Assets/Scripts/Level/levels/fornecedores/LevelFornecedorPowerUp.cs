public class LevelFornecedorPowerUp : AbstractMapaLevelFornecedor
{
    public override AbstractLevel getLevelPorIndice(int level)
    {
        switch (level)
        {
            case 1: return new LevelPowerUp();
        }
        return null;
    }

    public override int getQtdLevels()
    {
        return 1;
    }
}
