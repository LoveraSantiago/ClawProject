public class Level2 : AbstractLevel
{
    public override string getLevelName()
    {
        return "Nível 2";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Faça o maior número de combinações";
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            { 10, 10, 10, 11, 11, 11, 12 },
            { 14, 14, 14, 13, 13, 13, 1 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 } };
    }

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override string getTempoContagem()
    {
        return "01:00";
    }

    public override PowerUpEntidade.NAME[] getPowerUpsParaBotoesMaquina()
    {
        return new PowerUpEntidade.NAME[] { PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE,
        PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_DA_GARRA, PowerUpEntidade.NAME.MINA_TERRESTRE};
    }
}

