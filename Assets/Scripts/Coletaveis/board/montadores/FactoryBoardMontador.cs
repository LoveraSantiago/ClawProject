public class FactoryBoardMontador 
{
    public static BoardMontador getMontadorByLevel(AbstractLevel level)
    {
        BoardMontador montador = null;
        if (LevelUtils.isNormalLevel(level))
        {
            montador = new BoardMontadorNormal();
        }
        else if (LevelUtils.isObstaculoLevel(level))
        {
            montador = new BoardMontadorObstaculos();
        }
        else if (LevelUtils.isOvoLevel(level))
        {
            montador = new BoardMontadorOvo();
        }
        else
        {
            montador = new BoardMontadorNormal();
        }
        montador.configuradoPeloLevel(level);
        return montador;
    }

    public static BoardMontador getMontadorExtraByLevel(AbstractLevel level)
    {
        BoardMontador montadorExtra = null;
        if (LevelUtils.isElevadorLevel(level))
        {
            montadorExtra = new BoardMontadorExtra();
        }
        else
        {
            montadorExtra = new BoardMontadorVazio();
        }
        montadorExtra.configuradoPeloLevel(level);
        return montadorExtra;
    }
}
