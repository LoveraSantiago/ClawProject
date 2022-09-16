using System.Collections.Generic;

public class LevelCoco : AbstractLevelColetavel
{
    public override string getLevelTitle()
    {
        return "Level Coco";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {15, 13, 13, 13, 13, 13, 13},
            {12, 15, 12, 12, 12, 12, 0},
            {11, 11, 11, 15, 11, 11, 11},
            {10, 10, 10, 10, 10, 10, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 15;
    }

    public override string getMaquinaNome()
    {
        return "Frescor Energetica";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {   
        //11. Fresh & Energetic
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#4CB5F5");
        dicionario.Add("base-chao", "#838482");
        dicionario.Add("chao-dentro", "#B3C100");
        dicionario.Add("cabo-da-garra", "#DBDCDB");
        dicionario.Add("viga", "#4C97F5");
        dicionario.Add("barra", "#B3C100");
        dicionario.Add("placa-timer", "#B7B8B6");
        dicionario.Add("display-timer-digito", "#DBDCDB");
        dicionario.Add("seg", "#FFFFFF");
        dicionario.Add("placa-coletados", "#B7B8B6");
        dicionario.Add("display-coletado1", "#DBDCDB");
        dicionario.Add("display-coletado2", "#DBDCDB");
        dicionario.Add("display-coletado3", "#DBDCDB");
        dicionario.Add("placa-scores", "#B7B8B6");
        dicionario.Add("display-pontos1", "#DBDCDB");
        dicionario.Add("display-pontos2", "#DBDCDB");
        dicionario.Add("display-pontos3", "#DBDCDB");
        dicionario.Add("leds", "#FFFFFF");
        dicionario.Add("topo", "#B3C100");
        dicionario.Add("base", "#F6FF77");
        dicionario.Add("mesa-joystick-cima", "#34675C");
        dicionario.Add("mesa-joystick-baixo", "#2C574E");
        dicionario.Add("buraco-joystick", "#838482");
        dicionario.Add("haste-joystick", "#B7B8B6");
        dicionario.Add("bola-joystick", "#838482");
        dicionario.Add("buraco-botao", "#838482");
        dicionario.Add("botao", "#B7B8B6");
        dicionario.Add("buraco-ficha", "#B7B8B6");
        dicionario.Add("buraco-card", "#B7B8B6");
        dicionario.Add("triangulo-card", "#B7B8B6");
        dicionario.Add("btn-pup-base-d", "#B7B8B6");
        dicionario.Add("btn-pup-topo-d", "#DBDCDB");
        dicionario.Add("btn-pup-base-e", "#B7B8B6");
        dicionario.Add("btn-pup-topo-e", "#DBDCDB");
        dicionario.Add("placa-externa", "#B7B8B6");
        dicionario.Add("placa-interna", "#DBDCDB");
        dicionario.Add("setas-laterais", "#34675C");
        dicionario.Add("seta-cima", "#34675C");
        dicionario.Add("divisoria", "#838482");
        dicionario.Add("digitos", "#FFFFFF");
        dicionario.Add("circulo-externo", "#838482");
        dicionario.Add("circulo-interno", "#4D9988");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }   
}
