using System.Collections.Generic;

public class LevelMaca : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {13, 12, 15, 11, 14, 14, 15},
            {0, 16, 11, 11, 13, 0, 0},
            {0, 0, 10, 10, 12, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 11;
    }   

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        //09. Refreshing & Pretty
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#E6D72A");
        dicionario.Add("base-chao", "#F18D9E");
        dicionario.Add("chao-dentro", "#5BC8AC");
        dicionario.Add("cabo-da-garra", "#98DBC6");
        dicionario.Add("viga", "#BEB016");
        dicionario.Add("barra", "#5BC8AC");
        dicionario.Add("placa-timer", "#F18D9E");
        dicionario.Add("display-timer-digito", "#98DBC6");
        dicionario.Add("seg", "#5BC8AC");
        dicionario.Add("placa-coletados", "#F18D9E");
        dicionario.Add("display-coletado1", "#98DBC6");
        dicionario.Add("display-coletado2", "#98DBC6");
        dicionario.Add("display-coletado3", "#98DBC6");
        dicionario.Add("placa-scores", "#F18D9E");
        dicionario.Add("display-pontos1", "#98DBC6");
        dicionario.Add("display-pontos2", "#98DBC6");
        dicionario.Add("display-pontos3", "#98DBC6");
        dicionario.Add("leds", "#5BC8AC");
        dicionario.Add("topo", "#E6D72A");
        dicionario.Add("base", "#98DBC6");
        dicionario.Add("mesa-joystick-cima", "#F18D9E");
        dicionario.Add("mesa-joystick-baixo", "#EE7589");
        dicionario.Add("buraco-joystick", "#5BC8AC");
        dicionario.Add("haste-joystick", "#98DBC6");
        dicionario.Add("bola-joystick", "#E6D72A");
        dicionario.Add("buraco-botao", "#5BC8AC");
        dicionario.Add("botao", "#E6D72A");
        dicionario.Add("buraco-ficha", "#98DBC6");
        dicionario.Add("buraco-card", "#98DBC6");
        dicionario.Add("triangulo-card", "#98DBC6");
        dicionario.Add("btn-pup-base-d", "#5BC8AC");
        dicionario.Add("btn-pup-topo-d", "#98DBC6");
        dicionario.Add("btn-pup-base-e", "#5BC8AC");
        dicionario.Add("btn-pup-topo-e", "#98DBC6");
        dicionario.Add("placa-externa", "#5BC8AC");
        dicionario.Add("placa-interna", "#98DBC6");
        dicionario.Add("setas-laterais", "#F18D9E");
        dicionario.Add("seta-cima", "#F18D9E");
        dicionario.Add("divisoria", "#F18D9E");
        dicionario.Add("digitos", "#5BC8AC");
        dicionario.Add("circulo-externo", "#F1E08E");
        dicionario.Add("circulo-interno", "#F1E08E");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorMaca();
    }    

    public class FornecedorMaca : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelMaca();
        }
    }

}
