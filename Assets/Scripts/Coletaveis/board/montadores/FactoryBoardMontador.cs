using UnityEngine;

public class FactoryBoardMontador 
{
    public static BoardMontador getMontadorByLevel(GameObject goParent)
    {
        BoardMontador montador = null;
        if (LevelUtils.isNormalLevel())
        {
            montador = new BoardMontadorNormal();
        }
        else if (LevelUtils.isObstaculoLevel())
        {
            montador = new BoardMontadorObstaculos();
        }
        else if (LevelUtils.isOvoLevel())
        {
            montador = new BoardMontadorOvo();
        }
        else if (LevelUtils.isElevadorLevel())
        {
            montador = new BoardMontadorElevadorNormal(goParent);
        }
        else
        {
            montador = new BoardMontadorNormal();
        }
        
        montador.configuradoPeloLevel();
        return montador;
    }

    public static BoardMontador getMontadorExtraByLevel(GameObject goParent)
    {
        BoardMontador montadorExtra = null;
        if (LevelUtils.isElevadorLevel())
        {
            montadorExtra = new BoardMontadorExtra(goParent);
        }
        else
        {
            montadorExtra = new BoardMontadorVazio();
        }
        montadorExtra.configuradoPeloLevel();
        return montadorExtra;
    }
}
