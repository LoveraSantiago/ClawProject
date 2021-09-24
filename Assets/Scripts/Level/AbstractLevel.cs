using System.Collections.Generic;

public abstract class AbstractLevel 
{
    protected enum TIPO_GAME { NORMAL, ORDENADO, PUP, CACANIQUEL_PUP_INDIVIDUAL, CACANIQUEL_PUP_GERAL }

    protected static readonly string TIMER_ZERO = "00:00";

    public abstract string getLevelName();

    public abstract string getMsgObjetivoLevel();

    public abstract GarraManager.MECANICA_GARRA getMecanicaDaGarra();

    public abstract bool devolverParaBoard();

    public abstract ColetavelEntidade.FAMILIA getFamiliaColetavel();

    public abstract int[,] getArrayDeColetaveis();

    public virtual int[,] getArrayDeColetaveisSub(){return null;}

    public string getTipoGameDesc()
    {
        return getTipoGame().ToString();
    }

    protected abstract TIPO_GAME getTipoGame();

    public abstract TipoContagemTempoDto getTempoContagem();

    public abstract Dictionary<string, string> getDicionarioDeCores();   

    public void validar()
    {

    }

    public bool isCacaNiquelLevel()
    {
        TIPO_GAME tipoGame = getTipoGame();
        return tipoGame == TIPO_GAME.CACANIQUEL_PUP_GERAL || 
               tipoGame == TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL;
    }

    public bool isPupLevel()
    {
        return getTipoGame() == TIPO_GAME.PUP;
    }

    public static bool isCacaNiquelLevel(string desc)
    {
        return isCacaNiquelGeralLevel(desc) ||
               isCacaNiquelSingleLevel(desc);
    }

    public static bool isCacaNiquelGeralLevel(string desc)
    {
        return TIPO_GAME.CACANIQUEL_PUP_GERAL.ToString().Equals(desc);
    }

    public static bool isCacaNiquelSingleLevel(string desc)
    {
        return TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL.ToString().Equals(desc);
    }
}
