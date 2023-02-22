namespace parque_diversoes
{
    public class Level4 : AbstractLevelObstaculos
    {
        public Level4() : base(new MaquinaCorModeradaProfissional()) { }

        public override string getLevelTitle()
        {
            return "Nível 4";
        }

        public override int[,] getArrayDeColetaveis()
        {
            int[,] coletaveis = new int[,]{
            {5, -1, 2, 5, 2, -1, 5},
            {-1, 3, 2, 4, 1, -1, -1},
            {-1, 3, 3, 4, 4, 1, -1},
            {-1, -1, -1, -1, -1, 1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
            return coletaveis;
        }

        public override bool[,] getArrayDeObstaculos()
        {
            bool[,] gaiolas = new bool[,]{
            {false, true, false, false, false, true, false},
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
               .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA });               
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
