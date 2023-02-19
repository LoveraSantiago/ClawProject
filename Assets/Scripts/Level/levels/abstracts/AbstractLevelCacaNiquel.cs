public abstract class AbstractLevelCacaNiquel : AbstractLevel
{
    protected AbstractLevelCacaNiquel() : base(new MaquinaCorChicleteEEmbalagem())
    {
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
       {
            {-1, -1, -1, -1, -1, -1, -1},
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

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }
}
