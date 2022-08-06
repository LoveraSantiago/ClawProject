using System.Collections.Generic;

public class Level7 : AbstractLevel
{
    //COPIADO DO LEVEL 1 SO PRA TER CLASSE P COLOCAR COR NA MAQUINA
    public override string getLevelTitle()
    {
        return "Nível 7";
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
        //06. Outdoorsy & Natural
        Dictionary<string, string> dicionario = new Dictionary<string, string>();
        dicionario.Add("placa-frente", "#2E4600");
        dicionario.Add("base-chao", "#243800");
        dicionario.Add("chao-dentro", "#A2C523");
        dicionario.Add("cabo-da-garra", "#C46E43");
        dicionario.Add("viga", "#243800");
        dicionario.Add("barra", "#A2C523");
        dicionario.Add("placa-timer", "#A2C523");
        dicionario.Add("display-timer-digito", "#CFE777");
        dicionario.Add("seg", "#A2C523");
        dicionario.Add("placa-coletados", "#A2C523");
        dicionario.Add("display-coletado1", "#CFE777");
        dicionario.Add("display-coletado2", "#CFE777");
        dicionario.Add("display-coletado3", "#CFE777");
        dicionario.Add("placa-scores", "#A2C523");
        dicionario.Add("display-pontos1", "#CFE777");
        dicionario.Add("display-pontos2", "#CFE777");
        dicionario.Add("display-pontos3", "#CFE777");
        dicionario.Add("leds", "#A2C523");
        dicionario.Add("topo", "#486B00");
        dicionario.Add("base", "#A8B937");
        dicionario.Add("mesa-joystick-cima", "#7D4427");
        dicionario.Add("mesa-joystick-baixo", "#7D4427");
        dicionario.Add("buraco-joystick", "#59301C");
        dicionario.Add("haste-joystick", "#C3C3C3");
        dicionario.Add("bola-joystick", "#C46E43");
        dicionario.Add("buraco-botao", "#59301C");
        dicionario.Add("botao", "#C46E43");
        dicionario.Add("buraco-ficha", "#C46E43");
        dicionario.Add("buraco-card", "#C46E43");
        dicionario.Add("triangulo-card", "#C46E43");
        dicionario.Add("btn-pup-base-d", "#6A3A22");
        dicionario.Add("btn-pup-topo-d", "#C46E43");
        dicionario.Add("btn-pup-base-e", "#6A3A22");
        dicionario.Add("btn-pup-topo-e", "#C46E43");
        dicionario.Add("placa-externa", "#6A3A22");
        dicionario.Add("placa-interna", "#C46E43");
        dicionario.Add("setas-laterais", "#CFE777");
        dicionario.Add("seta-cima", "#CFE777");
        dicionario.Add("divisoria", "#2E4600");
        dicionario.Add("digitos", "#A2C523");
        dicionario.Add("circulo-externo", "#A2C523");
        dicionario.Add("circulo-interno", "#CFE777");
        return dicionario;
    }

    public override bool isLevelAlbedo0()
    {
        return false;
    }

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevel7();
    }

    public class FornecedorLevel7 : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new Level7();
        }
    }
}
