using System;

[Obsolete("ser removida qdo todos os tutoriais de pups estiverem prontos. Tudo copiadao para AbstractLevelTutorialPowerUp")]
public class LevelPowerUp : AbstractLevel
{
    public LevelPowerUp() : base(new MaquinaCorAguaAzulEsverdeada()){}

    public override string getLevelTitle()
    {
        return "Treino de Power Up";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Treinar Habilidades em Power Up";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.PUP;
    }   

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {0, 1, 2, 3, 4, 5, 6},
            {1, 2, 3, 4, 5, 6, -1},
            {0, 1, 2, 3, 4, 5, 6},
            {1, 2, 3, 4, 5, 6, -1},
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

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }     
}
