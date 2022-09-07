using System.Collections.Generic;

public abstract class AbstractLevel 
{
    private static ContextoEstaticoLevels contexto = new ContextoEstaticoLevels();

    public static readonly string TIMER_ZERO = "00:00";

    public abstract string getLevelTitle();

    public virtual string getLevelName()
    {
        return getLevelTitle();
    }
    
    public abstract string getMsgObjetivoLevel();    

    public abstract bool devolverParaBoard();    

    public abstract int[,] getArrayDeColetaveis();        

    public virtual PowerUpsParaLevel getPupsToLevel() { return null; }

    public string getTipoGameDesc()
    {
        return getTipoGame().ToString();
    }

    public abstract TipoGame getTipoGame();

    public abstract TipoContagemTempoDto getTempoContagem();

    public abstract Dictionary<string, string> getDicionarioDeCores();

    public abstract string getMaquinaNome();   

    public abstract bool isLevelAlbedo0();

    public virtual bool isLevelAlbedo0Scores()
    {
        return isLevelAlbedo0();
    }

    public virtual bool isLevelAlbedo0Timers()
    {
        return isLevelAlbedo0();
    }

    public virtual bool isLevelAlbedo0Timer2Pontos()
    {
        return isLevelAlbedo0();
    }

    public virtual bool isLevelAlbedo0DigitosScrollPup()
    {
        return isLevelAlbedo0();
    }  

    public bool hasPupToLevel()
    {
        return getPupsToLevel() != null;
    }   

    public void setIndiceLevelAtual(int indiceLevelAtual)
    {
        contexto.receberIndiceLevelAtual(indiceLevelAtual);
    }

    public void levelConcluido()
    {
        contexto.salvarLevelAtual();
    }
}
