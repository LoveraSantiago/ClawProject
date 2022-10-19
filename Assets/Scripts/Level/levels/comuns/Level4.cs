using System.Collections.Generic;

public class Level4 : AbstractLevelOrdem
{
    public override string getLevelTitle()
    {
        return "Nível 4";
    }     

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            { 1,  1,  1,  1,  1,  1,  1},
            { 2,  2,  2,  2,  2,  2, -1},
            {-1,  5,  5,  5,  5,  5, -1},
            {-1,  6,  6,  6,  6,  0, -1},
            {-1, -1,  3,  3,  3, -1, -1},
            {-1, -1,  4,  4, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}};
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        return new PowerUpsParaLevel(1)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.DESCARTE,
               PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.DESCARTE});
    }

    public override BoardOrdem[] getBoardOrdem()
    {
        BoardOrdem[] ordem = new BoardOrdem[]{
        new BoardOrdem(1, "28"),
        new BoardOrdem(2, "27"),
        new BoardOrdem(3, "26"),
        new BoardOrdem(4, "24"),
        new BoardOrdem(5, "25"),
        new BoardOrdem(6, "23"),
        new BoardOrdem(7, "22"),
        new BoardOrdem(8, "21"),
        new BoardOrdem(9, "20"),
        new BoardOrdem(10, "19"),
        new BoardOrdem(11, "15"),
        new BoardOrdem(12, "14"),
        new BoardOrdem(13, "16"),
        new BoardOrdem(14, "18"),
        new BoardOrdem(15, "17"),
        new BoardOrdem(16, "13"),
        new BoardOrdem(17, "12"),
        new BoardOrdem(18, "11"),
        new BoardOrdem(19, "10"),
        new BoardOrdem(20, "9"),
        new BoardOrdem(21, "8"),
        new BoardOrdem(22, "4"),
        new BoardOrdem(23, "1"),
        new BoardOrdem(24, "7"),
        new BoardOrdem(25, "6"),
        new BoardOrdem(26, "2"),
        new BoardOrdem(27, "5"),
        new BoardOrdem(28, "3")};
        return ordem;
    }    

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override Challenge[] getChallenges()
    {
        return new Challenge[] {
            new ChallengeCombinacaoColetaveis(this, 5, 5, 5),            
            new ChallengeCombinacaoColetaveisTempoMaior(this, 1, 1, 1, "00:40"),
            new ChallengeSubidasDaGarraMaior(5)
        };
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, LevelUtils.TIMER_ZERO);
    }

    public override string getMaquinaNome()
    {
        return "Moderada Profissional";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //02. Subdued & Professional
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#90AFC5");
        dicionario.Add("base-chao", "#336B87");
        dicionario.Add("chao-dentro", "#2A3132");
        dicionario.Add("cabo-da-garra", "#2A3132");
        dicionario.Add("viga", "#5480A0");
        dicionario.Add("barra", "#336B87");
        dicionario.Add("placa-timer", "#336B87");
        dicionario.Add("display-timer-digito", "#2A3132");
        dicionario.Add("seg", "#763626");
        dicionario.Add("placa-coletados", "#336B87");
        dicionario.Add("display-coletado1", "#2A3132");
        dicionario.Add("display-coletado2", "#2A3132");
        dicionario.Add("display-coletado3", "#2A3132");
        dicionario.Add("placa-scores", "#336B87");
        dicionario.Add("display-pontos1", "#2A3132");
        dicionario.Add("display-pontos2", "#2A3132");
        dicionario.Add("display-pontos3", "#2A3132");
        dicionario.Add("leds", "#763626");
        dicionario.Add("topo", "#336B87");
        dicionario.Add("base", "#90AFC5");
        dicionario.Add("mesa-joystick-cima", "#336B87");
        dicionario.Add("mesa-joystick-baixo", "#2B5A72");
        dicionario.Add("buraco-joystick", "#2A3132");
        dicionario.Add("haste-joystick", "#336B87");
        dicionario.Add("bola-joystick", "#90AFC5");
        dicionario.Add("buraco-botao", "#2A3132");
        dicionario.Add("botao", "#90AFC5");
        dicionario.Add("buraco-ficha", "#90AFC5");
        dicionario.Add("buraco-card", "#90AFC5");
        dicionario.Add("triangulo-card", "#90AFC5");
        dicionario.Add("btn-pup-base-d", "#763626");
        dicionario.Add("btn-pup-topo-d", "#90AFC5");
        dicionario.Add("btn-pup-base-e", "#763626");
        dicionario.Add("btn-pup-topo-e", "#90AFC5");
        dicionario.Add("placa-externa", "#336B87");
        dicionario.Add("placa-interna", "#2A3132");
        dicionario.Add("setas-laterais", "#763626");
        dicionario.Add("seta-cima", "#763626");
        dicionario.Add("divisoria", "#90AFC5");
        dicionario.Add("digitos", "#000000");        
        dicionario.Add("circulo-externo", "#B05139");
        dicionario.Add("circulo-interno", "#276777");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }    
}
