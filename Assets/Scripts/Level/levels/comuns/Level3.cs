using System.Collections.Generic;

public class Level3 : AbstractLevelElevador
{
    public override string getLevelTitle()
    {
        return "Nível 3";
    }  

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            {  0,  1,  2,  5,  5,  5,  2 },
            {  4,  4,  4,  3,  3,  3, -1 },
            {  1,  6,  1,  6,  1,  7,  7 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 } };
    }

    public override int[,] getArrayDeColetaveisSub()
    {
        return new int[,] {
            { 0, 0, 0, 1, 1, 1, -1 },
            { 1, 1, 1, 1, 1, 1,  1 }
        };
    }
    
    public override bool devolverParaBoard()
    {
        return true;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.CONTINUA, "01:00");
        //return new TipoContagemTempoDto(ContadorTimer.Contagem.CONTINUA, "00:10");        
    }

    public override string getMaquinaNome()
    {
        return "Brilhante Fresco";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        //01.Fresh & Bright
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

    public override bool isLevelAlbedo0()
    {
        return false;
    }    
}