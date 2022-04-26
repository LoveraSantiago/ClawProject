
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
        dicionario.Add("cabo-da-garra", "#99E5EC");
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
        dicionario.Add("topo", "#00BDCF");
        dicionario.Add("base", "#99E5EC");
        dicionario.Add("mesa-joystick-cima", "#BEBEBE");
        dicionario.Add("mesa-joystick-baixo", "#B8B8B8");
        dicionario.Add("buraco-joystick", "#606986");
        dicionario.Add("haste-joystick", "#7C7C7C");
        dicionario.Add("bola-joystick", "#00BDCF");
        dicionario.Add("buraco-botao", "#606986");
        dicionario.Add("botao", "#00BDCF");
        dicionario.Add("buraco-ficha", "#99E5EC");
        dicionario.Add("buraco-card", "#99E5EC");
        dicionario.Add("triangulo-card", "#99E5EC");
        dicionario.Add("btn-pup-base-d", "#606986");
        dicionario.Add("btn-pup-topo-d", "#99E5EC");
        dicionario.Add("btn-pup-base-e", "#606986");
        dicionario.Add("btn-pup-topo-e", "#99E5EC");
        dicionario.Add("placa-externa", "#BEBEBE");
        dicionario.Add("placa-interna", "#3A3A3A");
        dicionario.Add("setas-laterais", "#00BDCF");
        dicionario.Add("seta-cima", "#00BDCF");
        dicionario.Add("circulo-externo", "#BEBEBE");
        dicionario.Add("circulo-interno", "#99E5EC");
        return dicionario;

        //Dictionary<string, string> dicionario = new Dictionary<string, string>();
        //dicionario.Add("placa-cima", "#80BD9E");
        //dicionario.Add("base-parte", "#89DA59");
        //dicionario.Add("base-chao", "#80BD9E");
        //dicionario.Add("borda-vidro", "#CB9888");
        //dicionario.Add("placa-frontal", "#C3EDAB");
        //dicionario.Add("placa-saida", "#CB9888");
        //dicionario.Add("barra", "#FF420E");
        //dicionario.Add("chao-dentro", "#FF420E");
        //dicionario.Add("tubo", "#F98866");
        //dicionario.Add("viga-tras", "#52A123");
        //dicionario.Add("btnPowerUp1", "#FAAB93");
        //dicionario.Add("parte-dentro1", "#CB9888");
        //dicionario.Add("contorno1", "#F37476");
        //dicionario.Add("btnPowerUp2", "#FAAB93");
        //dicionario.Add("parte-dentro2", "#CB9888");
        //dicionario.Add("contorno2", "#F37476");
        //dicionario.Add("btnPowerUp3", "#FAAB93");
        //dicionario.Add("parte-dentro3", "#CB9888");
        //dicionario.Add("contorno3", "#F37476");
        //dicionario.Add("btnPowerUp4", "#FAAB93");
        //dicionario.Add("parte-dentro4", "#CB9888");
        //dicionario.Add("contorno4", "#F37476");
        //dicionario.Add("parte-cima", "#CB9888");
        //dicionario.Add("parte-baixo", "#F37476");
        //dicionario.Add("furo-haste", "#FF420E");
        //dicionario.Add("haste", "#F98866");
        //dicionario.Add("joystick-bola", "#FF420E");
        //dicionario.Add("furo-botao", "#FF420E");
        //dicionario.Add("botao", "#F98866");
        //dicionario.Add("placa-ficha", "#F98866");
        //dicionario.Add("placa-parte-cima", "#CB9888");
        //dicionario.Add("placa-parte-baixo", "#CB9888");
        //dicionario.Add("quadrado-maior", "#CB9888");
        //dicionario.Add("quadrado-menor", "#F98866");
        //dicionario.Add("furo-cima", "#F98866");
        //dicionario.Add("furo-baixo", "#F98866");
        //dicionario.Add("display-coletados", "#164D28");
        //dicionario.Add("placa-coletado1", "#268747");
        //dicionario.Add("placa-coletado2", "#268747");
        //dicionario.Add("placa-coletado3", "#268747");
        //dicionario.Add("display-timer", "#164D28");
        //dicionario.Add("digitos-timer", "#268747");
        //dicionario.Add("display-pontos1", "#164D28");
        //dicionario.Add("display-pontos2", "#164D28");
        //dicionario.Add("display-pontos3", "#164D28");
        //dicionario.Add("leds1", "#268747");
        //dicionario.Add("leds2", "#268747");
        //dicionario.Add("leds3", "#268747");
        //dicionario.Add("cabo-da-garra", "#CB9888");

        //return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return true;
    }

    public override bool isLevelAlbedo0Timer2Pontos()
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

