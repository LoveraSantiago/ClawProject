using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaCorSurpresaDeAbobora : MaquinaCor
{
    public string getNome()
    {
        return "Surpresa de Abobora";
    }

    public Dictionary<string, string> getCores()
    {
        //16. Day & Night
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#063852");
        dicionario.Add("base-chao", "#011A27");
        dicionario.Add("chao-dentro", "#011A27");
        dicionario.Add("cabo-da-garra", "#C6D4FF");
        dicionario.Add("viga", "#063852");
        dicionario.Add("barra", "#011A27");
        dicionario.Add("placa-timer", "#E6DF44");
        dicionario.Add("display-timer-digito", "#063852");
        dicionario.Add("seg", "#011A27");
        dicionario.Add("placa-coletados", "#E6DF44");
        dicionario.Add("display-coletado1", "#063852");
        dicionario.Add("display-coletado2", "#063852");
        dicionario.Add("display-coletado3", "#063852");
        dicionario.Add("placa-scores", "#E6DF44");
        dicionario.Add("display-pontos1", "#063852");
        dicionario.Add("display-pontos2", "#063852");
        dicionario.Add("display-pontos3", "#063852");
        dicionario.Add("leds", "#011A27");
        dicionario.Add("topo", "#063852");
        dicionario.Add("base", "#E6DF44");
        dicionario.Add("mesa-joystick-cima", "#F0810F");
        dicionario.Add("mesa-joystick-baixo", "#F0810F");
        dicionario.Add("buraco-joystick", "#063852");
        dicionario.Add("haste-joystick", "#011A27");
        dicionario.Add("bola-joystick", "#063852");
        dicionario.Add("buraco-botao", "#063852");
        dicionario.Add("botao", "#E6DF44");
        dicionario.Add("buraco-ficha", "#E6DF44");
        dicionario.Add("buraco-card", "#E6DF44");
        dicionario.Add("triangulo-card", "#E6DF44");
        dicionario.Add("btn-pup-base-d", "#063852");
        dicionario.Add("btn-pup-topo-d", "#E6DF44");
        dicionario.Add("btn-pup-base-e", "#063852");
        dicionario.Add("btn-pup-topo-e", "#E6DF44");
        dicionario.Add("placa-externa", "#011A27");
        dicionario.Add("placa-interna", "#F0810F");
        dicionario.Add("setas-laterais", "#E6DF44");
        dicionario.Add("seta-cima", "#F0810F");
        dicionario.Add("divisoria", "#063852");
        dicionario.Add("digitos", "#063852");
        dicionario.Add("circulo-externo", "#011A27");
        dicionario.Add("circulo-interno", "#F0810F");

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
