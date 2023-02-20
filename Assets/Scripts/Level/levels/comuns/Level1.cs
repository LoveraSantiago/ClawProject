using System.Collections.Generic;

public class Level1 : AbstractLevelTutorial
{
    public Level1() : base(new MaquinaCorChicleteEEmbalagem()){}

    public override string getLevelTitle()
    {
        return "Nível 1";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Complete o tutorial";
    } 

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {-1, -1,  0,  0,  0,  0, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }   

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeCombinacaoColetaveis(this, 0, 0, 0),
            new ChallengeTempoMenor("59:59"),
            new ChallengeScoreMaior(1)
        };
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }      

    public override int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo)
    {
        if(powerupTipo == PowerUpEnums.TIPO.BOMBA_DA_GARRA)
        {
            return 1;
        }
        return 0;
    }

    public override AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        //return new MainGameEventosTutorialLevel1(allGameManagers, new TutorialLevel1(allGameManagers, mainDto));
        return new MainGameEventosTutorialLevel1Original(allGameManagers, new TutorialLevel1Original(allGameManagers, mainDto));
    }
}
