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
        //07. Watery Blue-Greens
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#6FB98F");
        dicionario.Add("base-chao", "#2C7873");
        dicionario.Add("chao-dentro", "#2C7873");
        dicionario.Add("cabo-da-garra", "#FFFFFF");
        dicionario.Add("viga", "#4C9D6F");
        dicionario.Add("barra", "#2C7873");
        dicionario.Add("placa-timer", "#2C7873");
        dicionario.Add("display-timer-digito", "#C1E1CF");
        dicionario.Add("seg", "#021C1E");
        dicionario.Add("placa-coletados", "#2C7873");
        dicionario.Add("display-coletado1", "#C1E1CF");
        dicionario.Add("display-coletado2", "#C1E1CF");
        dicionario.Add("display-coletado3", "#C1E1CF");
        dicionario.Add("placa-scores", "#2C7873");
        dicionario.Add("display-pontos1", "#C1E1CF");
        dicionario.Add("display-pontos2", "#C1E1CF");
        dicionario.Add("display-pontos3", "#C1E1CF");
        dicionario.Add("leds", "#021C1E");
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
        dicionario.Add("placa-interna", "#C1E1CF");
        dicionario.Add("setas-laterais", "#2C7873");
        dicionario.Add("seta-cima", "#2C7873");
        dicionario.Add("divisoria", "#2C7873");
        dicionario.Add("digitos", "#021C1E");
        dicionario.Add("circulo-externo", "#021C1E");
        dicionario.Add("circulo-interno", "#2C7873");
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
