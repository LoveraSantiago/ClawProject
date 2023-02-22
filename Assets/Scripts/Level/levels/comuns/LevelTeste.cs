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
            {-1, -1,  3,  1,  2, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        return new PowerUpsParaLevel(2)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.IGUAL })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] {  });
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
