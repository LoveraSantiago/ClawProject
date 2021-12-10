public class LevelUtils 
{
    public static int[,] getArrayDeColetaveisLevelElevador(AbstractLevel level)
    {
        if (level.isElevadorLevel())
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
        if (level.isOrdemLevel())
        {
            return ((AbstractLevelOrdem)level).getBoardOrdem();
        }
        else
        {
            return null;
        }
    }
}
