using System.Collections.Generic;

public class MaquinaCorCarvaoCarbonita : MaquinaCor
{
    public string getNome()
    {
        return "Carvão Carbonita";
    }
    public Dictionary<string, string> getCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#000000");
        dicionario.Add("base-chao", "#5D5B5B");
        dicionario.Add("chao-dentro", "#606986");
        dicionario.Add("cabo-da-garra", "#FFFFFF");
        dicionario.Add("viga", "#000000");
        dicionario.Add("barra", "#606986");
        dicionario.Add("placa-timer", "#BEBEBE");
        dicionario.Add("display-timer-digito", "#3A3A3A");
        dicionario.Add("seg", "#5D5B5B");
        dicionario.Add("placa-coletados", "#BEBEBE");
        dicionario.Add("display-coletado1", "#3A3A3A");
        dicionario.Add("display-coletado2", "#3A3A3A");
        dicionario.Add("display-coletado3", "#3A3A3A");
        dicionario.Add("placa-scores", "#BEBEBE");
        dicionario.Add("display-pontos1", "#3A3A3A");
        dicionario.Add("display-pontos2", "#3A3A3A");
        dicionario.Add("display-pontos3", "#3A3A3A");
        dicionario.Add("leds", "#5D5B5B");
        dicionario.Add("topo", "#606986");
        dicionario.Add("base", "#FFFFFF");
        dicionario.Add("mesa-joystick-cima", "#575757");
        dicionario.Add("mesa-joystick-baixo", "#575757");
        dicionario.Add("buraco-joystick", "#606986");
        dicionario.Add("haste-joystick", "#BEBEBE");
        dicionario.Add("bola-joystick", "#FFFFFF");
        dicionario.Add("buraco-botao", "#606986");
        dicionario.Add("botao", "#FFFFFF");
        dicionario.Add("buraco-ficha", "#BEBEBE");
        dicionario.Add("buraco-card", "#BEBEBE");
        dicionario.Add("triangulo-card", "#FFFFFF");
        dicionario.Add("btn-pup-base-d", "#BEBEBE");
        dicionario.Add("btn-pup-topo-d", "#5D5B5B");
        dicionario.Add("btn-pup-base-e", "#BEBEBE");
        dicionario.Add("btn-pup-topo-e", "#5D5B5B");
        dicionario.Add("placa-externa", "#BEBEBE");
        dicionario.Add("placa-interna", "#3A3A3A");
        dicionario.Add("setas-laterais", "#606986");
        dicionario.Add("seta-cima", "#606986");
        dicionario.Add("divisoria", "#FFFFFF");
        dicionario.Add("digitos", "#3A3A3A");
        dicionario.Add("circulo-externo", "#FFFFFF");
        dicionario.Add("circulo-interno", "#606986");
        return dicionario;
    }


    public bool isLevelAlbedo0()
    {
        return false;
    }

    public bool isLevelAlbedo0Timer2Pontos()
    {
        return false;
    }
}
