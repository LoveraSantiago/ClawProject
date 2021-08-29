using System.Collections.Generic;

public abstract class AbstractLevel 
{
    public enum TIPO_GAME { NORMAL, PUP, SORTEIO_PUP, SORTEIO_GERAL }

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
}
