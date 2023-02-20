namespace parque_diversoes
{
    public class Level3 : AbstractLevelNormal
    {
        public Level3() : base(new MaquinaCorBrilhanteFresco()) { }

        public override string getLevelTitle()
        {
            return "Nível 3";
        }

        public override int[,] getArrayDeColetaveis()
        {
            return new int[,] {
            {  4,  2,  1,  1,  2,  1,  3 },
            {  1,  4,  2,  1,  3,  2, -1 },
            {  1, -1,  2,  2,  3, -1,  4 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 } };
        }

        public override bool devolverParaBoard()
        {
            return false;
        }

        public override Challenge[] getChallenges()
        {
            return new Challenge[] {
            new ChallengeLevelCompleto(),
            new ChallengeTempoMenor("59:59"),
            new ChallengeScoreMaior(1)
        };
        }

        public override TipoContagemTempoDto getTempoContagem()
        {
            return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);                 
        }


        public override PowerUpsParaLevel getPupsToLevel()
        {
            return new PowerUpsParaLevel(1)
               .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINI_ASAS });
        }

        public override string getMsgObjetivoLevel()
        {
            return "Colete todos os itens";
        }
    }
}