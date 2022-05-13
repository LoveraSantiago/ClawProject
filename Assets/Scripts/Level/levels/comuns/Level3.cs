using System.Collections.Generic;

public class Level3 : AbstractLevelElevador
{
    public override string getLevelName()
    {
        return "Nível 3";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Cuidado com o numero de coletaveis";
    }   

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            { 10, 10, 10, 11, 11, 11, 12 },
            { 14, 14, 14, 13, 13, 13, 0 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 } };
    }

    public override int[,] getArrayDeColetaveisSub()
    {
        return new int[,] {
            { 10, 10, 10, 11, 11, 11, 0 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override bool devolverParaBoard()
    {
        return true;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.CONTINUA, "00:26");        
    }

    public override Dictionary<string, string> getDicionarioDeCores()
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
        dicionario.Add("seg", "#F98866");
        dicionario.Add("placa-coletados", "#80BD9E");
        dicionario.Add("display-coletado1", "#BBEA9F");
        dicionario.Add("display-coletado2", "#BBEA9F");
        dicionario.Add("display-coletado3", "#BBEA9F");
        dicionario.Add("placa-scores", "#80BD9E");
        dicionario.Add("display-pontos1", "#BBEA9F");
        dicionario.Add("display-pontos2", "#BBEA9F");
        dicionario.Add("display-pontos3", "#BBEA9F");
        dicionario.Add("leds", "#F98866");
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
        dicionario.Add("btn-pup-topo-d", "#89DA59");
        dicionario.Add("btn-pup-base-e", "#80BD9E");
        dicionario.Add("btn-pup-topo-e", "#89DA59");
        dicionario.Add("placa-externa", "#FF420E");
        dicionario.Add("placa-interna", "#BBEA9F");
        dicionario.Add("setas-laterais", "#F98866");
        dicionario.Add("seta-cima", "#F98866");
        dicionario.Add("divisoria", "#80BD9E");
        dicionario.Add("digitos", "#F98866");
        dicionario.Add("circulo-externo", "#80BD9E");
        dicionario.Add("circulo-interno", "#BBEA9F");        return dicionario;
    }

    public override bool isLevelAlbedo0Timers()
    {
        return true;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel3();
    }

    public class FornecedorLevel3 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level3();
        }
    }
}




