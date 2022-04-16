using System.Collections.Generic;

public class LevelPowerUp : AbstractLevel
{
    public override string getLevelName()
    {
        return "Treino de Power Up";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Treinar Habilidades em Power Up";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.PUP;
    }   

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 0},
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 0},
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
        dicionario.Add("placa-cima", "#375E97");
        dicionario.Add("base-parte", "#3F681C");
        dicionario.Add("base-chao", "#FB6542");
        dicionario.Add("borda-vidro", "#528CE3");
        dicionario.Add("placa-frontal", "#FFBB00");
        dicionario.Add("placa-saida", "#FB6542");
        dicionario.Add("barra", "#FFBB00");
        dicionario.Add("chao-dentro", "#3F681C");
        dicionario.Add("tubo", "#6FB531");
        dicionario.Add("viga-tras", "#2D4D7D");
        dicionario.Add("btnPowerUp1", "#E6A800");
        dicionario.Add("parte-dentro1", "#FFBB00");
        dicionario.Add("contorno1", "#FB6542");
        dicionario.Add("btnPowerUp2", "#E6A800");
        dicionario.Add("parte-dentro2", "#FFBB00");
        dicionario.Add("contorno2", "#FB6542");
        dicionario.Add("btnPowerUp3", "#E6A800");
        dicionario.Add("parte-dentro3", "#FFBB00");
        dicionario.Add("contorno3", "#FB6542");
        dicionario.Add("btnPowerUp4", "#E6A800");
        dicionario.Add("parte-dentro4", "#FFBB00");
        dicionario.Add("contorno4", "#FB6542");
        dicionario.Add("parte-cima", "#FB6542");
        dicionario.Add("parte-baixo", "#E0593A");
        dicionario.Add("furo-haste", "#1C1C1C");
        dicionario.Add("haste", "#B7B7B7");
        dicionario.Add("joystick-bola", "#1C1C1C");
        dicionario.Add("furo-botao", "#B7B7B7");
        dicionario.Add("botao", "#1C1C1C");
        dicionario.Add("placa-ficha", "#BA4A30");
        dicionario.Add("placa-parte-cima", "#E0593A");
        dicionario.Add("placa-parte-baixo", "#E0593A");
        dicionario.Add("quadrado-maior", "#FBA18C");
        dicionario.Add("quadrado-menor", "#FBA18C");
        dicionario.Add("furo-cima", "#FBA18C");
        dicionario.Add("furo-baixo", "#FBA18C");
        dicionario.Add("display-coletados", "#304F15");
        dicionario.Add("placa-coletado1", "#95F542");
        dicionario.Add("placa-coletado2", "#95F542");
        dicionario.Add("placa-coletado3", "#95F542");
        dicionario.Add("display-timer", "#304F15");
        dicionario.Add("digitos-timer", "#95F542");
        dicionario.Add("display-pontos1", "#304F15");
        dicionario.Add("display-pontos2", "#304F15");
        dicionario.Add("display-pontos3", "#304F15");
        dicionario.Add("leds1", "#95F542");
        dicionario.Add("leds2", "#95F542");
        dicionario.Add("leds3", "#95F542");
        dicionario.Add("cabo-da-garra", "#FB6542");
        return dicionario;        
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevelPup();
    }

    public class FornecedorLevelPup : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelPowerUp();
        }
    }
}
