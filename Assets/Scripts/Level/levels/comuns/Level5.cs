using System.Collections.Generic;

public class Level5 : AbstractLevelObstaculos
{
    public override string getLevelName()
    {
        return "Nível 5";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete com obstaculos";
    }

    public override int[,] getArrayDeColetaveis()
    {
        int[,] coletaveis = new int[,]{
            {12, 12, 12, 11, 15, 15, 15},
            {15, 15, 15, 11, 12, 12, 12},
            {12, 12, 12, 11, 15, 15, 15},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
        return coletaveis;
    }

    public override bool[,] getArrayDeObstaculos()
    {
        bool[,] gaiolas = new bool[,]{
            {false, true, false, true, false, true, false},
            {true, false, true, false, true, false, true},
            {false, false, false, false, false, false, false},
            {true, true, true, true, true, true, true},
            {false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false}
        };
        return gaiolas;
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        //03. Dark & Earthy
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#693D3D");
        dicionario.Add("base-chao", "#46211A");
        dicionario.Add("chao-dentro", "#46211A");
        dicionario.Add("cabo-da-garra", "#A77639");
        dicionario.Add("viga", "#5C3535");
        dicionario.Add("barra", "#BA5536");
        dicionario.Add("placa-timer", "#A43820");
        dicionario.Add("display-timer-digito", "#BA5536");
        dicionario.Add("seg", "#46211A");
        dicionario.Add("placa-coletados", "#A43820");
        dicionario.Add("display-coletado1", "#BA5536");
        dicionario.Add("display-coletado2", "#BA5536");
        dicionario.Add("display-coletado3", "#BA5536");
        dicionario.Add("placa-scores", "#A43820");
        dicionario.Add("display-pontos1", "#BA5536");
        dicionario.Add("display-pontos2", "#BA5536");
        dicionario.Add("display-pontos3", "#BA5536");
        dicionario.Add("leds", "#46211A");
        dicionario.Add("topo", "#BA5536");
        dicionario.Add("base", "#D88F78");
        dicionario.Add("mesa-joystick-cima", "#BA5536");
        dicionario.Add("mesa-joystick-baixo", "#BA5536");
        dicionario.Add("buraco-joystick", "#46211A");
        dicionario.Add("haste-joystick", "#BA5536");
        dicionario.Add("bola-joystick", "#D88F78");
        dicionario.Add("buraco-botao", "#46211A");
        dicionario.Add("botao", "#D88F78");
        dicionario.Add("buraco-ficha", "#A43820");
        dicionario.Add("buraco-card", "#A43820");
        dicionario.Add("triangulo-card", "#A43820");
        dicionario.Add("btn-pup-base-d", "#A43820");
        dicionario.Add("btn-pup-topo-d", "#D88F78");
        dicionario.Add("btn-pup-base-e", "#A43820");
        dicionario.Add("btn-pup-topo-e", "#D88F78");
        dicionario.Add("placa-externa", "#A43820");
        dicionario.Add("placa-interna", "#D88F78");
        dicionario.Add("setas-laterais", "#46211A");
        dicionario.Add("seta-cima", "#46211A");
        dicionario.Add("divisoria", "#A43820");
        dicionario.Add("digitos", "#46211A");
        dicionario.Add("circulo-externo", "#A77639");
        dicionario.Add("circulo-interno", "#BA5536");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel5();
    }

    public class FornecedorLevel5 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level5();
        }
    }
}
