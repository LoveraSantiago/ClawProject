using System.Collections.Generic;

public class Level9 : AbstractLevel
{
    public override string getLevelTitle()
    {
        return "Nível 9";
    }

    public override string getMsgObjetivoLevel()
    {
        return LevelUtils.MSG_COLETAR_ITENS;
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.NORMAL;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]{
            {5, -1, -1, 2, -1, -1, 5},
            {-1, -1, 2, 2, -1, -1, -1},
            {-1, -1, -1, 2, -1, -1, -1},
            {-1, -1, 1, 1, -1, -1, -1},
            {-1, -1, -1, 1, -1, -1, -1},
            {-1, -1, 7, 7, -1, -1, -1},
            {-1, -1, -1, 7, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}};
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE });

    }

    public override string getMaquinaNome()
    {
        return "Chiclete e Embalagem";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //16. Day & Night
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#063852");
        dicionario.Add("base-chao", "#FFFFFF");
        dicionario.Add("chao-dentro", "#FFFFFF");
        dicionario.Add("cabo-da-garra", "#FFFFFF");
        dicionario.Add("viga", "#FFFFFF");
        dicionario.Add("barra", "#FFFFFF");
        dicionario.Add("placa-timer", "#E6DF44");
        dicionario.Add("display-timer-digito", "#063852");
        dicionario.Add("seg", "#011A27");
        dicionario.Add("placa-coletados", "#E6DF44");
        dicionario.Add("display-coletado1", "#063852");
        dicionario.Add("display-coletado2", "#063852");
        dicionario.Add("display-coletado3", "#063852");
        dicionario.Add("placa-scores", "#E6DF44");
        dicionario.Add("display-pontos1", "#063852");
        dicionario.Add("display-pontos2", "#063852");
        dicionario.Add("display-pontos3", "#063852");
        dicionario.Add("leds", "#011A27");
        dicionario.Add("topo", "#FFFFFF");
        dicionario.Add("base", "#FFFFFF");
        dicionario.Add("mesa-joystick-cima", "#FFFFFF");
        dicionario.Add("mesa-joystick-baixo", "#FFFFFF");
        dicionario.Add("buraco-joystick", "#FFFFFF");
        dicionario.Add("haste-joystick", "#FFFFFF");
        dicionario.Add("bola-joystick", "#FFFFFF");
        dicionario.Add("buraco-botao", "#FFFFFF");
        dicionario.Add("botao", "#FFFFFF");
        dicionario.Add("buraco-ficha", "#FFFFFF");
        dicionario.Add("buraco-card", "#FFFFFF");
        dicionario.Add("triangulo-card", "#FFFFFF");
        dicionario.Add("btn-pup-base-d", "#FFFFFF");
        dicionario.Add("btn-pup-topo-d", "#FFFFFF");
        dicionario.Add("btn-pup-base-e", "#FFFFFF");
        dicionario.Add("btn-pup-topo-e", "#FFFFFF");
        dicionario.Add("placa-externa", "#FFFFFF");
        dicionario.Add("placa-interna", "#FFFFFF");
        dicionario.Add("setas-laterais", "#FFFFFF");
        dicionario.Add("seta-cima", "#FFFFFF");
        dicionario.Add("divisoria", "#FFFFFF");
        dicionario.Add("digitos", "#FFFFFF");
        dicionario.Add("circulo-externo", "#FFFFFF");
        dicionario.Add("circulo-interno", "#FFFFFF");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }
}
