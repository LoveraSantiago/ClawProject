using System.Collections.Generic;

public abstract class AbstractLevel 
{
    public enum TIPO_GAME { NORMAL, PUP, CACANIQUEL_PUP_INDIVIDUAL, CACANIQUEL_PUP_GERAL }

    protected static readonly string TIMER_ZERO = "00:00";

    public abstract string getLevelName();

    public abstract string getMsgObjetivoLevel();

    public abstract GarraManager.MECANICA_GARRA getMecanicaDaGarra();

    public abstract bool devolverParaBoard();//Pode ser trocado p enum para tipos de devolucoes

    public abstract ColetavelEntidade.FAMILIA getFamiliaColetavel();

    public abstract int[,] getArrayDeColetaveis();

    public virtual int[,] getArrayDeColetaveisSub(){return null;}    

    public virtual TIPO_GAME getTipoGame() { return TIPO_GAME.NORMAL; }

    public abstract TipoContagemTempoDto getTempoContagem();

    public abstract Dictionary<string, string> getDicionarioDeCores();   

    public static bool isCacaNiquelLevel(AbstractLevel.TIPO_GAME tipoGame)
    {
        return tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_GERAL || tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL;
    }
}
