using System.Collections.Generic;

public class LevelPowerUp : AbstractLevel
{
    public override string getLevelTitle()
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
            {0, 1, 2, 3, 4, 5, 6},
            {1, 2, 3, 4, 5, 6, -1},
            {0, 1, 2, 3, 4, 5, 6},
            {1, 2, 3, 4, 5, 6, -1},
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

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }

    public override string getMaquinaNome()
    {
        return "Agua Azul Esverdeada";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //07. Watery Blue-Greens
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#6FB98F");
        dicionario.Add("base-chao", "#2C7873");
        dicionario.Add("chao-dentro", "#2C7873");
        dicionario.Add("cabo-da-garra", "#FFFFFF");
        dicionario.Add("viga", "#4C9D6F");
        dicionario.Add("barra", "#2C7873");
        dicionario.Add("placa-timer", "#021C1E");
        dicionario.Add("display-timer-digito", "#2C7873");
        dicionario.Add("seg", "#C1E1CF");
        dicionario.Add("placa-coletados", "#021C1E");
        dicionario.Add("display-coletado1", "#C1E1CF");
        dicionario.Add("display-coletado2", "#C1E1CF");
        dicionario.Add("display-coletado3", "#C1E1CF");
        dicionario.Add("placa-scores", "#021C1E");
        dicionario.Add("display-pontos1", "#2C7873");
        dicionario.Add("display-pontos2", "#2C7873");
        dicionario.Add("display-pontos3", "#2C7873");
        dicionario.Add("leds", "#C1E1CF");
        dicionario.Add("topo", "#2C7873");
        dicionario.Add("base", "#C1E1CF");
        dicionario.Add("mesa-joystick-cima", "#004445");
        dicionario.Add("mesa-joystick-baixo", "#004445");
        dicionario.Add("buraco-joystick", "#021C1E");
        dicionario.Add("haste-joystick", "#B7B7B7");
        dicionario.Add("bola-joystick", "#6FB98F");
        dicionario.Add("buraco-botao", "#021C1E");
        dicionario.Add("botao", "#6FB98F");
        dicionario.Add("buraco-ficha", "#6FB98F");
        dicionario.Add("buraco-card", "#6FB98F");
        dicionario.Add("triangulo-card", "#6FB98F");
        dicionario.Add("btn-pup-base-d", "#2C7873");
        dicionario.Add("btn-pup-topo-d", "#6FB98F");
        dicionario.Add("btn-pup-base-e", "#2C7873");
        dicionario.Add("btn-pup-topo-e", "#6FB98F");
        dicionario.Add("placa-externa", "#021C1E");
        dicionario.Add("placa-interna", "#2C7873");
        dicionario.Add("setas-laterais", "#2C7873");
        dicionario.Add("seta-cima", "#2C7873");
        dicionario.Add("divisoria", "#C1E1CF");
        dicionario.Add("digitos", "#C1E1CF");
        dicionario.Add("circulo-externo", "#021C1E");
        dicionario.Add("circulo-interno", "#2C7873");
        return dicionario;        
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }    
}
