using System.Collections.Generic;

public abstract class AbstractLevel 
{
    public static readonly string MSG_COLETAR_ITENS = "Colete todos os itens.";
    public static readonly string MSG_TEMPO         = "Colete os itens antes do tempo acabar.";
    public static readonly string MSG_ELEVADOR      = "Colete os itens antes do elevador subir.";
    public static readonly string MSG_ORDENADO      = "Colete seguindo a ordenação.";
    public static readonly string MSG_OBSTACULOS    = "Colete apesar dos obstaculos.";
    public static readonly string MSG_MEMORIA       = "Colete memorizando as posições.";
    public static readonly string TIMER_ZERO        = "00:00";

    private int indiceLevelAtual;
    public int challenge { get; private set; }
    public int score     { get; private set; }
    public string tempo  { get; private set; }

    private Dictionary<string, string> dicionario;

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

    public void addInfosParaLevelEmAndamento(int indiceLevelAtual, int challenge, int score, string tempo)
    {        
        this.indiceLevelAtual = indiceLevelAtual;
        this.challenge = challenge;
        this.score = score;
        this.tempo = tempo;
    }

    public virtual Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeLevelCompleto(),
            new ChallengeLevelCompleto(),
            new ChallengeLevelCompleto()
        };
    }

    public void levelConcluido(string tempo, int score, int challenge)
    {
        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;

        int indiceDecremento = indiceLevelAtual - 1;

        PlayerPrefsMapas.salvarIndiceLevelLiberado(indiceLevelAtual + 1);
        PlayerPrefsMapas.salvarScoreDoMapa(mapaEntidade, indiceDecremento, score);
        PlayerPrefsMapas.salvarChallengeDoMapa(mapaEntidade, indiceDecremento, challenge);
        PlayerPrefsMapas.salvarTempoDoMapa(mapaEntidade, indiceDecremento, tempo);

        mapaEntidade.reloadEstadosLevels();
    }
}
