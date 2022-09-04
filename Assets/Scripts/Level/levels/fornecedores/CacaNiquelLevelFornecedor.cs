public class CacaNiquelLevelFornecedor : AbstractMapaLevelFornecedor
{
    public override AbstractLevel getLevelPorIndice(int level)
    {
        switch (level)
        {
            case 1: return new LevelCacaNiquelPowerUpGeral();
            case 2: return new LevelCacaNiquelPowerUpIndividual();
        }
        return null;
    }

    public override int getQtdLevels()
    {
        return 2;
    }
}
