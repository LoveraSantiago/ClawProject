using System.Collections.Generic;

public class LevelPao : AbstractLevelColetavel
{
    public override string getLevelTitle()
    {
        return "Level Pao";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {3, 1, 2, 3, 4, 5, 3},
            {6, 5, 4, 2, 1, 0, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };        
    }
    
    public override string getMaquinaNome()
    {
        return "Vibrante Primaria";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //08. Primary Colors With a Vibrant Twist
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#FB6542");
        dicionario.Add("base-chao", "#3F681C");
        dicionario.Add("chao-dentro", "#3F681C");
        dicionario.Add("cabo-da-garra", "#41D9FB");
        dicionario.Add("viga", "#FB512B");
        dicionario.Add("barra", "#375E97");
        dicionario.Add("placa-timer", "#FFBB00");
        dicionario.Add("display-timer-digito", "#FFE292");
        dicionario.Add("seg", "#FFBB00");
        dicionario.Add("placa-coletados", "#375E97");
        dicionario.Add("display-coletado1", "#6E93CB");
        dicionario.Add("display-coletado2", "#6E93CB");
        dicionario.Add("display-coletado3", "#6E93CB");
        dicionario.Add("placa-scores", "#3F681C");
        dicionario.Add("display-pontos1", "#81CC3F");
        dicionario.Add("display-pontos2", "#81CC3F");
        dicionario.Add("display-pontos3", "#81CC3F");
        dicionario.Add("leds", "#A4DA75");
        dicionario.Add("topo", "#FFBB00");
        dicionario.Add("base", "#FFE292");
        dicionario.Add("mesa-joystick-cima", "#375E97");
        dicionario.Add("mesa-joystick-baixo", "#375E97");
        dicionario.Add("buraco-joystick", "#3F681C");
        dicionario.Add("haste-joystick", "#FFBB00");
        dicionario.Add("bola-joystick", "#FB512B");
        dicionario.Add("buraco-botao", "#3F681C");
        dicionario.Add("botao", "#FB512B");
        dicionario.Add("buraco-ficha", "#3F681C");
        dicionario.Add("buraco-card", "#3F681C");
        dicionario.Add("triangulo-card", "#3F681C");
        dicionario.Add("btn-pup-base-d", "#FFBB00");
        dicionario.Add("btn-pup-topo-d", "#FB512B");
        dicionario.Add("btn-pup-base-e", "#FFBB00");
        dicionario.Add("btn-pup-topo-e", "#FB512B");
        dicionario.Add("placa-externa", "#FFBB00");
        dicionario.Add("placa-interna", "#FFE292");
        dicionario.Add("setas-laterais", "#375E97");
        dicionario.Add("seta-cima", "#375E97");
        dicionario.Add("divisoria", "#3F681C");
        dicionario.Add("digitos", "#FFBB00");
        dicionario.Add("circulo-externo", "#375E97");
        dicionario.Add("circulo-interno", "#41D9FB");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }       
}
