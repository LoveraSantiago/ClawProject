public class Level6 : AbstractLevelOvo
{
    public Level6() : base(new MaquinaCorDramaticaCrocante()){}

    public override string getLevelTitle()
    {
        return "Level 6";
    }   

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    } 

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            { 4,  4,  4,  1,  1,  3,  3},
            { 2,  2,  2,  7,  1,  3, -1},
            {-1, -1,  5,  5,  7, 7, -1},
            {-1, -1, -1,  5, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeCombinacaoColetaveisTempoMenor(this, 1, 1, 1, "01:30"),
            new ChallengeCombinacaoColetaveisTodasCorretas(this),
            new ChallengePowerUpNenhumAcionado()
        };
    }         
}
