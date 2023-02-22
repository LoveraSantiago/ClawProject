namespace parque_diversoes
{
    public class Level10 : AbstractLevelNormal
    {
        public Level10() : base(new MaquinaCorSucrilhosComErvilha()) { }

        public override string getLevelTitle()
        {
            return "Nível 10";
        }

        public override int[,] getArrayDeColetaveis()
        {
            return new int[,] {
            { 6, 5, 2, 2, 1, 1, 4 },
            { 6, 5, 2, 3, 1, 4, -1 },
            { 0, 6, 5, 3, 3, 4, 0 },
            { 5, 1, 4, 1, 1, 0, -1 },
            { 6, 5, 4, 4, 3, 2, 2 },
            { 6, 5, 6, 3, 2, 3, -1 },
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
               .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.ASAS })
               .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.MINI_ASAS });
        }

        public override string getMsgObjetivoLevel()
        {
            return "Colete todos os itens";
        }
    }
}
