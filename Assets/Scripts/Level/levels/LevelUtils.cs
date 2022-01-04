public class LevelUtils 
{
    public static AbstractLevel loadLevelEscolhido(Level levelDefault)
    {
        Level levelFlow = PlayerPrefsLevel.recuperarELimparLevel(levelDefault);
        AbstractLevel levelEscolhido = LevelHelper.getLevelByEnum(levelFlow);
        return levelEscolhido;
    }

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
        return isCacaNiquelGeralLevel(level) ||
            isCacaNiquelSingleLevel(level);        
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

    public static bool isCacaNiquelGeralLevel(AbstractLevel level)
    {
        return level.getTipoGame() == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_GERAL;        
    }

    public static bool isCacaNiquelSingleLevel(AbstractLevel level)
    {
        return level.getTipoGame() == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL;
    }

    public static ColetavelEntidade getColetavelFromLevelColetavel(AbstractLevel level)
    {
        int id = ((AbstractLevelColetavel)level).getIdColetavel();
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        ColetavelEntidade coletavelEntidade = helperColetavel.getColetavelEntidadeById(id);
        return coletavelEntidade;
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
