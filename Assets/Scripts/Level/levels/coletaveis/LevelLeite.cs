using System.Collections.Generic;

public class LevelLeite : AbstractLevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {10, 10, 10, 11, 12, 13, 14},
            {13, 14, 15, 16, 16, 15, 0},
            {12, 11, 12, 13, 14, 15, 16},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override int getIdColetavel()
    {
        return 10;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }


    public override Dictionary<string, string> getDicionarioDeCores()
    {
        //10. Playful Greens & Blues
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#86AC41");
        dicionario.Add("base-chao", "#34675C");
        dicionario.Add("chao-dentro", "#7DA3A1");
        dicionario.Add("cabo-da-garra", "#34675C");
        dicionario.Add("viga", "#729237");
        dicionario.Add("barra", "#7DA3A1");
        dicionario.Add("placa-timer", "#34675C");
        dicionario.Add("display-timer-digito", "#7DA3A1");
        dicionario.Add("seg", "#324851");
        dicionario.Add("placa-coletados", "#34675C");
        dicionario.Add("display-coletado1", "#7DA3A1");
        dicionario.Add("display-coletado2", "#7DA3A1");
        dicionario.Add("display-coletado3", "#7DA3A1");
        dicionario.Add("placa-scores", "#34675C");
        dicionario.Add("display-pontos1", "#7DA3A1");
        dicionario.Add("display-pontos2", "#7DA3A1");
        dicionario.Add("display-pontos3", "#7DA3A1");
        dicionario.Add("leds", "#324851");
        dicionario.Add("topo", "#86AC41");
        dicionario.Add("base", "#7DA3A1");
        dicionario.Add("mesa-joystick-cima", "#34675C");
        dicionario.Add("mesa-joystick-baixo", "#34675C");
        dicionario.Add("buraco-joystick", "#324851");
        dicionario.Add("haste-joystick", "#7DA3A1");
        dicionario.Add("bola-joystick", "#86AC41");
        dicionario.Add("buraco-botao", "#324851");
        dicionario.Add("botao", "#86AC41");
        dicionario.Add("buraco-ficha", "#86AC41");
        dicionario.Add("buraco-card", "#86AC41");
        dicionario.Add("triangulo-card", "#86AC41");
        dicionario.Add("btn-pup-base-d", "#86AC41");
        dicionario.Add("btn-pup-topo-d", "#7DA3A1");
        dicionario.Add("btn-pup-base-e", "#86AC41");
        dicionario.Add("btn-pup-topo-e", "#7DA3A1");
        dicionario.Add("placa-externa", "#34675C");
        dicionario.Add("placa-interna", "#7DA3A1");
        dicionario.Add("setas-laterais", "#324851");
        dicionario.Add("seta-cima", "#324851");
        dicionario.Add("divisoria", "#324851");
        dicionario.Add("digitos", "#324851");
        dicionario.Add("circulo-externo", "#324851");
        dicionario.Add("circulo-interno", "#7DA3A1");        return dicionario;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLeite();
    }
    
    public class FornecedorLeite : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelLeite();
        }
    }

}
