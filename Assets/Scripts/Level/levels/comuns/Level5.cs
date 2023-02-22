public class Level5 : AbstractLevelObstaculos
{
    public Level5() : base(new MaquinaCorTerrosaEscura()){}

    public override string getLevelTitle()
    {
        return "Nível 5";
    }   

    public override int[,] getArrayDeColetaveis()
    {
        int[,] coletaveis = new int[,]{
            {2, 2, 2, 1, 5, 5, 5},
            {5, 5, 5, 1, 2, 2, -1},
            {2, 2, 2, 1, 5, 5, 5},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
        return coletaveis;
    }
 
    public override bool[,] getArrayDeObstaculos()
    {
        bool[,] gaiolas = new bool[,]{
            {false, true, false, true, false, true, false},
            {true, false, true, false, true, false, true},
            {false, false, false, false, false, false, false},
            {true, true, true, true, true, true, true},
            {false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false}
        };
        return gaiolas;
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
           new ChallengeQuebrarGaiolasMaior(this, 4),
           new ChallengeQuebrarGaiolasTodas(this),
           new ChallengeQuebrarGaiolasIgual(this, 5)
        };
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        //return new PowerUpsParaLevel(1)
        //   .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MOLA });

        return new PowerUpsParaLevel(1)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE });           

    }

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }    
}
