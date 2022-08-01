using System.Collections.Generic;

public class Level8 : AbstractLevel
{
    //COPIADO DO LEVEL 1 SO PRA TER CLASSE P COLOCAR COR NA MAQUINA
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
        //05. Cool Blues
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#66A5AD");
        dicionario.Add("base-chao", "#4C858D");
        dicionario.Add("chao-dentro", "#C4DFE6");
        dicionario.Add("cabo-da-garra", "#4C858D");
        dicionario.Add("viga", "#4C858D");
        dicionario.Add("barra", "#C4DFE6");
        dicionario.Add("placa-timer", "#07575B");
        dicionario.Add("display-timer-digito", "#C4DFE6");
        dicionario.Add("seg", "#4C858D");
        dicionario.Add("placa-coletados", "#07575B");
        dicionario.Add("display-coletado1", "#C4DFE6");
        dicionario.Add("display-coletado2", "#C4DFE6");
        dicionario.Add("display-coletado3", "#C4DFE6");
        dicionario.Add("placa-scores", "#07575B");
        dicionario.Add("display-pontos1", "#C4DFE6");
        dicionario.Add("display-pontos2", "#C4DFE6");
        dicionario.Add("display-pontos3", "#C4DFE6");
        dicionario.Add("leds", "#4C858D");
        dicionario.Add("topo", "#66A5AD");
        dicionario.Add("base", "#C4DFE6");
        dicionario.Add("mesa-joystick-cima", "#003B46");
        dicionario.Add("mesa-joystick-baixo", "#003B46");
        dicionario.Add("buraco-joystick", "#66A5AD");
        dicionario.Add("haste-joystick", "#C4DFE6");
        dicionario.Add("bola-joystick", "#66A5AD");
        dicionario.Add("buraco-botao", "#66A5AD");
        dicionario.Add("botao", "#C4DFE6");
        dicionario.Add("buraco-ficha", "#C4DFE6");
        dicionario.Add("buraco-card", "#C4DFE6");
        dicionario.Add("triangulo-card", "#C4DFE6");
        dicionario.Add("btn-pup-base-d", "#66A5AD");
        dicionario.Add("btn-pup-topo-d", "#C4DFE6");
        dicionario.Add("btn-pup-base-e", "#66A5AD");
        dicionario.Add("btn-pup-topo-e", "#C4DFE6");
        dicionario.Add("placa-externa", "#003B46");
        dicionario.Add("placa-interna", "#C4DFE6");
        dicionario.Add("setas-laterais", "#C4DFE6");
        dicionario.Add("seta-cima", "#66A5AD");
        dicionario.Add("divisoria", "#66A5AD");
        dicionario.Add("digitos", "#4C858D");
        dicionario.Add("circulo-externo", "#07575B");
        dicionario.Add("circulo-interno", "#C4DFE6");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel8();
    }

    public class FornecedorLevel8 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level8();
        }
    }
}
