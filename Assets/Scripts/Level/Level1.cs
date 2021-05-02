public class Level1 : AbstractLevel
{
    public override string getLevelName()
    {
        return "Nível 1";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete todos os itens";
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {14, 12, 11, 12, 11, 12, 11},
            {12, 11, 14, 11, 11, 13, 13},
            {0, 0, 14, 14, 14, 0, 0},
            {0, 0, 0, 14, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override PowerUp.TIPO[] getPowerUpsParaBotoesMaquina()
    {
        return new PowerUp.TIPO[] { PowerUp.TIPO.BOMBA_DA_GARRA, PowerUp.TIPO.NONE, PowerUp.TIPO.BOMBA_DA_GARRA, PowerUp.TIPO.NONE };
    }
}
