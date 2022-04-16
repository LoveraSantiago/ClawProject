using System.Collections.Generic;

public class Level3 : AbstractLevelElevador
{
    public override string getLevelName()
    {
        return "Nível 3";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Cuidado com o numero de coletaveis";
    }   

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            { 10, 10, 10, 11, 11, 11, 12 },
            { 14, 14, 14, 13, 13, 13, 0 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 } };
    }

    public override int[,] getArrayDeColetaveisSub()
    {
        return new int[,] {
            { 10, 10, 10, 11, 11, 11, 0 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };
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
        return new TipoContagemTempoDto(ContadorTimer.Contagem.CONTINUA, "00:26");        
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#336B87");
        dicionario.Add("base-parte", "#763626");
        dicionario.Add("base-chao", "#336B87");
        dicionario.Add("borda-vidro", "#90AFC5");
        dicionario.Add("placa-frontal", "#336B87");
        dicionario.Add("placa-saida", "#90AFC5");
        dicionario.Add("barra", "#BF5940");
        dicionario.Add("chao-dentro", "#BF5940");
        dicionario.Add("tubo", "#6B3224");
        dicionario.Add("viga-tras", "#1B3947");
        dicionario.Add("btnPowerUp1", "#90AFC5");
        dicionario.Add("parte-dentro1", "#607173");
        dicionario.Add("contorno1", "#2A3132");
        dicionario.Add("btnPowerUp2", "#90AFC5");
        dicionario.Add("parte-dentro2", "#569CBF");
        dicionario.Add("contorno2", "#336B87");
        dicionario.Add("btnPowerUp3", "#90AFC5");
        dicionario.Add("parte-dentro3", "#569CBF");
        dicionario.Add("contorno3", "#336B87");
        dicionario.Add("btnPowerUp4", "#90AFC5");
        dicionario.Add("parte-dentro4", "#607173");
        dicionario.Add("contorno4", "#2A3132");
        dicionario.Add("parte-cima", "#BF5940");
        dicionario.Add("parte-baixo", "#863E2D");
        dicionario.Add("furo-haste", "#6B3224");
        dicionario.Add("haste", "#607173");
        dicionario.Add("joystick-bola", "#6B3224");
        dicionario.Add("furo-botao", "#607173");
        dicionario.Add("botao", "#6B3224");
        dicionario.Add("placa-ficha", "#2A3132");
        dicionario.Add("placa-parte-cima", "#575757");
        dicionario.Add("placa-parte-baixo", "#575757");
        dicionario.Add("quadrado-maior", "#90AFC5");
        dicionario.Add("quadrado-menor", "#455375");
        dicionario.Add("furo-cima", "#90AFC5");
        dicionario.Add("furo-baixo", "#90AFC5");
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
        dicionario.Add("cabo-da-garra", "#2C9FBF");

        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel3();
    }

    public class FornecedorLevel3 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level3();
        }
    }
}




