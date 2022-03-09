using System.Collections.Generic;

public class Level4 : AbstractLevelOrdem
{
    public override string getLevelName()
    {
        return "Nível 4";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Siga a ordem dos coletaveis";
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
            new BoardOrdem(1, "28"),
            new BoardOrdem(2, "27"),
            new BoardOrdem(3, "26"),
            new BoardOrdem(4, "24"),
            new BoardOrdem(5, "23"),
            new BoardOrdem(6, "25"),
            new BoardOrdem(7, "22"),
            new BoardOrdem(8, "21"),
            new BoardOrdem(9, "20"),
            new BoardOrdem(10, "19"),
            new BoardOrdem(11, "15"),
            new BoardOrdem(12, "14"),
            new BoardOrdem(13, "16"),
            new BoardOrdem(14, "18"),
            new BoardOrdem(15, "17"),
            new BoardOrdem(16, "13"),
            new BoardOrdem(17, "12"),
            new BoardOrdem(18, "11"),
            new BoardOrdem(19, "10"),
            new BoardOrdem(20, "9"),
            new BoardOrdem(21, "8"),
            new BoardOrdem(22, "4"),
            new BoardOrdem(23, "1"),
            new BoardOrdem(24, "7"),
            new BoardOrdem(25, "6"),
            new BoardOrdem(26, "2"),
            new BoardOrdem(27, "5"),
            new BoardOrdem(28, "3")
        };
        return ordem;
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

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel4();
    }

    public class FornecedorLevel4 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level4();
        }
    }
}
