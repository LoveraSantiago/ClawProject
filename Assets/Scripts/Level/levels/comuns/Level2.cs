
using System.Collections.Generic;

public class Level2 : AbstractLevel
{
    public override string getLevelName()
    {
        return "Nível 2";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Faça o maior número de combinações";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.NORMAL;
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

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.REGRESSIVA, "02:01");
    }   

    public override Dictionary<string, string> getDicionarioDeCores()
    {   
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#000000");
        dicionario.Add("base-chao", "#5D5B5B");
        dicionario.Add("chao-dentro", "#606986");
        dicionario.Add("cabo-da-garra", "#FFFFFF");
        dicionario.Add("viga", "#000000");
        dicionario.Add("barra", "#606986");
        dicionario.Add("placa-timer", "#BEBEBE");
        dicionario.Add("display-timer-digito", "#3A3A3A");
        dicionario.Add("seg", "#5D5B5B");
        dicionario.Add("placa-coletados", "#BEBEBE");
        dicionario.Add("display-coletado1", "#3A3A3A");
        dicionario.Add("display-coletado2", "#3A3A3A");
        dicionario.Add("display-coletado3", "#3A3A3A");
        dicionario.Add("placa-scores", "#BEBEBE");
        dicionario.Add("display-pontos1", "#3A3A3A");
        dicionario.Add("display-pontos2", "#3A3A3A");
        dicionario.Add("display-pontos3", "#3A3A3A");
        dicionario.Add("leds", "#5D5B5B");
        dicionario.Add("topo", "#606986");
        dicionario.Add("base", "#FFFFFF");
        dicionario.Add("mesa-joystick-cima", "#575757");
        dicionario.Add("mesa-joystick-baixo", "#575757");
        dicionario.Add("buraco-joystick", "#606986");
        dicionario.Add("haste-joystick", "#BEBEBE");
        dicionario.Add("bola-joystick", "#FFFFFF");
        dicionario.Add("buraco-botao", "#606986");
        dicionario.Add("botao", "#FFFFFF");
        dicionario.Add("buraco-ficha", "#BEBEBE");
        dicionario.Add("buraco-card", "#BEBEBE");
        dicionario.Add("triangulo-card", "#FFFFFF");
        dicionario.Add("btn-pup-base-d", "#BEBEBE");
        dicionario.Add("btn-pup-topo-d", "#5D5B5B");
        dicionario.Add("btn-pup-base-e", "#BEBEBE");
        dicionario.Add("btn-pup-topo-e", "#5D5B5B");
        dicionario.Add("placa-externa", "#BEBEBE");
        dicionario.Add("placa-interna", "#3A3A3A");
        dicionario.Add("setas-laterais", "#606986");
        dicionario.Add("seta-cima", "#606986");
        dicionario.Add("divisoria", "#FFFFFF");
        dicionario.Add("digitos", "#digitos");
        dicionario.Add("circulo-externo", "#FFFFFF");
        dicionario.Add("circulo-interno", "#606986");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public override bool isLevelAlbedo0Timer2Pontos()
    {
        return false;
    }

    public override bool isLevelAlbedo0DigitosScrollPup()
    {
        return false;
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        //return new PowerUpsParaLevel(2)
        //   .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MOLA})
        //   .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.MINA_TERRESTRE });

        return new PowerUpsParaLevel(2)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE });

        //return new PowerUpsParaLevel(2)
        //    .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.BOMBA_DA_GARRA })
        //    .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.ASAS});
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel2();
    }

    public class FornecedorLevel2: Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level2();
        }
    }
}

