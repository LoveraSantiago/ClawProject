namespace parque_diversoes
{
    public class Level7 : AbstractLevelOrdem
    {
        public Level7() : base(new MaquinaCorModeradaProfissional()) { }

        public override string getLevelTitle()
        {
            return "Nível 7";
        }

        public override int[,] getArrayDeColetaveis()
        {
            return new int[,] {
            {3, -1, 4, 3, 4, 4, 3},
            {1, 1, 1, 0, 0, 0, -1},
            {6, 5, -1, 2, 2, 2, 5},
            {6, -1, -1, 5, -1, 6, -1},
            {-1, -1, -1, -1, -1, -1, -1},
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
                new BoardOrdem(1, "19"),
                new BoardOrdem(2, "21"),
                new BoardOrdem(3, "13"),
                new BoardOrdem(4, "14"),
                new BoardOrdem(5, "20"),
                new BoardOrdem(6, "18"),
                new BoardOrdem(7, "16"),
                new BoardOrdem(8, "15"),
                new BoardOrdem(9, "17"),
                new BoardOrdem(10, "12"),
                new BoardOrdem(11, "10"),
                new BoardOrdem(12, "11"),
                new BoardOrdem(13, "7"),
                new BoardOrdem(14, "9"),
                new BoardOrdem(15, "8"),
                new BoardOrdem(16, "6"),
                new BoardOrdem(17, "1"),
                new BoardOrdem(18, "3"),
                new BoardOrdem(19, "2"),
                new BoardOrdem(20, "5"),
                new BoardOrdem(21, "4")};
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
