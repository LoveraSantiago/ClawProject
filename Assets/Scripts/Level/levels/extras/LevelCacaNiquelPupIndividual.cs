using System.Collections.Generic;

public class LevelCacaNiquelPupIndividual : AbstractLevel
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
        dicionario.Add("placa-cima", "#07575B");
        dicionario.Add("base-parte", "#003B46");
        dicionario.Add("base-chao", "#07575B");
        dicionario.Add("borda-vidro", "#66A5AD");
        dicionario.Add("placa-frontal", "#66A5AD");
        dicionario.Add("placa-saida", "#C4DFE6");
        dicionario.Add("barra", "#003B46");
        dicionario.Add("chao-dentro", "#003B46");
        dicionario.Add("tubo", "#C4DFE6");
        dicionario.Add("viga-tras", "#578D94");
        dicionario.Add("btnPowerUp1", "#003B46");
        dicionario.Add("parte-dentro1", "#07575B");
        dicionario.Add("contorno1", "#C4DFE6");
        dicionario.Add("btnPowerUp2", "#003B46");
        dicionario.Add("parte-dentro2", "#07575B");
        dicionario.Add("contorno2", "#C4DFE6");
        dicionario.Add("btnPowerUp3", "#003B46");
        dicionario.Add("parte-dentro3", "#07575B");
        dicionario.Add("contorno3", "#C4DFE6");
        dicionario.Add("btnPowerUp4", "#003B46");
        dicionario.Add("parte-dentro4", "#07575B");
        dicionario.Add("contorno4", "#C4DFE6");
        dicionario.Add("parte-cima", "#07575B");
        dicionario.Add("parte-baixo", "#003B46");
        dicionario.Add("furo-haste", "#003B46");
        dicionario.Add("haste", "#C4DFE6");
        dicionario.Add("joystick-bola", "#003B46");
        dicionario.Add("furo-botao", "#C4DFE6");
        dicionario.Add("botao", "#003B46");
        dicionario.Add("placa-ficha", "#003B46");
        dicionario.Add("placa-parte-cima", "#07575B");
        dicionario.Add("placa-parte-baixo", "#07575B");
        dicionario.Add("quadrado-maior", "#C4DFE6");
        dicionario.Add("quadrado-menor", "#66A5AD");
        dicionario.Add("furo-cima", "#C4DFE6");
        dicionario.Add("furo-baixo", "#C4DFE6");
        dicionario.Add("display-coletados", "#003B46");
        dicionario.Add("placa-coletado1", "#C4DFE6");
        dicionario.Add("placa-coletado2", "#C4DFE6");
        dicionario.Add("placa-coletado3", "#C4DFE6");
        dicionario.Add("display-timer", "#003B46");
        dicionario.Add("digitos-timer", "#07575B");
        dicionario.Add("display-pontos1", "#003B46");
        dicionario.Add("display-pontos2", "#003B46");
        dicionario.Add("display-pontos3", "#003B46");
        dicionario.Add("leds1", "#07575B");
        dicionario.Add("leds2", "#07575B");
        dicionario.Add("leds3", "#07575B");
        dicionario.Add("cabo-da-garra", "#14EAF5");
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
            return new LevelCacaNiquelPupIndividual();
        }
    }
}
