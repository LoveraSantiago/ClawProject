using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaCorFrescorEnergetica : MaquinaCor
{
    public string getNome()
    {
        return "Frescor Energetica";
    }

    public Dictionary<string, string> getCores()
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

    public bool isLevelAlbedo0()
    {
        return false;
    }

    public bool isLevelAlbedo0Timer2Pontos()
    {
        return false;
    }
}
