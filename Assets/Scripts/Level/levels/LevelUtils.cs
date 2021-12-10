public class LevelUtils 
{
    public static bool isNormalLevel(AbstractLevel level)
    {
        return level.getTipoGame() == AbstractLevel.TIPO_GAME.NORMAL;
    }

    public static bool isElevadorLevel(AbstractLevel level)
    {
        return level.getTipoGame() == AbstractLevel.TIPO_GAME.ELEVADOR;
    }

    public static bool isColetavelLevel(AbstractLevel level)
    {
        return level.getTipoGame() == AbstractLevel.TIPO_GAME.COLETAVEL;
    }

    public static bool isCacaNiquelLevel(AbstractLevel level)
    {
        AbstractLevel.TIPO_GAME tipoGame = level.getTipoGame();
        return tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_GERAL ||
               tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL;
    }

    public static bool isPupLevel(AbstractLevel level)
    {
        return level.getTipoGame() == AbstractLevel.TIPO_GAME.PUP;
    }

    public static bool isOrdemLevel(AbstractLevel level)
    {
        return level.getTipoGame() == AbstractLevel.TIPO_GAME.ORDENADO;
    }

    public static bool isLevelDeDestaque(AbstractLevel level)
    {
        return isColetavelLevel(level) || isOrdemLevel(level);
    }

    public static bool isCacaNiquelLevel(string desc)
    {
        return isCacaNiquelGeralLevel(desc) ||
               isCacaNiquelSingleLevel(desc);
    }

    public static bool isCacaNiquelGeralLevel(string desc)
    {
        return AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_GERAL.ToString().Equals(desc);
    }

    public static bool isCacaNiquelSingleLevel(string desc)
    {
        return AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL.ToString().Equals(desc);
    }

    public static int[,] getArrayDeColetaveisLevelElevador(AbstractLevel level)
    {
        if (isElevadorLevel(level))
        {
            return ((AbstractLevelElevador)level).getArrayDeColetaveisSub();
        }
        else
        {
            return null;
        }
    }

    public static BoardOrdem[] getBoardOrdensFromLevelOrdenado(AbstractLevel level)
    {
        if (isOrdemLevel(level))
        {
            return ((AbstractLevelOrdem)level).getBoardOrdem();
        }
        else
        {
            return null;
        }
    }
}
