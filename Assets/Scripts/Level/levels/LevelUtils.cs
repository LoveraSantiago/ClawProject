public class LevelUtils 
{
    public static readonly string MSG_COLETAR_ITENS = "Colete todos os itens.";
    public static readonly string MSG_TEMPO         = "Colete os itens antes do tempo acabar.";
    public static readonly string MSG_ELEVADOR      = "Colete os itens antes do elevador subir.";
    public static readonly string MSG_ORDENADO      = "Colete seguindo a ordenação.";
    public static readonly string MSG_OBSTACULOS    = "Colete apesar dos obstaculos.";
    public static readonly string MSG_MEMORIA       = "Colete memorizando as posições.";
    public static readonly string TIMER_ZERO        = "00:00";


    public static bool isNormalLevel()
    {
        return ContextoEstaticoUtils.level.getTipoGame() == TipoGame.NORMAL;
    }

    public static bool isElevadorLevel()
    {
        return isElevadorLevel(ContextoEstaticoUtils.level);
    }

    public static bool isElevadorLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.ELEVADOR;
    }

    public static bool isColetavelLevel()
    {
        return ContextoEstaticoUtils.level.getTipoGame() == TipoGame.COLETAVEL;
    }

    public static bool isCacaNiquelLevel()
    {
        AbstractLevel level = ContextoEstaticoUtils.level;
        return isCacaNiquelGeralLevel() ||
               isCacaNiquelSingleLevel(level);        
    }

    public static bool isPupLevel()
    {
        return ContextoEstaticoUtils.level.getTipoGame() == TipoGame.PUP;
    }

    public static bool isOrdemLevel()
    {
        return isOrdemLevel(ContextoEstaticoUtils.level);
    }

    public static bool isOrdemLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.ORDENADO;
    }

    public static bool isLevelDeDestaque()
    {        
        return isColetavelLevel() || isOrdemLevel();
    }    

    public static bool isCacaNiquelGeralLevel()
    {
        return ContextoEstaticoUtils.level.getTipoGame() == TipoGame.CACANIQUEL_PUP_GERAL;        
    }

    public static bool isCacaNiquelSingleLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.CACANIQUEL_PUP_INDIVIDUAL;
    }

    public static bool isObstaculoLevel()
    {
        return isObstaculoLevel(ContextoEstaticoUtils.level);
    }

    public static bool isObstaculoLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.OBSTACULO;
    }

    public static bool isPlayableLevel()
    {
        AbstractLevel level = ContextoEstaticoUtils.level;
        return isNormalLevel() || isOrdemLevel() ||
               isObstaculoLevel(level) || isElevadorLevel(level) || 
               isOvoLevel(level) || isTutorialLevel();
    }

    public static bool isOvoLevel()
    {
        return isOvoLevel(ContextoEstaticoUtils.level);
    }

    public static bool isOvoLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.MEMORIA;
    }

    public static bool isTutorialLevel()
    {
        return ContextoEstaticoUtils.level.getTipoGame() == TipoGame.TUTORIAL;
    }

    public static ColetavelEntidade getColetavelFromLevelColetavel()
    {
        return ((AbstractLevelColetavel)ContextoEstaticoUtils.level).coletavelEntidade;        
    }

    public static int[,] getArrayDeColetaveisLevelElevador()
    {
        AbstractLevel level = ContextoEstaticoUtils.level;
        if (isElevadorLevel(level))
        {
            return ((AbstractLevelElevador)level).getArrayDeColetaveisSub();
        }
        else
        {
            return null;
        }
    }

    public static BoardOrdem[] getBoardOrdensFromLevelOrdenado()
    {
        return getBoardOrdensFromLevelOrdenado(ContextoEstaticoUtils.level);
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

    public static bool[,] getArrayDeObstaculos()
    {
        return getArrayDeObstaculos(ContextoEstaticoUtils.level);
    }

    public static bool[,] getArrayDeObstaculos(AbstractLevel level)
    {
        if (isObstaculoLevel(level))
        {
            return ((AbstractLevelObstaculos)level).getArrayDeObstaculos();
        }
        else
        {
            return null;
        }
    }   

    public static MainGameEventosTutorial getMainGameEventosTutorial(AbstractLevel level, AllGameManagers allGameManagers)
    {
        return ((AbstractLevelTutorial)level).getMainGameEventos(allGameManagers);
    }
}
