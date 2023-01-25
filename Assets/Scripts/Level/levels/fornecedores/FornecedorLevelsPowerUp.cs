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
            case 0: return new LevelTutorialPowerUpBomba();
            case 1: return new LevelTutorialPowerUpMissilNuclear();
            case 2: return new LevelTutorialPowerUpMinaTerrestre();
            case 3: return new LevelTutorialPowerUpMissilTeleguiado();
            case 4: return new LevelTutorialPowerUpIgual();
            case 5: return new LevelTutorialPowerUpTeleporte();
            case 6: return new LevelTutorialPowerUpCoringa();
            case 7: return new LevelTutorialPowerUpMiniAsa();
            case 8: return new LevelPowerUp();
        }
        return null;
    }

    public override int getQtdLevels()
    {
        return 1;
    }
}
