using System.Collections.Generic;

public class LevelPup : AbstractLevel
{
    public override string getLevelName()
    {
        return "Treino de Power Up";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Treinar Habilidades em Power Up";
    }

    protected override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.PUP;
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1},
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
