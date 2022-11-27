using System.Collections.Generic;

public class Level1 : AbstractLevelTutorial
{
    public override string getLevelTitle()
    {
        return "Nível 1";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Complete o tutorial";
    } 

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {-1, -1,  0,  0,  0,  0, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }   

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeCombinacaoColetaveis(this, 0, 0, 0),
            new ChallengeTempoMenor("59:59"),
            new ChallengeScoreMaior(1)
        };
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }    

    public override string getMaquinaNome()
    {
        return "Chiclete e Embalagem";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#EB82EB");
        dicionario.Add("base-chao", "#FF8096");
        dicionario.Add("chao-dentro", "#00BDCF");
        dicionario.Add("cabo-da-garra", "#FB6542");
        dicionario.Add("viga", "#C268C2");
        dicionario.Add("barra", "#606986");
        dicionario.Add("placa-timer", "#FF8096");
        dicionario.Add("display-timer-digito", "#85E1F0");
        dicionario.Add("seg", "#6CAED9");
        dicionario.Add("placa-coletados", "#FF8096");
        dicionario.Add("display-coletado1", "#85E1F0");
        dicionario.Add("display-coletado2", "#85E1F0");
        dicionario.Add("display-coletado3", "#85E1F0");
        dicionario.Add("placa-scores", "#FF8096");
        dicionario.Add("display-pontos1", "#85E1F0");
        dicionario.Add("display-pontos2", "#85E1F0");
        dicionario.Add("display-pontos3", "#85E1F0");
        dicionario.Add("leds", "#6CAED9");
        dicionario.Add("topo", "#FF8096");
        dicionario.Add("base", "#99E5EC");
        dicionario.Add("mesa-joystick-cima", "#EAE67B");
        dicionario.Add("mesa-joystick-baixo", "#C1BD64");
        dicionario.Add("buraco-joystick", "#FF8096");
        dicionario.Add("haste-joystick", "#B7B7B7");
        dicionario.Add("bola-joystick", "#85E1F0");
        dicionario.Add("buraco-botao", "#85E1F0");
        dicionario.Add("botao", "#EB82EB");
        dicionario.Add("buraco-ficha", "#85E1F0");
        dicionario.Add("buraco-card", "#85E1F0");
        dicionario.Add("triangulo-card", "#85E1F0");
        dicionario.Add("btn-pup-base-d", "#FF8096");
        dicionario.Add("btn-pup-topo-d", "#85E1F0");
        dicionario.Add("btn-pup-base-e", "#FF8096");
        dicionario.Add("btn-pup-topo-e", "#85E1F0");
        dicionario.Add("placa-externa", "#FF8096");
        dicionario.Add("placa-interna", "#85E1F0");
        dicionario.Add("setas-laterais", "#00BEDD");
        dicionario.Add("seta-cima", "#00BEDD");
        dicionario.Add("divisoria", "#00BEDD");
        dicionario.Add("digitos", "#00BEDD");
        dicionario.Add("circulo-externo", "#FF8096");
        dicionario.Add("circulo-interno", "#6CAED9");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }   

    public override int recuperarQtdPup(PowerUpEnums.TIPO powerupTipo)
    {
        if(powerupTipo == PowerUpEnums.TIPO.BOMBA_DA_GARRA)
        {
            return 1;
        }
        return 0;
    }

    public override MainGameEventosTutorial getMainGameEventos(MainGameManagers mainGameManagers)
    {
        return new MainGameEventosTutorial(mainGameManagers, new Tutorial());
    }
}
