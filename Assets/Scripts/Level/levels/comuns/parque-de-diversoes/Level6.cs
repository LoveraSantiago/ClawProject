namespace parque_diversoes
{
    public class Level6 : AbstractLevelObstaculos
    {
        public Level6() : base(new MaquinaCorBrilhanteFresco())
        {
        }

        public override string getLevelTitle()
        {
            return "Nível 6";
        }

        public override int[,] getArrayDeColetaveis()
        {
            return new int[,] {
            { -1, -1, 0, 0, 0, -1, -1 },
            { -1, -1, 1, 1, 1, -1, -1 },
            { -1, -1, 2, 2, 3, -1, -1 },
            { -1, -1, 2, 3, 4, -1, -1 },
            { -1, 5, 5, 3, 4, 6, -1 },
            { 6, -1, 5, 4, -1, 6, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 } };
        }

        public override bool[,] getArrayDeObstaculos()
        {
            bool[,] gaiolas = new bool[,]{
                {true, true, false, false, false, true, true},
                {false, true, false, false, false, true, false},
                {true, true, false, false, false, true, true},
                {false, true, false, false, false, true, false},
                {true, false, false, false, false, false, true},
                {false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false}
        };
            return gaiolas;
        }



        public override Challenge[] getChallenges()
        {
            return new Challenge[] {
            new ChallengeQuebrarGaiolasMaior(this, 1),
            new ChallengeQuebrarGaiolasMaior(this, 3),
            new ChallengeQuebrarGaiolasMaior(this, 2)
        };
        }

        public override bool devolverParaBoard()
        {
            return true;
        }

        public override TipoContagemTempoDto getTempoContagem()
        {
            return new TipoContagemTempoDto(ContadorTimer.Contagem.CONTINUA, "01:00");
            //return new TipoContagemTempoDto(ContadorTimer.Contagem.CONTINUA, "00:20");        
        }


        public override PowerUpsParaLevel getPupsToLevel()
        {
            return new PowerUpsParaLevel(2)
               .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE })
               .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO });
        }    
    }
}