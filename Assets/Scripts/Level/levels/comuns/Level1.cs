
using System.Collections.Generic;

public class Level1 : AbstractLevel
{
    public override string getLevelName()
    {
        return "Nível 1";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete todos os itens";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.NORMAL;
    }

    public override string getNameMap()
    {
        return Mapas.PARQUE_DIVERSOES;
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
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        //return new PowerUpsParaLevel(1)
        //   .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MOLA });

        return new PowerUpsParaLevel(2)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE })
           .addPupsParaBtn(1, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.BOMBA_DA_GARRA, PowerUpEnums.TIPO.MISSIL_NUCLEAR, PowerUpEnums.TIPO.MINA_TERRESTRE, PowerUpEnums.TIPO.MISSIL_TELEGUIADO, PowerUpEnums.TIPO.IGUAL, PowerUpEnums.TIPO.TELEPORTE, PowerUpEnums.TIPO.CORINGA, PowerUpEnums.TIPO.MINI_ASAS, PowerUpEnums.TIPO.ASAS, PowerUpEnums.TIPO.BURACO_NEGRO, PowerUpEnums.TIPO.MOLA, PowerUpEnums.TIPO.ROLLBACK, PowerUpEnums.TIPO.DESCARTE });

    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#EB82EB");
        dicionario.Add("base-chao", "#FF8096");
        dicionario.Add("chao-dentro", "#00BDCF");
        dicionario.Add("cabo-da-garra", "#FB6542");
        dicionario.Add("viga", "#C268C2");
        dicionario.Add("barra", "#606986");
        dicionario.Add("placa-timer", "#FF8096");
        dicionario.Add("display-timer-digito", "#85E1F0");
        dicionario.Add("seg", "#6CAED9");
        dicionario.Add("placa-coletados", "#FF8096");
        dicionario.Add("display-coletado1", "#85E1F0");
        dicionario.Add("display-coletado2", "#85E1F0");
        dicionario.Add("display-coletado3", "#85E1F0");
        dicionario.Add("placa-scores", "#FF8096");
        dicionario.Add("display-pontos1", "#85E1F0");
        dicionario.Add("display-pontos2", "#85E1F0");
        dicionario.Add("display-pontos3", "#85E1F0");
        dicionario.Add("leds", "#6CAED9");
        dicionario.Add("topo", "#FF8096");
        dicionario.Add("base", "#99E5EC");
        dicionario.Add("mesa-joystick-cima", "#EAE67B");
        dicionario.Add("mesa-joystick-baixo", "#C1BD64");
        dicionario.Add("buraco-joystick", "#FF8096");
        dicionario.Add("haste-joystick", "#B7B7B7");
        dicionario.Add("bola-joystick", "#85E1F0");
        dicionario.Add("buraco-botao", "#85E1F0");
        dicionario.Add("botao", "#EB82EB");
        dicionario.Add("buraco-ficha", "#85E1F0");
        dicionario.Add("buraco-card", "#85E1F0");
        dicionario.Add("triangulo-card", "#85E1F0");
        dicionario.Add("btn-pup-base-d", "#FF8096");
        dicionario.Add("btn-pup-topo-d", "#85E1F0");
        dicionario.Add("btn-pup-base-e", "#FF8096");
        dicionario.Add("btn-pup-topo-e", "#85E1F0");
        dicionario.Add("placa-externa", "#FF8096");
        dicionario.Add("placa-interna", "#85E1F0");
        dicionario.Add("setas-laterais", "#00BEDD");
        dicionario.Add("seta-cima", "#00BEDD");
        dicionario.Add("divisoria", "#00BEDD");
        dicionario.Add("digitos", "#00BEDD");
        dicionario.Add("circulo-externo", "#FF8096");
        dicionario.Add("circulo-interno", "#6CAED9");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel1();
    }

    public class FornecedorLevel1 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level1();
        }
    }
}
