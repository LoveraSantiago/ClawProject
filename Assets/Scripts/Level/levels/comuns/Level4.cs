public class Level4 : AbstractLevelOrdem
{
    public Level4() : base(new MaquinaCorModeradaProfissional()){}

    public override string getLevelTitle()
    {
        return "Nível 4";
    }     

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            { 1,  1,  1,  1,  1,  1,  1},
            { 2,  2,  2,  2,  2,  2, -1},
            {-1,  5,  5,  5,  5,  5, -1},
            {-1,  6,  6,  6,  6,  0, -1},
            {-1, -1,  3,  3,  3, -1, -1},
            {-1, -1,  4,  4, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}};
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        return new PowerUpsParaLevel(1)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.DESCARTE,
               PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE});
    }

    public override BoardOrdem[] getBoardOrdem()
    {
        BoardOrdem[] ordem = new BoardOrdem[]{
        new BoardOrdem(1, "28"),
        new BoardOrdem(2, "27"),
        new BoardOrdem(3, "26"),
        new BoardOrdem(4, "24"),
        new BoardOrdem(5, "25"),
        new BoardOrdem(6, "23"),
        new BoardOrdem(7, "22"),
        new BoardOrdem(8, "21"),
        new BoardOrdem(9, "20"),
        new BoardOrdem(10, "19"),
        new BoardOrdem(11, "15"),
        new BoardOrdem(12, "14"),
        new BoardOrdem(13, "16"),
        new BoardOrdem(14, "18"),
        new BoardOrdem(15, "17"),
        new BoardOrdem(16, "13"),
        new BoardOrdem(17, "12"),
        new BoardOrdem(18, "11"),
        new BoardOrdem(19, "10"),
        new BoardOrdem(20, "9"),
        new BoardOrdem(21, "8"),
        new BoardOrdem(22, "4"),
        new BoardOrdem(23, "1"),
        new BoardOrdem(24, "7"),
        new BoardOrdem(25, "6"),
        new BoardOrdem(26, "2"),
        new BoardOrdem(27, "5"),
        new BoardOrdem(28, "3")};
        return ordem;
    }    

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeCombinacaoColetaveis(this, 5, 5, 5),            
            new ChallengeCombinacaoColetaveisTempoMaior(this, 1, 1, 1, "00:40"),
            new ChallengeSubidasDaGarraMaior(5)
        };
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }   
}
