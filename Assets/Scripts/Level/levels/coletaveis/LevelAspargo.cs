using System.Collections.Generic;

public class LevelAspargo : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {16, 16, 16, 16, 16, 16, 14},
            {16, 16, 16, 16, 16, 14, 0},
            {16, 16, 16, 16, 16, 14, 16},
            {16, 16, 16, 16, 16, 16, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 14;
    }

    public override string getMaquinaNome()
    {
        return "Frescor Energetica";
    }

    protected override Dictionary<string, string> getCoresMaquina()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#F4CC70");
        dicionario.Add("base-chao", "#DE7A22");
        dicionario.Add("chao-dentro", "#6AB187");
        dicionario.Add("cabo-da-garra", "#FFFFFF");
        dicionario.Add("viga", "#EFB42A");
        dicionario.Add("barra", "#6AB187");
        dicionario.Add("placa-timer", "#DE7A22");
        dicionario.Add("display-timer-digito", "#F4CC70");
        dicionario.Add("seg", "#F9E2AE");
        dicionario.Add("placa-coletados", "#DE7A22");
        dicionario.Add("display-coletado1", "#F4CC70");
        dicionario.Add("display-coletado2", "#F4CC70");
        dicionario.Add("display-coletado3", "#F4CC70");
        dicionario.Add("placa-scores", "#DE7A22");
        dicionario.Add("display-pontos1", "#F4CC70");
        dicionario.Add("display-pontos2", "#F4CC70");
        dicionario.Add("display-pontos3", "#F4CC70");
        dicionario.Add("leds", "#F9E2AE");
        dicionario.Add("topo", "#F4CC70");
        dicionario.Add("base", "#F9E2AE");
        dicionario.Add("mesa-joystick-cima", "#DE7A22");
        dicionario.Add("mesa-joystick-baixo", "#BE681C");
        dicionario.Add("buraco-joystick", "#20948B");
        dicionario.Add("haste-joystick", "#BCBCBC");
        dicionario.Add("bola-joystick", "#F4CC70");
        dicionario.Add("buraco-botao", "#20948B");
        dicionario.Add("botao", "#F4CC70");
        dicionario.Add("buraco-ficha", "#6AB187");
        dicionario.Add("buraco-card", "#6AB187");
        dicionario.Add("triangulo-card", "#6AB187");
        dicionario.Add("btn-pup-base-d", "#F4CC70");
        dicionario.Add("btn-pup-topo-d", "#F9E2AE");
        dicionario.Add("btn-pup-base-e", "#F4CC70");
        dicionario.Add("btn-pup-topo-e", "#F9E2AE");
        dicionario.Add("placa-externa", "#6AB187");
        dicionario.Add("placa-interna", "#F4CC70");
        dicionario.Add("setas-laterais", "#DE7A22");
        dicionario.Add("seta-cima", "#DE7A22");
        dicionario.Add("divisoria", "#BE681C");
        dicionario.Add("digitos", "#F9E2AE");
        dicionario.Add("circulo-externo", "#20948B");
        dicionario.Add("circulo-interno", "#6AB187");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }    
}
