using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaCorArFrescoNatural : MaquinaCor
{
    public string getNome()
    {
        return "Ar fresco Natural";
    }

    public Dictionary<string, string> getCores()
    {
        //06. Outdoorsy & Natural
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#2E4600");
        dicionario.Add("base-chao", "#243800");
        dicionario.Add("chao-dentro", "#A2C523");
        dicionario.Add("cabo-da-garra", "#C46E43");
        dicionario.Add("viga", "#243800");
        dicionario.Add("barra", "#A2C523");
        dicionario.Add("placa-timer", "#A2C523");
        dicionario.Add("display-timer-digito", "#CFE777");
        dicionario.Add("seg", "#A2C523");
        dicionario.Add("placa-coletados", "#A2C523");
        dicionario.Add("display-coletado1", "#CFE777");
        dicionario.Add("display-coletado2", "#CFE777");
        dicionario.Add("display-coletado3", "#CFE777");
        dicionario.Add("placa-scores", "#A2C523");
        dicionario.Add("display-pontos1", "#CFE777");
        dicionario.Add("display-pontos2", "#CFE777");
        dicionario.Add("display-pontos3", "#CFE777");
        dicionario.Add("leds", "#A2C523");
        dicionario.Add("topo", "#486B00");
        dicionario.Add("base", "#A8B937");
        dicionario.Add("mesa-joystick-cima", "#7D4427");
        dicionario.Add("mesa-joystick-baixo", "#7D4427");
        dicionario.Add("buraco-joystick", "#59301C");
        dicionario.Add("haste-joystick", "#C3C3C3");
        dicionario.Add("bola-joystick", "#C46E43");
        dicionario.Add("buraco-botao", "#59301C");
        dicionario.Add("botao", "#C46E43");
        dicionario.Add("buraco-ficha", "#C46E43");
        dicionario.Add("buraco-card", "#C46E43");
        dicionario.Add("triangulo-card", "#C46E43");
        dicionario.Add("btn-pup-base-d", "#6A3A22");
        dicionario.Add("btn-pup-topo-d", "#C46E43");
        dicionario.Add("btn-pup-base-e", "#6A3A22");
        dicionario.Add("btn-pup-topo-e", "#C46E43");
        dicionario.Add("placa-externa", "#6A3A22");
        dicionario.Add("placa-interna", "#C46E43");
        dicionario.Add("setas-laterais", "#CFE777");
        dicionario.Add("seta-cima", "#CFE777");
        dicionario.Add("divisoria", "#2E4600");
        dicionario.Add("digitos", "#A2C523");
        dicionario.Add("circulo-externo", "#A2C523");
        dicionario.Add("circulo-interno", "#CFE777");
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
