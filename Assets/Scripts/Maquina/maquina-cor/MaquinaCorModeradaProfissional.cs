using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaCorModeradaProfissional : MaquinaCor
{
    public string getNome()
    {
        return "Moderada Profissional";
    }

    public Dictionary<string, string> getCores()
    {
        //02. Subdued & Professional
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#90AFC5");
        dicionario.Add("base-chao", "#336B87");
        dicionario.Add("chao-dentro", "#2A3132");
        dicionario.Add("cabo-da-garra", "#2A3132");
        dicionario.Add("viga", "#5480A0");
        dicionario.Add("barra", "#336B87");
        dicionario.Add("placa-timer", "#336B87");
        dicionario.Add("display-timer-digito", "#2A3132");
        dicionario.Add("seg", "#763626");
        dicionario.Add("placa-coletados", "#336B87");
        dicionario.Add("display-coletado1", "#2A3132");
        dicionario.Add("display-coletado2", "#2A3132");
        dicionario.Add("display-coletado3", "#2A3132");
        dicionario.Add("placa-scores", "#336B87");
        dicionario.Add("display-pontos1", "#2A3132");
        dicionario.Add("display-pontos2", "#2A3132");
        dicionario.Add("display-pontos3", "#2A3132");
        dicionario.Add("leds", "#763626");
        dicionario.Add("topo", "#336B87");
        dicionario.Add("base", "#90AFC5");
        dicionario.Add("mesa-joystick-cima", "#336B87");
        dicionario.Add("mesa-joystick-baixo", "#2B5A72");
        dicionario.Add("buraco-joystick", "#2A3132");
        dicionario.Add("haste-joystick", "#336B87");
        dicionario.Add("bola-joystick", "#90AFC5");
        dicionario.Add("buraco-botao", "#2A3132");
        dicionario.Add("botao", "#90AFC5");
        dicionario.Add("buraco-ficha", "#90AFC5");
        dicionario.Add("buraco-card", "#90AFC5");
        dicionario.Add("triangulo-card", "#90AFC5");
        dicionario.Add("btn-pup-base-d", "#763626");
        dicionario.Add("btn-pup-topo-d", "#90AFC5");
        dicionario.Add("btn-pup-base-e", "#763626");
        dicionario.Add("btn-pup-topo-e", "#90AFC5");
        dicionario.Add("placa-externa", "#336B87");
        dicionario.Add("placa-interna", "#2A3132");
        dicionario.Add("setas-laterais", "#763626");
        dicionario.Add("seta-cima", "#763626");
        dicionario.Add("divisoria", "#90AFC5");
        dicionario.Add("digitos", "#000000");
        dicionario.Add("circulo-externo", "#B05139");
        dicionario.Add("circulo-interno", "#276777");
        return dicionario;
    }

    public bool isLevelAlbedo0()
    {
        return true;
    }

    public bool isLevelAlbedo0Timer2Pontos()
    {
        return true;
    }
}
