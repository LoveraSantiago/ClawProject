using System.Collections.Generic;

public class LevelCacaNiquelPowerUpIndividual : AbstractLevel
{
    public override string getLevelName()
    {
        return "Caça Niquel Pup Individual";
    }


    public override string getMsgObjetivoLevel()
    {
        return "Ganhar power up escolhido.";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.CACANIQUEL_PUP_INDIVIDUAL;
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
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#2C7873");
        dicionario.Add("base-parte", "#004445");
        dicionario.Add("base-chao", "#021C1E");
        dicionario.Add("borda-vidro", "#6FB98F");
        dicionario.Add("placa-frontal", "#2C7873");
        dicionario.Add("placa-saida", "#6FB98F");
        dicionario.Add("barra", "#2E7B8F");
        dicionario.Add("chao-dentro", "#2E7B8F");
        dicionario.Add("tubo", "#2A5B85");
        dicionario.Add("viga-tras", "#021C1E");
        dicionario.Add("btnPowerUp1", "#2C7873");
        dicionario.Add("parte-dentro1", "#6FB98F");
        dicionario.Add("contorno1", "#004445");
        dicionario.Add("btnPowerUp2", "#2C7873");
        dicionario.Add("parte-dentro2", "#6FB98F");
        dicionario.Add("contorno2", "#004445");
        dicionario.Add("btnPowerUp3", "#2C7873");
        dicionario.Add("parte-dentro3", "#6FB98F");
        dicionario.Add("contorno3", "#004445");
        dicionario.Add("btnPowerUp4", "#2C7873");
        dicionario.Add("parte-dentro4", "#6FB98F");
        dicionario.Add("contorno4", "#004445");
        dicionario.Add("parte-cima", "#021C1E");
        dicionario.Add("parte-baixo", "#021C1E");
        dicionario.Add("furo-haste", "#2C7873");
        dicionario.Add("haste", "#B7B7B7");
        dicionario.Add("joystick-bola", "#2C7873");
        dicionario.Add("furo-botao", "#2C7873");
        dicionario.Add("botao", "#6FB98F");
        dicionario.Add("placa-ficha", "#021C1E");
        dicionario.Add("placa-parte-cima", "#004445");
        dicionario.Add("placa-parte-baixo", "#004445");
        dicionario.Add("quadrado-maior", "#6FB98F");
        dicionario.Add("quadrado-menor", "#2C7873");
        dicionario.Add("furo-cima", "#6FB98F");
        dicionario.Add("furo-baixo", "#6FB98F");
        dicionario.Add("display-coletados", "#021C1E");
        dicionario.Add("placa-coletado1", "#6FB98F");
        dicionario.Add("placa-coletado2", "#6FB98F");
        dicionario.Add("placa-coletado3", "#6FB98F");
        dicionario.Add("display-timer", "#021C1E");
        dicionario.Add("digitos-timer", "#6FB98F");
        dicionario.Add("display-pontos1", "#021C1E");
        dicionario.Add("display-pontos2", "#021C1E");
        dicionario.Add("display-pontos3", "#021C1E");
        dicionario.Add("leds1", "#6FB98F");
        dicionario.Add("leds2", "#6FB98F");
        dicionario.Add("leds3", "#6FB98F");
        dicionario.Add("cabo-da-garra", "#B3FFD4");

        return dicionario;
    }

    public override bool isAlbedo1()
    {
        return false;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevelCacaNiquelPupIndividual();
    }

    public class FornecedorLevelCacaNiquelPupIndividual : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelCacaNiquelPowerUpIndividual();
        }
    }
}
