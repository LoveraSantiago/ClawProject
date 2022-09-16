using System.Collections.Generic;

public class LevelEstrelaMarinha : AbstractLevelColetavel
{
    public override string getLevelTitle()
    {
        return "Level EstrelaMarinha";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]{
            {16, 15, 15, 15, 15, 15, 15},
            {14, 14, 14, 14, 14, 14, 0},
            {13, 13, 13, 13, 13, 13, 16},
            {12, 12, 12, 12, 12, 12, 0},
            {16, 11, 11, 11, 11, 11, 11},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 16;
    }

    public override string getMaquinaNome()
    {
        return "Iceberg Gelada";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //14. Icy Blues and Grays
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#F1F1F2");
        dicionario.Add("base-chao", "#BCBABE");
        dicionario.Add("chao-dentro", "#BCBABE");
        dicionario.Add("cabo-da-garra", "#A1D6E2");
        dicionario.Add("viga", "#CECED2");
        dicionario.Add("barra", "#BCBABE");
        dicionario.Add("placa-timer", "#BCBABE");
        dicionario.Add("display-timer-digito", "#A1D6E2");
        dicionario.Add("seg", "#1995AD");
        dicionario.Add("placa-coletados", "#BCBABE");
        dicionario.Add("display-coletado1", "#A1D6E2");
        dicionario.Add("display-coletado2", "#A1D6E2");
        dicionario.Add("display-coletado3", "#A1D6E2");
        dicionario.Add("placa-scores", "#BCBABE");
        dicionario.Add("display-pontos1", "#A1D6E2");
        dicionario.Add("display-pontos2", "#A1D6E2");
        dicionario.Add("display-pontos3", "#A1D6E2");
        dicionario.Add("leds", "#1995AD");
        dicionario.Add("topo", "#1995AD");
        dicionario.Add("base", "#A1D6E2");
        dicionario.Add("mesa-joystick-cima", "#A1D6E2");
        dicionario.Add("mesa-joystick-baixo", "#77C4D5");
        dicionario.Add("buraco-joystick", "#1995AD");
        dicionario.Add("haste-joystick", "#BCBABE");
        dicionario.Add("bola-joystick", "#1995AD");
        dicionario.Add("buraco-botao", "#1995AD");
        dicionario.Add("botao", "#BCBABE");
        dicionario.Add("buraco-ficha", "#BCBABE");
        dicionario.Add("buraco-card", "#BCBABE");
        dicionario.Add("triangulo-card", "#BCBABE");
        dicionario.Add("btn-pup-base-d", "#1995AD");
        dicionario.Add("btn-pup-topo-d", "#F1F1F2");
        dicionario.Add("btn-pup-base-e", "#1995AD");
        dicionario.Add("btn-pup-topo-e", "#F1F1F2");
        dicionario.Add("placa-externa", "#BCBABE");
        dicionario.Add("placa-interna", "#A1D6E2");
        dicionario.Add("setas-laterais", "#1995AD");
        dicionario.Add("seta-cima", "#1995AD");
        dicionario.Add("divisoria", "#F1F1F2");
        dicionario.Add("digitos", "#A1D6E2");
        dicionario.Add("circulo-externo", "#1995AD");
        dicionario.Add("circulo-interno", "#CECED2");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }    
}
