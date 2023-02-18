public abstract class AbstractLevelColetavel : AbstractLevel
{
    protected AbstractLevelColetavel(MaquinaCor maquinaCor) : base(maquinaCor){}

    public ColetavelEntidade coletavelEntidade { get; private set; }

    public void setColetavelEntidade(ColetavelEntidade coletavelEntidade)
    {
        this.coletavelEntidade = coletavelEntidade;
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete o coletavel de interesse";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.COLETAVEL;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {0, 0, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }   

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        //return new PowerUpsParaLevel(1)
        //   .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MOLA });

        return new PowerUpsParaLevel(2)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BURACO_NEGRO, });
    }   
}
