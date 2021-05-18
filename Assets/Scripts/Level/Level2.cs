using System.Collections.Generic;

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
        return "01:31";
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

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#FF9800");
        dicionario.Add("base-parte", "#FFF000");
        dicionario.Add("base-chao", "#A6FF00");
        dicionario.Add("borda-vidro", "#39FF00");
        dicionario.Add("placa-frontal", "#00F30A");
        dicionario.Add("placa-saida", "#00E29C");
        dicionario.Add("barra", "#0052FF");
        dicionario.Add("chao-dentro", "#8F00FF");
        dicionario.Add("tubo", "#FF00FF");
        dicionario.Add("viga-tras", "#FF0066");
        dicionario.Add("btnPowerUp1", "#FF8000");
        dicionario.Add("parte-dentro1", "#FFBD00");
        dicionario.Add("contorno1", "#DFFF00");
        dicionario.Add("btnPowerUp2", "#97FF00");
        dicionario.Add("parte-dentro2", "#21FF00");
        dicionario.Add("contorno2", "#00FF1B");
        dicionario.Add("btnPowerUp3", "#00FF48");
        dicionario.Add("parte-dentro3", "#00FF6E");
        dicionario.Add("contorno3", "#00FFA8");
        dicionario.Add("btnPowerUp4", "#00AFFF");
        dicionario.Add("parte-dentro4", "#0087FF");
        dicionario.Add("contorno4", "#0F00FF");

        dicionario.Add("parte-cima", "#FF0066");
        dicionario.Add("parte-baixo", "#DFFF00");
        dicionario.Add("furo-haste", "#00FFAB");
        dicionario.Add("haste", "#0091FF");
        dicionario.Add("joystick-bola", "#FF005F");
        dicionario.Add("furo-botao", "#0F00FF");
        dicionario.Add("botao", "#FF2100");

        dicionario.Add("placa-ficha", "#FF9201");
        dicionario.Add("placa-parte-cima", "#FFD500");
        dicionario.Add("placa-parte-baixo", "#BCFF00");
        dicionario.Add("quadrado-maior", "#81FF00");
        dicionario.Add("quadrado-menor", "#4DFF00");
        dicionario.Add("furo-cima", "#00FF06");
        dicionario.Add("furo-baixo", "#00FF26");
        dicionario.Add("display-coletados", "#00FF7C");
        dicionario.Add("placa-coletado1", "#00FFA6");
        dicionario.Add("placa-coletado2", "#00FFAB");
        dicionario.Add("placa-coletado3", "#00FFAE");
        dicionario.Add("display-timer", "#00FFE2");
        dicionario.Add("digitos-timer", "#0091FF");
        dicionario.Add("display-pontos1", "#001DFF");
        dicionario.Add("display-pontos2", "#3200FF");
        dicionario.Add("display-pontos3", "#4700FF");
        dicionario.Add("leds1", "#6100FF");
        dicionario.Add("leds2", "#B900FF");
        dicionario.Add("leds3", "#FF005F");
        dicionario.Add("cabo-da-garra", "#F30000");

        return dicionario;

    }
}

