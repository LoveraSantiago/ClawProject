using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLevelCacaNiquel : AbstractLevel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
       {
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
       };
    }

    public override bool devolverParaBoard()
    {
        return false;
    }    

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }

    public override string getMaquinaNome()
    {
        return "Chiclete e Embalagem";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#B2BEC3");
        dicionario.Add("base-chao", "#2D3436");
        dicionario.Add("chao-dentro", "#636E72");
        dicionario.Add("cabo-da-garra", "#2D3436");
        dicionario.Add("viga", "#B2BEC3");
        dicionario.Add("barra", "#636E72");
        dicionario.Add("placa-timer", "#636E72");
        dicionario.Add("display-timer-digito", "#DFE6E9");
        dicionario.Add("seg", "#FFFFFF");
        dicionario.Add("placa-coletados", "#636E72");
        dicionario.Add("display-coletado1", "#DFE6E9");
        dicionario.Add("display-coletado2", "#DFE6E9");
        dicionario.Add("display-coletado3", "#DFE6E9");
        dicionario.Add("placa-scores", "#636E72");
        dicionario.Add("display-pontos1", "#DFE6E9");
        dicionario.Add("display-pontos2", "#DFE6E9");
        dicionario.Add("display-pontos3", "#DFE6E9");
        dicionario.Add("leds", "#FFFFFF");
        dicionario.Add("topo", "#636E72");
        dicionario.Add("base", "#FFFFFF");
        dicionario.Add("mesa-joystick-cima", "#2D3436");
        dicionario.Add("mesa-joystick-baixo", "#2D3436");
        dicionario.Add("buraco-joystick", "#DFE6E9");
        dicionario.Add("haste-joystick", "#DFE6E9");
        dicionario.Add("bola-joystick", "#DFE6E9");
        dicionario.Add("buraco-botao", "#636E72");
        dicionario.Add("botao", "#636E72");
        dicionario.Add("buraco-ficha", "#DFE6E9");
        dicionario.Add("buraco-card", "#DFE6E9");
        dicionario.Add("triangulo-card", "#DFE6E9");
        dicionario.Add("btn-pup-base-d", "#636E72");
        dicionario.Add("btn-pup-topo-d", "#DFE6E9");
        dicionario.Add("btn-pup-base-e", "#636E72");
        dicionario.Add("btn-pup-topo-e", "#DFE6E9");
        dicionario.Add("placa-externa", "#2D3436");
        dicionario.Add("placa-interna", "#DFE6E9");
        dicionario.Add("setas-laterais", "#636E72");
        dicionario.Add("seta-cima", "#636E72");
        dicionario.Add("divisoria", "#2D3436");
        dicionario.Add("digitos", "#2D3436");
        dicionario.Add("circulo-externo", "#2D3436");
        dicionario.Add("circulo-interno", "#DFE6E9");
        return dicionario;
    }

}
