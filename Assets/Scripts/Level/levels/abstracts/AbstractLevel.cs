using System.Collections.Generic;

public abstract class AbstractLevel 
{
    private int indiceLevelAtual;
    public int challenge { get; private set; }
    public int score     { get; private set; }
    public string tempo  { get; private set; }

    private MaquinaCor maquinaCor;
    private Dictionary<string, string> dicionario;   

    public AbstractLevel(MaquinaCor maquinaCor)
    {
        this.maquinaCor = maquinaCor;
    }

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

    //protected abstract Dictionary<string, string> getCoresMaquina();
    private Dictionary<string, string> getCoresMaquina()
    {
        return maquinaCor.getCores();
    }

    public string getMaquinaNome()
    {
        return maquinaCor.getNome();
    }

    public bool isLevelAlbedo0()
    {
        return maquinaCor.isLevelAlbedo0();
    }

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
        return maquinaCor.isLevelAlbedo0Timer2Pontos();
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

    public virtual void levelConcluido(string tempo, int score, int challenge, bool evolucao)
    {
        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;

        int indiceDecremento = indiceLevelAtual - 1;

        PlayerPrefsMapas.salvarIndiceLevelLiberado(indiceLevelAtual + 1);
        PlayerPrefsMapas.salvarScoreDoMapa(mapaEntidade, indiceDecremento, score);
        PlayerPrefsMapas.salvarChallengeDoMapa(mapaEntidade, indiceDecremento, challenge, evolucao);
        PlayerPrefsMapas.salvarTempoDoMapa(mapaEntidade, indiceDecremento, tempo);

        mapaEntidade.reloadEstadosLevels();
    }
}
