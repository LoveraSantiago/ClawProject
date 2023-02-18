using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaCorChocolateComMorango : MaquinaCor
{
    public string getNome()
    {
        return "Chocolate com Morango";
    }

    public Dictionary<string, string> getCores()
    {
        //15. Birds & Berries
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#7D484D");
        dicionario.Add("base-chao", "#DFE166");
        dicionario.Add("chao-dentro", "#EC96A4");
        dicionario.Add("cabo-da-garra", "#98ECDE");
        dicionario.Add("viga", "#6C3E43");
        dicionario.Add("barra", "#DFE166");
        dicionario.Add("placa-timer", "#9A9EAB");
        dicionario.Add("display-timer-digito", "#5D535E");
        dicionario.Add("seg", "#EC96A4");
        dicionario.Add("placa-coletados", "#9A9EAB");
        dicionario.Add("display-coletado1", "#5D535E");
        dicionario.Add("display-coletado2", "#5D535E");
        dicionario.Add("display-coletado3", "#5D535E");
        dicionario.Add("placa-scores", "#9A9EAB");
        dicionario.Add("display-pontos1", "#5D535E");
        dicionario.Add("display-pontos2", "#5D535E");
        dicionario.Add("display-pontos3", "#5D535E");
        dicionario.Add("leds", "#EC96A4");
        dicionario.Add("topo", "#E3CF69");
        dicionario.Add("base", "#9A9EAB");
        dicionario.Add("mesa-joystick-cima", "#DFE166");
        dicionario.Add("mesa-joystick-baixo", "#DFE166");
        dicionario.Add("buraco-joystick", "#ECDE98");
        dicionario.Add("haste-joystick", "#9A9EAB");
        dicionario.Add("bola-joystick", "#ECDE98");
        dicionario.Add("buraco-botao", "#EC96A4");
        dicionario.Add("botao", "#ECDE98");
        dicionario.Add("buraco-ficha", "#EC96A4");
        dicionario.Add("buraco-card", "#EC96A4");
        dicionario.Add("triangulo-card", "#EC96A4");
        dicionario.Add("btn-pup-base-d", "#E3CF69");
        dicionario.Add("btn-pup-topo-d", "#EC96A4");
        dicionario.Add("btn-pup-base-e", "#E3CF69");
        dicionario.Add("btn-pup-topo-e", "#EC96A4");
        dicionario.Add("placa-externa", "#EC96A4");
        dicionario.Add("placa-interna", "#ECDE98");
        dicionario.Add("setas-laterais", "#E3CF69");
        dicionario.Add("seta-cima", "#E3CF69");
        dicionario.Add("divisoria", "#5D535E");
        dicionario.Add("digitos", "#5D535E");
        dicionario.Add("circulo-externo", "#DFE166");
        dicionario.Add("circulo-interno", "#EC96A4");
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
