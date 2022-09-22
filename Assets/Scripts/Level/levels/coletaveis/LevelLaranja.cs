using System.Collections.Generic;

public class LevelLaranja : AbstractLevelColetavel
{
    public override string getLevelTitle()
    {
        return "Level Laranja";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {5, 5, 2, 2, 2, 5, 5},
            {1, 1, 1, 1, 1, 1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }    

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public override string getMaquinaNome()
    {
        return "Outono Natural";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //13. Autumn in Vermont
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#8D230F");
        dicionario.Add("base-chao", "#9B4F0F");
        dicionario.Add("chao-dentro", "#9B4F0F");
        dicionario.Add("cabo-da-garra", "#F1CC52");
        dicionario.Add("viga", "#661A0B");
        dicionario.Add("barra", "#9B4F0F");
        dicionario.Add("placa-timer", "#1E434C");
        dicionario.Add("display-timer-digito", "#3F8C9F");
        dicionario.Add("seg", "#1E434C");
        dicionario.Add("placa-coletados", "#1E434C");
        dicionario.Add("display-coletado1", "#3F8C9F");
        dicionario.Add("display-coletado2", "#3F8C9F");
        dicionario.Add("display-coletado3", "#3F8C9F");
        dicionario.Add("placa-scores", "#1E434C");
        dicionario.Add("display-pontos1", "#3F8C9F");
        dicionario.Add("display-pontos2", "#3F8C9F");
        dicionario.Add("display-pontos3", "#3F8C9F");
        dicionario.Add("leds", "#1E434C");
        dicionario.Add("topo", "#9B4F0F");
        dicionario.Add("base", "#F1CC52");
        dicionario.Add("mesa-joystick-cima", "#C99E10");
        dicionario.Add("mesa-joystick-baixo", "#C99E10");
        dicionario.Add("buraco-joystick", "#8D230F");
        dicionario.Add("haste-joystick", "#E2E2E2");
        dicionario.Add("bola-joystick", "#9B4F0F");
        dicionario.Add("buraco-botao", "#8D230F");
        dicionario.Add("botao", "#9B4F0F");
        dicionario.Add("buraco-ficha", "#9B4F0F");
        dicionario.Add("buraco-card", "#9B4F0F");
        dicionario.Add("triangulo-card", "#9B4F0F");
        dicionario.Add("btn-pup-base-d", "#8D230F");
        dicionario.Add("btn-pup-topo-d", "#9B4F0F");
        dicionario.Add("btn-pup-base-e", "#8D230F");
        dicionario.Add("btn-pup-topo-e", "#9B4F0F");
        dicionario.Add("placa-externa", "#9B4F0F");
        dicionario.Add("placa-interna", "#1E434C");
        dicionario.Add("setas-laterais", "#F1CC52");
        dicionario.Add("seta-cima", "#F1CC52");
        dicionario.Add("divisoria", "#C99E10");
        dicionario.Add("digitos", "#000000");
        dicionario.Add("circulo-externo", "#9B4F0F");
        dicionario.Add("circulo-interno", "#C99E10");
        return dicionario;
    }   
}
