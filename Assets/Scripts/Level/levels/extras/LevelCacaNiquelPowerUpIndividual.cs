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
        dicionario.Add("placa-cima", "#7D4427");
        dicionario.Add("base-parte", "#C96D3E");
        dicionario.Add("base-chao", "#2E4600");
        dicionario.Add("borda-vidro", "#7D4427");
        dicionario.Add("placa-frontal", "#7D4427");
        dicionario.Add("placa-saida", "#A2C523");
        dicionario.Add("barra", "#7D4427");
        dicionario.Add("chao-dentro", "#C9957B");
        dicionario.Add("tubo", "#C96D3E");
        dicionario.Add("viga-tras", "#936D59");
        dicionario.Add("btnPowerUp1", "#A2C523");
        dicionario.Add("parte-dentro1", "#C9E466");
        dicionario.Add("contorno1", "#2E4600");
        dicionario.Add("btnPowerUp2", "#A2C523");
        dicionario.Add("parte-dentro2", "#7BE371");
        dicionario.Add("contorno2", "#2E4600");
        dicionario.Add("btnPowerUp3", "#A2C523");
        dicionario.Add("parte-dentro3", "#7BE371");
        dicionario.Add("contorno3", "#2E4600");
        dicionario.Add("btnPowerUp4", "#A2C523");
        dicionario.Add("parte-dentro4", "#C9E466");
        dicionario.Add("contorno4", "#2E4600");
        dicionario.Add("parte-cima", "#486B00");
        dicionario.Add("parte-baixo", "#2E4600");
        dicionario.Add("furo-haste", "#C9E466");
        dicionario.Add("haste", "#7D4427");
        dicionario.Add("joystick-bola", "#C9E466");
        dicionario.Add("furo-botao", "#7D4427");
        dicionario.Add("botao", "#C9E466");
        dicionario.Add("placa-ficha", "#486B00");
        dicionario.Add("placa-parte-cima", "#A2C523");
        dicionario.Add("placa-parte-baixo", "#A2C523");
        dicionario.Add("quadrado-maior", "#486B00");
        dicionario.Add("quadrado-menor", "#2E4600");
        dicionario.Add("furo-cima", "#486B00");
        dicionario.Add("furo-baixo", "#486B00");
        dicionario.Add("display-coletados", "#2E4600");
        dicionario.Add("placa-coletado1", "#A2C523");
        dicionario.Add("placa-coletado2", "#A2C523");
        dicionario.Add("placa-coletado3", "#A2C523");
        dicionario.Add("display-timer", "#2E4600");
        dicionario.Add("digitos-timer", "#486B00");
        dicionario.Add("display-pontos1", "#2E4600");
        dicionario.Add("display-pontos2", "#2E4600");
        dicionario.Add("display-pontos3", "#2E4600");
        dicionario.Add("leds1", "#486B00");
        dicionario.Add("leds2", "#486B00");
        dicionario.Add("leds3", "#486B00");
        dicionario.Add("cabo-da-garra", "#16C9BD");

        return dicionario;
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
