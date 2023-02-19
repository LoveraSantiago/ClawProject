public class Level9 : AbstractLevelNormal
{
    public Level9() : base(new MaquinaCorSurpresaDeAbobora()){}

    public override string getLevelTitle()
    {
        return "Nível 9";
    }

    public override string getMsgObjetivoLevel()
    {
        return LevelUtils.MSG_COLETAR_ITENS;
    }  

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]{
            {5, -1, -1, 2, -1, -1, 5},
            {-1, -1, 2, 2, -1, -1, -1},
            {-1, -1, -1, 2, -1, -1, -1},
            {-1, -1, 1, 1, -1, -1, -1},
            {-1, -1, -1, 1, -1, -1, -1},
            {-1, -1, 7, 7, -1, -1, -1},
            {-1, -1, -1, 7, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}};
    }

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengePowerUpEspecificoAcionadoTempoMaior(PowerUpEnums.TIPO.BOMBA_DA_GARRA, "01:00"),
            new ChallengeSubidasDaGarraTodasComSucesso(),
            new ChallengeSubidasDaGarraComFalhas(2)
        };
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        //return new PowerUpsParaLevel(1)
        //   .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MOLA });

        return new PowerUpsParaLevel(2)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE });

    }        
}
