public class LevelTeste : AbstractLevelNormal
{
    public LevelTeste() : base(new MaquinaCorChicleteEEmbalagem()){}

    public override string getLevelTitle()
    {
        return "Nível T";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete todos os itens";
    }  

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {-1, -1, -1, 12, -1, -1, -1},
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
