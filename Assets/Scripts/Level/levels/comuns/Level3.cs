using System.Collections.Generic;

public class Level3 : AbstractLevelElevador
{
    public Level3():base(new MaquinaCorBrilhanteFresco()){}

    public override string getLevelTitle()
    {
        return "Nível 3";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            {  2,  1,  2,  5,  5,  5,  2 },
            {  4,  4,  4,  3,  3,  3, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 } };
    }

    //public override int[,] getArrayDeColetaveis()
    //{
    //    return new int[,]
    //    {
    //        {-1, -1,  0,  1,  2, -1, -1},
    //        {-1, -1, -1, -1, -1, -1, -1},
    //        {-1, -1, -1, -1, -1, -1, -1},
    //        {-1, -1, -1, -1, -1, -1, -1},
    //        {-1, -1, -1, -1, -1, -1, -1},
    //        {-1, -1, -1, -1, -1, -1, -1},
    //        {-1, -1, -1, -1, -1, -1, -1},
    //        {-1, -1, -1, -1, -1, -1, -1}
    //    };
    //}

    public override int[,] getArrayDeColetaveisSub()
    {
        return new int[,] {
            { 1, 1, 1, 1, 1, 1, -1 },
            { 2, 2, 2, 2, 2, 2,  2 }
        };
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {            
            new ChallengeSubidasDoElevadorIgual(this, 1),
            new ChallengeSubidasDoElevadorMenor(this, 3),
            new ChallengeSubidasDoElevadorMaior(this, 2)
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA });
    }
}