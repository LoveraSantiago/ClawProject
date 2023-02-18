using System.Collections.Generic;

public class MaquinaCorBonitaRefrescante : MaquinaCor
{
    public string getNome()
    {
        return "Bonita Refrescante";
    }

    public Dictionary<string, string> getCores()
    {
        //09. Refreshing & Pretty
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#E6D72A");
        dicionario.Add("base-chao", "#F18D9E");
        dicionario.Add("chao-dentro", "#5BC8AC");
        dicionario.Add("cabo-da-garra", "#98DBC6");
        dicionario.Add("viga", "#BEB016");
        dicionario.Add("barra", "#5BC8AC");
        dicionario.Add("placa-timer", "#F18D9E");
        dicionario.Add("display-timer-digito", "#98DBC6");
        dicionario.Add("seg", "#5BC8AC");
        dicionario.Add("placa-coletados", "#F18D9E");
        dicionario.Add("display-coletado1", "#98DBC6");
        dicionario.Add("display-coletado2", "#98DBC6");
        dicionario.Add("display-coletado3", "#98DBC6");
        dicionario.Add("placa-scores", "#F18D9E");
        dicionario.Add("display-pontos1", "#98DBC6");
        dicionario.Add("display-pontos2", "#98DBC6");
        dicionario.Add("display-pontos3", "#98DBC6");
        dicionario.Add("leds", "#5BC8AC");
        dicionario.Add("topo", "#E6D72A");
        dicionario.Add("base", "#98DBC6");
        dicionario.Add("mesa-joystick-cima", "#F18D9E");
        dicionario.Add("mesa-joystick-baixo", "#EE7589");
        dicionario.Add("buraco-joystick", "#5BC8AC");
        dicionario.Add("haste-joystick", "#98DBC6");
        dicionario.Add("bola-joystick", "#E6D72A");
        dicionario.Add("buraco-botao", "#5BC8AC");
        dicionario.Add("botao", "#E6D72A");
        dicionario.Add("buraco-ficha", "#98DBC6");
        dicionario.Add("buraco-card", "#98DBC6");
        dicionario.Add("triangulo-card", "#98DBC6");
        dicionario.Add("btn-pup-base-d", "#5BC8AC");
        dicionario.Add("btn-pup-topo-d", "#98DBC6");
        dicionario.Add("btn-pup-base-e", "#5BC8AC");
        dicionario.Add("btn-pup-topo-e", "#98DBC6");
        dicionario.Add("placa-externa", "#5BC8AC");
        dicionario.Add("placa-interna", "#98DBC6");
        dicionario.Add("setas-laterais", "#F18D9E");
        dicionario.Add("seta-cima", "#F18D9E");
        dicionario.Add("divisoria", "#F18D9E");
        dicionario.Add("digitos", "#5BC8AC");
        dicionario.Add("circulo-externo", "#F1E08E");
        dicionario.Add("circulo-interno", "#F1E08E");
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
