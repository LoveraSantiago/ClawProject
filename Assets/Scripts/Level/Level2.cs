
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
        return new PowerUpEntidade.NAME[] 
        {          
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
        };
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#80BD9E");
        dicionario.Add("base-parte", "#89DA59");
        dicionario.Add("base-chao", "#80BD9E");
        dicionario.Add("borda-vidro", "#CB9888");
        dicionario.Add("placa-frontal", "#C3EDAB");
        dicionario.Add("placa-saida", "#CB9888");
        dicionario.Add("barra", "#FF420E");
        dicionario.Add("chao-dentro", "#FF420E");
        dicionario.Add("tubo", "#F98866");
        dicionario.Add("viga-tras", "#52A123");
        dicionario.Add("btnPowerUp1", "#FAAB93");
        dicionario.Add("parte-dentro1", "#CB9888");
        dicionario.Add("contorno1", "#F37476");
        dicionario.Add("btnPowerUp2", "#FAAB93");
        dicionario.Add("parte-dentro2", "#CB9888");
        dicionario.Add("contorno2", "#F37476");
        dicionario.Add("btnPowerUp3", "#FAAB93");
        dicionario.Add("parte-dentro3", "#CB9888");
        dicionario.Add("contorno3", "#F37476");
        dicionario.Add("btnPowerUp4", "#FAAB93");
        dicionario.Add("parte-dentro4", "#CB9888");
        dicionario.Add("contorno4", "#F37476");
        dicionario.Add("parte-cima", "#CB9888");
        dicionario.Add("parte-baixo", "#F37476");
        dicionario.Add("furo-haste", "#FF420E");
        dicionario.Add("haste", "#F98866");
        dicionario.Add("joystick-bola", "#FF420E");
        dicionario.Add("furo-botao", "#FF420E");
        dicionario.Add("botao", "#F98866");
        dicionario.Add("placa-ficha", "#F98866");
        dicionario.Add("placa-parte-cima", "#CB9888");
        dicionario.Add("placa-parte-baixo", "#CB9888");
        dicionario.Add("quadrado-maior", "#CB9888");
        dicionario.Add("quadrado-menor", "#F98866");
        dicionario.Add("furo-cima", "#F98866");
        dicionario.Add("furo-baixo", "#F98866");
        dicionario.Add("display-coletados", "#164D28");
        dicionario.Add("placa-coletado1", "#268747");
        dicionario.Add("placa-coletado2", "#268747");
        dicionario.Add("placa-coletado3", "#268747");
        dicionario.Add("display-timer", "#164D28");
        dicionario.Add("digitos-timer", "#268747");
        dicionario.Add("display-pontos1", "#164D28");
        dicionario.Add("display-pontos2", "#164D28");
        dicionario.Add("display-pontos3", "#164D28");
        dicionario.Add("leds1", "#268747");
        dicionario.Add("leds2", "#268747");
        dicionario.Add("leds3", "#268747");
        dicionario.Add("cabo-da-garra", "#CB9888");

        return dicionario;
    }
}

