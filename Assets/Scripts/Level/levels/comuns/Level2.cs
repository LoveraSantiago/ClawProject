using System.Collections.Generic;

public class Level2 : AbstractLevelTutorial
{
    public Level2():base(new MaquinaCorCarvaoCarbonita()){}

    public override string getLevelTitle()
    {
        return "Nível 2";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Combine o máximo de itens.";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            {  1,  0,  0,  4,  3,  0,  3 },
            {    4, 3,  1,  1, 4, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
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
            new ChallengeTempoMaior(this, "00:30"),
            new ChallengeScoreMenor(1000),
            new ChallengeSubidasDaGarraMenorQueUmValor(50)
        };
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }          

    public override int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo)
    {
        if (powerupTipo == PowerUpEnums.TIPO.MINI_ASAS)
        {
            return 1;
        }
        return 0;
    }

    public override AbstractMainGameEventosTutorial getMainGameEventos(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        TutorialLevel2 tutorial = new TutorialLevel2(allGameManagers, mainDto);
        return new MainGameEventosTutorialLevel2(allGameManagers, tutorial);
        //return new MainGameEventosPowerUp(allGameManagers, tutorial);
    }
}

