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
    private int challenge;

    private Dictionary<string, string> dicionario;

    public abstract string getLevelTitle();

    public virtual string getLevelName()
    {
        return getLevelTitle();
    }
    
    public abstract string getMsgObjetivoLevel();    

    public abstract bool devolverParaBoard();    

    public abstract int[,] getArrayDeColetaveis();     
    
    public int getChallenge()
    {
        return challenge;
    }

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

    public void addInfosParaLevelEmAndamento(int indiceLevelAtual, int challenge)
    {        
        this.indiceLevelAtual = indiceLevelAtual;
        this.challenge = challenge;
    }

    public Challenge[] getChallenges()
    {
        return new Challenge[] {
            new LevelCompletoChallenge(),
            new LevelCompletoChallenge(),
            new LevelCompletoChallenge()
        };
    }

    public void levelConcluido(string tempo, int score)
    {
        Avaliadores avaliadores = new Avaliadores(getChallenges());
        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;

        challenge = avaliadores.avaliar();

        PlayerPrefsMapas.salvarIndiceLevelLiberado(indiceLevelAtual + 1);
        PlayerPrefsMapas.salvarScoreDoMapa(mapaEntidade, indiceLevelAtual - 1, score);
        PlayerPrefsMapas.salvarChallengeDoMapa(mapaEntidade, indiceLevelAtual - 1, challenge);

        mapaEntidade.reloadChallenges();
    }
}
