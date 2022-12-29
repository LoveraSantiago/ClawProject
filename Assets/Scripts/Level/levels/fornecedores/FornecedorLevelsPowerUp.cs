public class FornecedorLevelsPowerUp : AbstractFornecedorLevels
{
    public override AbstractLevel getLevelByIndiceDezena(int idMapa, int indice)
    {
        return getLevelPorIndice(indice);
    }

    protected override AbstractLevel getLevelPorIndice(int level)
    {
        switch (level)
        {
            case 0: return new LevelTutorialPupBomba();
            case 1: return new LevelTutorialPupMissilNuclear();
            case 2: return new LevelPowerUp();
        }
        return null;
    }

    public override int getQtdLevels()
    {
        return 1;
    }
}
