namespace parque_diversoes
{
    public class Level5 : AbstractLevelOrdem
    {
        public Level5() : base(new MaquinaCorTerrosaEscura()) { }

        public override string getLevelTitle()
        {
            return "Nível 5";
        }

        public override int[,] getArrayDeColetaveis()
        {
            return new int[,] {
            {1, 5, 4, 4, 4, 5, 1},
            {3, 0, 0, 1, 0, 5, -1},
            {3, -1, 2, 2, 2, -1, 3},
            {-1, -1, 6, 6, -1, -1, -1},
            {-1, -1, -1, 6, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}};
        }   

        public override PowerUpsParaLevel getPupsToLevel()
        {
            return new PowerUpsParaLevel(0);
               //.addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.DESCARTE,
               //PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE});
        }

        public override BoardOrdem[] getBoardOrdem()
        {
            BoardOrdem[] ordem = new BoardOrdem[]{
                new BoardOrdem(1, "21"),
                new BoardOrdem(2, "20"),
                new BoardOrdem(3, "19"),
                new BoardOrdem(4, "14"),
                new BoardOrdem(5, "18"),
                new BoardOrdem(6, "8"),
                new BoardOrdem(7, "15"),
                new BoardOrdem(8, "17"),
                new BoardOrdem(9, "16"),
                new BoardOrdem(10, "9"),
                new BoardOrdem(11, "12"),
                new BoardOrdem(12, "10"),
                new BoardOrdem(13, "13"),
                new BoardOrdem(14, "6"),
                new BoardOrdem(15, "2"),
                new BoardOrdem(16, "11"),
                new BoardOrdem(17, "1"),
                new BoardOrdem(18, "7"),
                new BoardOrdem(19, "4"),
                new BoardOrdem(20, "5"),
                new BoardOrdem(21, "3")};
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
}