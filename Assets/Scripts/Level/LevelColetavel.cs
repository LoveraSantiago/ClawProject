using System.Collections.Generic;

public class LevelColetavel : AbstractLevel
{
    public override string getLevelName()
    {
        return "Coletavel Level";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete o coletavel de interesse";
    }

    protected override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.COLETAVEL;
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
    
    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override bool devolverParaBoard()
    {
        return false;
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
        dicionario.Add("digitos-timer", "#A1492F");
        dicionario.Add("display-pontos1", "#693D3D");
        dicionario.Add("display-pontos2", "#693D3D");
        dicionario.Add("display-pontos3", "#693D3D");
        dicionario.Add("leds1", "#A1492F");
        dicionario.Add("leds2", "#A1492F");
        dicionario.Add("leds3", "#A1492F");
        dicionario.Add("cabo-da-garra", "#199162");
        return dicionario;
    }
}
