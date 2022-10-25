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
        return "Surpresa de Abobora";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //16. Day & Night
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#063852");
        dicionario.Add("base-chao", "#011A27");
        dicionario.Add("chao-dentro", "#011A27");
        dicionario.Add("cabo-da-garra", "#C6D4FF");
        dicionario.Add("viga", "#063852");
        dicionario.Add("barra", "#011A27");
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
        dicionario.Add("topo", "#063852");
        dicionario.Add("base", "#E6DF44");
        dicionario.Add("mesa-joystick-cima", "#F0810F");
        dicionario.Add("mesa-joystick-baixo", "#F0810F");
        dicionario.Add("buraco-joystick", "#063852");
        dicionario.Add("haste-joystick", "#011A27");
        dicionario.Add("bola-joystick", "#063852");
        dicionario.Add("buraco-botao", "#063852");
        dicionario.Add("botao", "#E6DF44");
        dicionario.Add("buraco-ficha", "#E6DF44");
        dicionario.Add("buraco-card", "#E6DF44");
        dicionario.Add("triangulo-card", "#E6DF44");
        dicionario.Add("btn-pup-base-d", "#063852");
        dicionario.Add("btn-pup-topo-d", "#E6DF44");
        dicionario.Add("btn-pup-base-e", "#063852");
        dicionario.Add("btn-pup-topo-e", "#E6DF44");
        dicionario.Add("placa-externa", "#011A27");
        dicionario.Add("placa-interna", "#F0810F");
        dicionario.Add("setas-laterais", "#E6DF44");
        dicionario.Add("seta-cima", "#F0810F");
        dicionario.Add("divisoria", "#063852");
        dicionario.Add("digitos", "#063852");
        dicionario.Add("circulo-externo", "#011A27");
        dicionario.Add("circulo-interno", "#F0810F");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }
}
