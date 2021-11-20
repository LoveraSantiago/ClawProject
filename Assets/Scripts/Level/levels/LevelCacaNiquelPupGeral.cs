using System.Collections.Generic;

public class LevelCacaNiquelPupGeral : AbstractLevel
{
    public override string getLevelName()
    {
        return "Caça Niquel Pup Geral";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Ganhar power ups gerais.";
    }   

    protected override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.CACANIQUEL_PUP_GERAL;
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
    {//TODO adicionar cores proprias
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
        dicionario.Add("display-coletados", "#505160");
        dicionario.Add("placa-coletado1", "#9BC1EB");
        dicionario.Add("placa-coletado2", "#9BC1EB");
        dicionario.Add("placa-coletado3", "#9BC1EB");
        dicionario.Add("display-timer", "#505160");
        dicionario.Add("digitos-timer", "#576F88");
        dicionario.Add("display-pontos1", "#505160");
        dicionario.Add("display-pontos2", "#505160");
        dicionario.Add("display-pontos3", "#505160");
        dicionario.Add("leds1", "#576F88");
        dicionario.Add("leds2", "#576F88");
        dicionario.Add("leds3", "#576F88");
        dicionario.Add("cabo-da-garra", "#8CCF53");        return dicionario;        
    }   
}
