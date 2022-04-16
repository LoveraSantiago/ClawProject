using System.Collections.Generic;

public abstract class AbstractLevel 
{
    public static readonly string TIMER_ZERO = "00:00";

    public abstract string getLevelName();

    public abstract string getMsgObjetivoLevel();    

    public abstract bool devolverParaBoard();

    public abstract ColetavelEntidade.FAMILIA getFamiliaColetavel();

    public abstract int[,] getArrayDeColetaveis();        

    public virtual PowerUpsParaLevel getPupsToLevel() { return null; }

    public string getTipoGameDesc()
    {
        return getTipoGame().ToString();
    }

    public abstract TipoGame getTipoGame();

    public abstract TipoContagemTempoDto getTempoContagem();

    public abstract Dictionary<string, string> getDicionarioDeCores();    

    public abstract bool isLevelAlbedo0();    

    public virtual bool isLevelAlbedo0Timer2Pontos()
    {
        return isLevelAlbedo0();
    }

    public bool hasPupToLevel()
    {
        return getPupsToLevel() != null;
    }   
}
