using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : AbstractLevel
{
    public override string getLevelName()
    {
        return "Nível 3";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Cuidado com o numero de coletaveis";
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

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override bool devolverParaBoard()
    {
        throw new System.NotImplementedException();
    }


    public override PowerUpEntidade.NAME[] getPowerUpsParaBotoesMaquina()
    {
        return new PowerUpEntidade.NAME[]
       {
            PowerUpEntidade.NAME.TELEPORTE     , PowerUpEntidade.NAME.ASAS,
            PowerUpEntidade.NAME.BOMBA_DA_GARRA, PowerUpEntidade.NAME.MISSIL_NUCLEAR, PowerUpEntidade.NAME.MINA_TERRESTRE, PowerUpEntidade.NAME.MISSIL_TELEGUIADO,
       };
    }

    public override string getTempoContagem()
    {
        return "01:31";
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#336B87");
        dicionario.Add("base-parte", "#763626");
        dicionario.Add("base-chao", "#5D5B5B");
        dicionario.Add("borda-vidro", "#90AFC5");
        dicionario.Add("placa-frontal", "#336B87");
        dicionario.Add("placa-saida", "#BEBEBE");
        dicionario.Add("barra", "#606986");
        dicionario.Add("chao-dentro", "#00BDCF");
        dicionario.Add("tubo", "#99E5EC");
        dicionario.Add("viga-tras", "#3A3A3A");
        dicionario.Add("btnPowerUp1", "#90AFC5");
        dicionario.Add("parte-dentro1", "#7C7C7C");
        dicionario.Add("contorno1", "#FFFFFF");
        dicionario.Add("btnPowerUp2", "#90AFC5");
        dicionario.Add("parte-dentro2", "#7C7C7C");
        dicionario.Add("contorno2", "#FFFFFF");
        dicionario.Add("btnPowerUp3", "#90AFC5");
        dicionario.Add("parte-dentro3", "#7C7C7C");
        dicionario.Add("contorno3", "#FFFFFF");
        dicionario.Add("btnPowerUp4", "#90AFC5");
        dicionario.Add("parte-dentro4", "#7C7C7C");
        dicionario.Add("contorno4", "#FFFFFF");
        dicionario.Add("parte-cima", "#717171");
        dicionario.Add("parte-baixo", "#575757");
        dicionario.Add("furo-haste", "#1C1C1C");
        dicionario.Add("haste", "#B7B7B7");
        dicionario.Add("joystick-bola", "#1C1C1C");
        dicionario.Add("furo-botao", "#B7B7B7");
        dicionario.Add("botao", "#1C1C1C");
        dicionario.Add("placa-ficha", "#1C1C1C");
        dicionario.Add("placa-parte-cima", "#474747");
        dicionario.Add("placa-parte-baixo", "#474747");
        dicionario.Add("quadrado-maior", "#F0F0F0");
        dicionario.Add("quadrado-menor", "#B8B8B8");
        dicionario.Add("furo-cima", "#E3E3E3");
        dicionario.Add("furo-baixo", "#E3E3E3");
        dicionario.Add("display-coletados", "#2A3132");
        dicionario.Add("placa-coletado1", "#607173");
        dicionario.Add("placa-coletado2", "#607173");
        dicionario.Add("placa-coletado3", "#607173");
        dicionario.Add("display-timer", "#2A3132");
        dicionario.Add("digitos-timer", "#607173");
        dicionario.Add("display-pontos1", "#2A3132");
        dicionario.Add("display-pontos2", "#2A3132");
        dicionario.Add("display-pontos3", "#2A3132");
        dicionario.Add("leds1", "#536163");
        dicionario.Add("leds2", "#536163");
        dicionario.Add("leds3", "#536163");
        dicionario.Add("cabo-da-garra", "#FFFFFF");

        return dicionario;
    }
}




