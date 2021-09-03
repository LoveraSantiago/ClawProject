using System.Collections.Generic;

public class LevelCacaNiquelPupIndividual : AbstractLevel
{
    public override bool devolverParaBoard()
    {
        return false;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
       {
            {0, 0, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
       };
    }

    public override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL;
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#598234");
        dicionario.Add("base-parte", "#4E6C4A");
        dicionario.Add("base-chao", "#4E6C4A");
        dicionario.Add("borda-vidro", "#505160");
        dicionario.Add("placa-frontal", "#598234");
        dicionario.Add("placa-saida", "#AEBD38");
        dicionario.Add("barra", "#9BC1EB");
        dicionario.Add("chao-dentro", "#9BC1EB");
        dicionario.Add("tubo", "#68829E");
        dicionario.Add("viga-tras", "#598234");
        dicionario.Add("btnPowerUp1", "#505160");
        dicionario.Add("parte-dentro1", "#68829E");
        dicionario.Add("contorno1", "#9BC1EB");
        dicionario.Add("btnPowerUp2", "#505160");
        dicionario.Add("parte-dentro2", "#68829E");
        dicionario.Add("contorno2", "#9BC1EB");
        dicionario.Add("btnPowerUp3", "#505160");
        dicionario.Add("parte-dentro3", "#68829E");
        dicionario.Add("contorno3", "#9BC1EB");
        dicionario.Add("btnPowerUp4", "#505160");
        dicionario.Add("parte-dentro4", "#68829E");
        dicionario.Add("contorno4", "#9BC1EB");
        dicionario.Add("parte-cima", "#AEBD38");
        dicionario.Add("parte-baixo", "#AEBD38");
        dicionario.Add("furo-haste", "#505160");
        dicionario.Add("haste", "#9BC1EB");
        dicionario.Add("joystick-bola", "#505160");
        dicionario.Add("furo-botao", "#9BC1EB");
        dicionario.Add("botao", "#505160");
        dicionario.Add("placa-ficha", "#4E6C4A");
        dicionario.Add("placa-parte-cima", "#AEBD38");
        dicionario.Add("placa-parte-baixo", "#AEBD38");
        dicionario.Add("quadrado-maior", "#68829E");
        dicionario.Add("quadrado-menor", "#505160");
        dicionario.Add("furo-cima", "#505160");
        dicionario.Add("furo-baixo", "#505160");
        dicionario.Add("display-coletados", "#68829E");
        dicionario.Add("placa-coletado1", "#505160");
        dicionario.Add("placa-coletado2", "#505160");
        dicionario.Add("placa-coletado3", "#505160");
        dicionario.Add("display-timer", "#68829E");
        dicionario.Add("digitos-timer", "#505160");
        dicionario.Add("display-pontos1", "#68829E");
        dicionario.Add("display-pontos2", "#68829E");
        dicionario.Add("display-pontos3", "#68829E");
        dicionario.Add("leds1", "#505160");
        dicionario.Add("leds2", "#505160");
        dicionario.Add("leds3", "#505160");
        dicionario.Add("cabo-da-garra", "#68829E");

        return dicionario;
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override string getLevelName()
    {
        return "Caça Niquel Pup Individual";
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override string getMsgObjetivoLevel()
    {
        return "Ganhar power up escolhido.";
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }
}
