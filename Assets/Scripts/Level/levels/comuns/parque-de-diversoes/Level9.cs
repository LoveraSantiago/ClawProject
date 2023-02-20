namespace parque_diversoes
{
    public class Level9 : AbstractLevelObstaculos
    {
        public Level9() : base(new MaquinaCorTerrosaEscura()) { }

        public override string getLevelTitle()
        {
            return "Nível 9";
        }

        public override int[,] getArrayDeColetaveis()
        {
            int[,] coletaveis = new int[,]{
            {0, -1, 1, -1, 1, -1, 0},
            {-1, 5, 0, 1, 5, -1, -1},
            {-1, 1, 2, 2, 2, 5, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {4, -1, 1, 3, 4, 1, -1},
            {4, -1, -1, 3, -1, 3, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
            return coletaveis;
        }

        public override bool[,] getArrayDeObstaculos()
        {
            bool[,] gaiolas = new bool[,]{
            {false, true, false, true, false, true, false},
            {true, false, false, false, false, false, true},
            {true, false, false, false, false, false, true},
            {false, false, false, false, false, false, false},
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
            return new PowerUpsParaLevel(1)
               .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.TELEPORTE });
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
}
