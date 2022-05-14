using System.Collections.Generic;

public class Level6 : AbstractLevelOvo
{
    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {14, 12, 11, 12, 11, 12, 11},
            {12, 11, 14, 11, 11, 13, 0},
            {0, 0, 14, 14, 14, 0, 0},
            {0, 0, 0, 14, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        //04. Crisp & Dramatic
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#68829E");
        dicionario.Add("base-chao", "#505160");
        dicionario.Add("chao-dentro", "#AEBD38");
        dicionario.Add("cabo-da-garra", "#598234");
        dicionario.Add("viga", "#50657D");
        dicionario.Add("barra", "#AEBD38");
        dicionario.Add("placa-timer", "#598234");
        dicionario.Add("display-timer-digito", "#505160");
        dicionario.Add("seg", "#68829E");
        dicionario.Add("placa-coletados", "#598234");
        dicionario.Add("display-coletado1", "#92A5B9");
        dicionario.Add("display-coletado2", "#92A5B9");
        dicionario.Add("display-coletado3", "#92A5B9");
        dicionario.Add("placa-scores", "#598234");
        dicionario.Add("display-pontos1", "#505160");
        dicionario.Add("display-pontos2", "#505160");
        dicionario.Add("display-pontos3", "#505160");
        dicionario.Add("leds", "#68829E");
        dicionario.Add("topo", "#68829E");
        dicionario.Add("base", "#92A5B9");
        dicionario.Add("mesa-joystick-cima", "#598234");
        dicionario.Add("mesa-joystick-baixo", "#5A7840");
        dicionario.Add("buraco-joystick", "#505160");
        dicionario.Add("haste-joystick", "#92A5B9");
        dicionario.Add("bola-joystick", "#505160");
        dicionario.Add("buraco-botao", "#505160");
        dicionario.Add("botao", "#92A5B9");
        dicionario.Add("buraco-ficha", "#92A5B9");
        dicionario.Add("buraco-card", "#92A5B9");
        dicionario.Add("triangulo-card", "#92A5B9");
        dicionario.Add("btn-pup-base-d", "#505160");
        dicionario.Add("btn-pup-topo-d", "#92A5B9");
        dicionario.Add("btn-pup-base-e", "#505160");
        dicionario.Add("btn-pup-topo-e", "#92A5B9");
        dicionario.Add("placa-externa", "#598234");
        dicionario.Add("placa-interna", "#AEBD38");
        dicionario.Add("setas-laterais", "#505160");
        dicionario.Add("seta-cima", "#505160");
        dicionario.Add("divisoria", "#598234");
        dicionario.Add("digitos", "#505160");
        dicionario.Add("circulo-externo", "#AEBD38");
        dicionario.Add("circulo-interno", "#DEE5A7");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel6();
    }

    public class FornecedorLevel6 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level6();
        }
    }
}
