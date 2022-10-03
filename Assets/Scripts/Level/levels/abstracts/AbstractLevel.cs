using System.Collections.Generic;

public abstract class AbstractLevel 
{
    public static readonly string MSG_COLETAR_ITENS = "Colete todos os itens.";
    public static readonly string MSG_TEMPO         = "Colete os itens antes do tempo acabar.";
    public static readonly string MSG_ELEVADOR      = "Colete os itens antes do elevador subir.";
    public static readonly string MSG_ORDENADO      = "Colete seguindo a ordenação.";
    public static readonly string MSG_OBSTACULOS    = "Colete apesar dos obstaculos.";
    public static readonly string MSG_MEMORIA       = "Colete memorizando as posições.";

    private static ContextoEstaticoLevels contexto = new ContextoEstaticoLevels();
    private Dictionary<string, string> dicionario;

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

    public Dictionary<string, string> getDicionarioDeCores()
    {
        if(dicionario == null)
        {
            dicionario = getCoresMaquina();
        }
        return dicionario;
    }

    protected abstract Dictionary<string, string> getCoresMaquina();

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
