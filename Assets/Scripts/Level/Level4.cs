using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : AbstractLevel
{
    public override string getLevelName()
    {
        return "Nível 4";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Siga a ordem dos coletaveis";
    }

    protected override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.ORDENADO;
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            {11, 11, 11, 11, 11, 11, 11},
            {12, 12, 12, 12, 12, 12, 0},
            {0, 15, 15, 15, 15, 15, 0},
            {0, 16, 16, 16, 16, 0, 0},
            {0, 0, 13, 13, 13, 0, 0},
            {0, 0, 14, 14, 0, 0, 0},
            {0, 0, 0, 10, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}};
    }

    public override BoardOrdem[] getBoardOrdem()
    {
        BoardOrdem[] ordem = new BoardOrdem[]{
            new BoardOrdem(0, 6, 3),
            new BoardOrdem(1, 5, 3),
            new BoardOrdem(2, 5, 2),
            new BoardOrdem(3, 4, 3),
            new BoardOrdem(4, 4, 2),
            new BoardOrdem(5, 4, 4),
            new BoardOrdem(6, 3, 4),
            new BoardOrdem(7, 3, 3),
            new BoardOrdem(8, 3, 2),
            new BoardOrdem(9, 3, 1),
            new BoardOrdem(10, 2, 2),
            new BoardOrdem(11, 2, 1),
            new BoardOrdem(12, 2, 3),
            new BoardOrdem(13, 2, 5),
            new BoardOrdem(14, 2, 4),
            new BoardOrdem(15, 1, 5),
            new BoardOrdem(16, 1, 4),
            new BoardOrdem(17, 1, 3),
            new BoardOrdem(18, 1, 2),
            new BoardOrdem(19, 1, 1),
            new BoardOrdem(20, 1, 0),
            new BoardOrdem(21, 0, 3),
            new BoardOrdem(22, 0, 0),
            new BoardOrdem(23, 0, 6),
            new BoardOrdem(24, 0, 5),
            new BoardOrdem(25, 0, 1),
            new BoardOrdem(26, 0, 4),
            new BoardOrdem(27, 0, 2)
        };
        return ordem;
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override bool devolverParaBoard()
    {
        return true;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#46211A");
        dicionario.Add("base-parte", "#A43820");
        dicionario.Add("base-chao", "#46211A");
        dicionario.Add("borda-vidro", "#46211A");
        dicionario.Add("placa-frontal", "#46211A");
        dicionario.Add("placa-saida", "#BA5536");
        dicionario.Add("barra", "#57B5A7");
        dicionario.Add("chao-dentro", "#57B5A7");
        dicionario.Add("tubo", "#376961");
        dicionario.Add("viga-tras", "#331813");
        dicionario.Add("btnPowerUp1", "#693D3D");
        dicionario.Add("parte-dentro1", "#A43820");
        dicionario.Add("contorno1", "#BA5536");
        dicionario.Add("btnPowerUp2", "#693D3D");
        dicionario.Add("parte-dentro2", "#A43820");
        dicionario.Add("contorno2", "#BA5536");
        dicionario.Add("btnPowerUp3", "#693D3D");
        dicionario.Add("parte-dentro3", "#A43820");
        dicionario.Add("contorno3", "#BA5536");
        dicionario.Add("btnPowerUp4", "#693D3D");
        dicionario.Add("parte-dentro4", "#A43820");
        dicionario.Add("contorno4", "#BA5536");
        dicionario.Add("parte-cima", "#BA5536");
        dicionario.Add("parte-baixo", "#A43820");
        dicionario.Add("furo-haste", "#376961");
        dicionario.Add("haste", "#57B5A7");
        dicionario.Add("joystick-bola", "#376961");
        dicionario.Add("furo-botao", "#57B5A7");
        dicionario.Add("botao", "#376961");
        dicionario.Add("placa-ficha", "#BA5536");
        dicionario.Add("placa-parte-cima", "#A43820");
        dicionario.Add("placa-parte-baixo", "#A43820");
        dicionario.Add("quadrado-maior", "#57B5A7");
        dicionario.Add("quadrado-menor", "#693D3D");
        dicionario.Add("furo-cima", "#57B5A7");
        dicionario.Add("furo-baixo", "#57B5A7");
        dicionario.Add("display-coletados", "#693D3D");
        dicionario.Add("placa-coletado1", "#BA5536");
        dicionario.Add("placa-coletado2", "#BA5536");
        dicionario.Add("placa-coletado3", "#BA5536");
        dicionario.Add("display-timer", "#693D3D");
        dicionario.Add("digitos-timer", "#BA5536");
        dicionario.Add("display-pontos1", "#693D3D");
        dicionario.Add("display-pontos2", "#693D3D");
        dicionario.Add("display-pontos3", "#693D3D");
        dicionario.Add("leds1", "#BA5536");
        dicionario.Add("leds2", "#BA5536");
        dicionario.Add("leds3", "#BA5536");
        dicionario.Add("cabo-da-garra", "#376961");

        return dicionario;
    }
}
