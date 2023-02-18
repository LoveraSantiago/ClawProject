public abstract class AbstractLevelTutorialPowerUp : AbstractLevelTutorial
{
    protected AbstractLevelTutorialPowerUp() : base(new MaquinaCorAguaAzulEsverdeada()){}

    public override string getLevelTitle()
    {
        return "Treino de Power Up";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Treinar Habilidades em Power Up";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.TUTORIAL_PUP;
    }

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }        

    public override int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo)
    {
        return 0;
    }

    public override void levelConcluido(string tempo, int score, int challenge, bool evolucao)
    {        
    }
}
