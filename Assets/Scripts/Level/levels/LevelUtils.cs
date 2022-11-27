public class LevelUtils 
{
    public static readonly string MSG_COLETAR_ITENS = "Colete todos os itens.";
    public static readonly string MSG_TEMPO         = "Colete os itens antes do tempo acabar.";
    public static readonly string MSG_ELEVADOR      = "Colete os itens antes do elevador subir.";
    public static readonly string MSG_ORDENADO      = "Colete seguindo a ordenação.";
    public static readonly string MSG_OBSTACULOS    = "Colete apesar dos obstaculos.";
    public static readonly string MSG_MEMORIA       = "Colete memorizando as posições.";
    public static readonly string TIMER_ZERO        = "00:00";


    public static bool isNormalLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.NORMAL;
    }

    public static bool isElevadorLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.ELEVADOR;
    }

    public static bool isColetavelLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.COLETAVEL;
    }

    public static bool isCacaNiquelLevel(AbstractLevel level)
    {
        return isCacaNiquelGeralLevel(level) ||
               isCacaNiquelSingleLevel(level);        
    }

    public static bool isPupLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.PUP;
    }

    public static bool isOrdemLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.ORDENADO;
    }

    public static bool isLevelDeDestaque(AbstractLevel level)
    {
        return isColetavelLevel(level) || isOrdemLevel(level);
    }    

    public static bool isCacaNiquelGeralLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.CACANIQUEL_PUP_GERAL;        
    }

    public static bool isCacaNiquelSingleLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.CACANIQUEL_PUP_INDIVIDUAL;
    }

    public static bool isObstaculoLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.OBSTACULO;
    }

    public static bool isPlayableLevel(AbstractLevel level)
    {
        return isNormalLevel(level) || isOrdemLevel(level) ||
               isObstaculoLevel(level) || isElevadorLevel(level) || 
               isOvoLevel(level) || isTutorialLevel(level);
    }

    public static bool isOvoLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.MEMORIA;
    }

    public static bool isTutorialLevel(AbstractLevel level)
    {
        return level.getTipoGame() == TipoGame.TUTORIAL;
    }

    public static ColetavelEntidade getColetavelFromLevelColetavel(AbstractLevel level)
    {
        return ((AbstractLevelColetavel)level).coletavelEntidade;        
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

    public static MainGameEventosTutorial getMainGameEventosTutorial(AbstractLevel level, MainGameManagers mainGameManagers)
    {
        return ((AbstractLevelTutorial)level).getMainGameEventos(mainGameManagers);
    }
}
