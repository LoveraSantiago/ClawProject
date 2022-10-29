using System.Collections.Generic;

public abstract class AbstractLevelColetavel : AbstractLevel
{
    public ColetavelEntidade coletavelEntidade { get; private set; }

    public void setColetavelEntidade(ColetavelEntidade coletavelEntidade)
    {
        this.coletavelEntidade = coletavelEntidade;
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete o coletavel de interesse";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.COLETAVEL;
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

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        //return new PowerUpsParaLevel(1)
        //   .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MOLA });

        return new PowerUpsParaLevel(2)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BURACO_NEGRO, });
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-cima", "#F2E205");
        dicionario.Add("base-parte", "#F2B90F");
        dicionario.Add("base-chao", "#F2E205");
        dicionario.Add("borda-vidro", "#F2E205");
        dicionario.Add("placa-frontal", "#F2E205");
        dicionario.Add("placa-saida", "#F2EC99");
        dicionario.Add("barra", "#5D04D9");
        dicionario.Add("chao-dentro", "#5D04D9");
        dicionario.Add("tubo", "#9F5CFC");
        dicionario.Add("viga-tras", "#BCB004");
        dicionario.Add("btnPowerUp1", "#F2EC99");
        dicionario.Add("parte-dentro1", "#F2CB05");
        dicionario.Add("contorno1", "#F2B90F");
        dicionario.Add("btnPowerUp2", "#F2EC99");
        dicionario.Add("parte-dentro2", "#F2CB05");
        dicionario.Add("contorno2", "#F2B90F");
        dicionario.Add("btnPowerUp3", "#F2EC99");
        dicionario.Add("parte-dentro3", "#F2CB05");
        dicionario.Add("contorno3", "#F2B90F");
        dicionario.Add("btnPowerUp4", "#F2EC99");
        dicionario.Add("parte-dentro4", "#F2CB05");
        dicionario.Add("contorno4", "#F2B90F");
        dicionario.Add("parte-cima", "#BCB004");
        dicionario.Add("parte-baixo", "#F2B90F");
        dicionario.Add("furo-haste", "#5D04D9");
        dicionario.Add("haste", "#B7B7B7");
        dicionario.Add("joystick-bola", "#5D04D9");
        dicionario.Add("furo-botao", "#B7B7B7");
        dicionario.Add("botao", "#5D04D9");
        dicionario.Add("placa-ficha", "#BCB004");
        dicionario.Add("placa-parte-cima", "#9F5CFC");
        dicionario.Add("placa-parte-baixo", "#9F5CFC");
        dicionario.Add("quadrado-maior", "#F2EC99");
        dicionario.Add("quadrado-menor", "#BCB004");
        dicionario.Add("furo-cima", "#F2EC99");
        dicionario.Add("furo-baixo", "#F2EC99");
        dicionario.Add("display-coletados", "#D09E0B");
        dicionario.Add("placa-coletado1", "#F2EC99");
        dicionario.Add("placa-coletado2", "#F2EC99");
        dicionario.Add("placa-coletado3", "#F2EC99");
        dicionario.Add("display-timer", "#D09E0B");
        dicionario.Add("digitos-timer", "#BCB004");
        dicionario.Add("display-pontos1", "#D09E0B");
        dicionario.Add("display-pontos2", "#D09E0B");
        dicionario.Add("display-pontos3", "#D09E0B");
        dicionario.Add("leds1", "#BCB004");
        dicionario.Add("leds2", "#BCB004");
        dicionario.Add("leds3", "#BCB004");
        dicionario.Add("cabo-da-garra", "#9F5CFC");
        return dicionario;
    }
}
