using System.Collections.Generic;

public class Level1 : AbstractLevel
{
    public override string getLevelName()
    {
        return "Nível 1";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete todos os itens";
    }

    public override TIPO_GAME getTipoGame()
    {
        return TIPO_GAME.NORMAL;
    }    

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {14, 12, 11, 12, 11, 12, 11},
            {12, 11, 14, 11, 11, 13, 0},
            {0, 0, 14, 14, 14, 0, 0},
            {0, 0, 0, 14, 0, 0, 0},
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

    public override PowerUpsToLevel getPupsLevel()
    {
        return new PowerUpsToLevel()
            .addBtn0(new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.BOMBA_DA_GARRA })
            .addBtn3(new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.ASAS});
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#5D5B5B");
        dicionario.Add("base-parte", "#1C1C1C");
        dicionario.Add("base-chao", "#5D5B5B");
        dicionario.Add("borda-vidro", "#BEBEBE");
        dicionario.Add("placa-frontal", "#E3E3E3");
        dicionario.Add("placa-saida", "#BEBEBE");
        dicionario.Add("barra", "#606986");
        dicionario.Add("chao-dentro", "#00BDCF");
        dicionario.Add("tubo", "#99E5EC");
        dicionario.Add("viga-tras", "#3A3A3A");
        dicionario.Add("btnPowerUp1", "#BEBEBE");
        dicionario.Add("parte-dentro1", "#7C7C7C");
        dicionario.Add("contorno1", "#FFFFFF");
        dicionario.Add("btnPowerUp2", "#BEBEBE");
        dicionario.Add("parte-dentro2", "#7C7C7C");
        dicionario.Add("contorno2", "#FFFFFF");
        dicionario.Add("btnPowerUp3", "#BEBEBE");
        dicionario.Add("parte-dentro3", "#7C7C7C");
        dicionario.Add("contorno3", "#FFFFFF");
        dicionario.Add("btnPowerUp4", "#BEBEBE");
        dicionario.Add("parte-dentro4", "#7C7C7C");
        dicionario.Add("contorno4", "#FFFFFF");
        dicionario.Add("parte-cima", "#717171");
        dicionario.Add("parte-baixo", "#575757");
        dicionario.Add("furo-haste", "#1C1C1C");
        dicionario.Add("haste", "#B7B7B7");
        dicionario.Add("joystick-bola", "#1C1C1C");
        dicionario.Add("furo-botao", "#B7B7B7");
        dicionario.Add("botao", "#1C1C1C");
        dicionario.Add("placa-ficha", "#1C1C1C");
        dicionario.Add("placa-parte-cima", "#474747");
        dicionario.Add("placa-parte-baixo", "#474747");
        dicionario.Add("quadrado-maior", "#F0F0F0");
        dicionario.Add("quadrado-menor", "#B8B8B8");
        dicionario.Add("furo-cima", "#E3E3E3");
        dicionario.Add("furo-baixo", "#E3E3E3");
        dicionario.Add("display-coletados", "#3A3A3A");
        dicionario.Add("placa-coletado1", "#BEBEBE");
        dicionario.Add("placa-coletado2", "#BEBEBE");
        dicionario.Add("placa-coletado3", "#BEBEBE");
        dicionario.Add("display-timer", "#3A3A3A");
        dicionario.Add("digitos-timer", "#5D5B5B");
        dicionario.Add("display-pontos1", "#3A3A3A");
        dicionario.Add("display-pontos2", "#3A3A3A");
        dicionario.Add("display-pontos3", "#3A3A3A");
        dicionario.Add("leds1", "#5D5B5B");
        dicionario.Add("leds2", "#5D5B5B");
        dicionario.Add("leds3", "#5D5B5B");
        dicionario.Add("cabo-da-garra", "#FFFFFF");
        return dicionario;
    }    

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel1();
    }

    public class FornecedorLevel1 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level1();
        }
    }
}
