using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaCorBrilhanteFresco : MaquinaCor
{
    
    public string getNome()
    {
        return "Brilhante Fresco";
    }


    public Dictionary<string, string> getCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#89DA59");
        dicionario.Add("base-chao", "#80BD9E");
        dicionario.Add("chao-dentro", "#80BD9E");
        dicionario.Add("cabo-da-garra", "#FF420E");
        dicionario.Add("viga", "#64C52B");
        dicionario.Add("barra", "#F98866");
        dicionario.Add("placa-timer", "#80BD9E");
        dicionario.Add("display-timer-digito", "#BBEA9F");
        dicionario.Add("seg", "#FABB66");
        dicionario.Add("placa-coletados", "#80BD9E");
        dicionario.Add("display-coletado1", "#BBEA9F");
        dicionario.Add("display-coletado2", "#BBEA9F");
        dicionario.Add("display-coletado3", "#BBEA9F");
        dicionario.Add("placa-scores", "#80BD9E");
        dicionario.Add("display-pontos1", "#BBEA9F");
        dicionario.Add("display-pontos2", "#BBEA9F");
        dicionario.Add("display-pontos3", "#BBEA9F");
        dicionario.Add("leds", "#FABB66");
        dicionario.Add("topo", "#80BD9E");
        dicionario.Add("base", "#F98866");
        dicionario.Add("mesa-joystick-cima", "#FF420E");
        dicionario.Add("mesa-joystick-baixo", "#E83200");
        dicionario.Add("buraco-joystick", "#80BD9E");
        dicionario.Add("haste-joystick", "#89DA59");
        dicionario.Add("bola-joystick", "#F98866");
        dicionario.Add("buraco-botao", "#80BD9E");
        dicionario.Add("botao", "#F98866");
        dicionario.Add("buraco-ficha", "#F98866");
        dicionario.Add("buraco-card", "#F98866");
        dicionario.Add("triangulo-card", "#F98866");
        dicionario.Add("btn-pup-base-d", "#80BD9E");
        dicionario.Add("btn-pup-topo-d", "#BBEA9F");
        dicionario.Add("btn-pup-base-e", "#80BD9E");
        dicionario.Add("btn-pup-topo-e", "#BBEA9F");
        dicionario.Add("placa-externa", "#FF420E");
        dicionario.Add("placa-interna", "#BBEA9F");
        dicionario.Add("setas-laterais", "#F98866");
        dicionario.Add("seta-cima", "#F98866");
        dicionario.Add("divisoria", "#80BD9E");
        dicionario.Add("digitos", "#FABB66");
        dicionario.Add("circulo-externo", "#80BD9E");
        dicionario.Add("circulo-interno", "#BBEA9F");
        return dicionario;
    }

    public bool isLevelAlbedo0()
    {
        return false;
    }
}
