using System.Collections.Generic;

public class Level10 : AbstractLevelOvo
{
    public override string getLevelTitle()
    {
        return "Nível 10";
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }        

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]{
            {7, -1, -1, 5, -1, -1, 7},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}};
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeLevelCompleto(),
            new ChallengeLevelCompleto(),
            new ChallengeLevelCompleto()
        };
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
        return "Sucrilhos com Ervilha";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //17. Stylish & Retro
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#D9B44A");
        dicionario.Add("base-chao", "#CEA22C");
        dicionario.Add("chao-dentro", "#ACD0C0");
        dicionario.Add("cabo-da-garra", "#B34AD9");
        dicionario.Add("viga", "#CEA22C");
        dicionario.Add("barra", "#ACD0C0");
        dicionario.Add("placa-timer", "#ACD0C0");
        dicionario.Add("display-timer-digito", "#75B1A9");
        dicionario.Add("seg", "#4F6457");
        dicionario.Add("placa-coletados", "#75B1A9");
        dicionario.Add("display-coletado1", "#ACD0C0");
        dicionario.Add("display-coletado2", "#ACD0C0");
        dicionario.Add("display-coletado3", "#ACD0C0");
        dicionario.Add("placa-scores", "#75B1A9");
        dicionario.Add("display-pontos1", "#ACD0C0");
        dicionario.Add("display-pontos2", "#ACD0C0");
        dicionario.Add("display-pontos3", "#ACD0C0");
        dicionario.Add("leds", "#4F6457");
        dicionario.Add("topo", "#D9B44A");
        dicionario.Add("base", "#C5DED3");
        dicionario.Add("mesa-joystick-cima", "#D9B44A");
        dicionario.Add("mesa-joystick-baixo", "#CEA22C");
        dicionario.Add("buraco-joystick", "#ACD0C0");
        dicionario.Add("haste-joystick", "#FFFFFF");
        dicionario.Add("bola-joystick", "#4F6457");
        dicionario.Add("buraco-botao", "#ACD0C0");
        dicionario.Add("botao", "#4F6457");
        dicionario.Add("buraco-ficha", "#75B1A9");
        dicionario.Add("buraco-card", "#75B1A9");
        dicionario.Add("triangulo-card", "#75B1A9");
        dicionario.Add("btn-pup-base-d", "#4F6457");
        dicionario.Add("btn-pup-topo-d", "#75B1A9");
        dicionario.Add("btn-pup-base-e", "#4F6457");
        dicionario.Add("btn-pup-topo-e", "#75B1A9");
        dicionario.Add("placa-externa", "#4F6457");
        dicionario.Add("placa-interna", "#75B1A9");
        dicionario.Add("setas-laterais", "#ACD0C0");
        dicionario.Add("seta-cima", "#ACD0C0");
        dicionario.Add("divisoria", "#4F6457");
        dicionario.Add("digitos", "#4F6457");
        dicionario.Add("circulo-externo", "#4F6457");
        dicionario.Add("circulo-interno", "#ACD0C0");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }
}
