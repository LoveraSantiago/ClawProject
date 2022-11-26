public class BotoesCenasMapa 
{
    public BotoesCenasMapa(BotoesCenasDto botoesCenasDto, SomMap somMap)
    {
        configurarBotoesCenas(botoesCenasDto, somMap);
    }

    private void configurarBotoesCenas(BotoesCenasDto botoesCenasDto, SomMap somMap)
    {
        configurarExclamacoes(botoesCenasDto);
        botoesCenasDto.BtnCards.onClick.AddListener  (() => irParaCenaPowerUp(somMap));
        botoesCenasDto.BtnStore.onClick.AddListener  (() => irParaCenaLoja(somMap));
        botoesCenasDto.BtnScore.onClick.AddListener  (() => irParaCenaLevel(somMap));
        botoesCenasDto.BtnPelucia.onClick.AddListener(() => irParaCenaColetaveis(somMap));
        botoesCenasDto.BtnConfig.onClick.AddListener (() => irParaCenaConfiguracao(somMap));
    }

    private void configurarExclamacoes(BotoesCenasDto botoesCenasDto)
    {
        configurarExclamacaoBotaoLevels(botoesCenasDto);
        configurarExclamacoesBotaoColetaveis(botoesCenasDto);
    }

    private void configurarExclamacaoBotaoLevels(BotoesCenasDto botoesCenasDto)
    {
        if (PlayerPrefsMapas.isNovaLiberacaoLevel())
        {
            botoesCenasDto.ExclamacaoLevel.SetActive(true);
        }
        else
        {
            botoesCenasDto.ExclamacaoLevel.SetActive(false);
        }
    }

    private void configurarExclamacoesBotaoColetaveis(BotoesCenasDto botoesCenasDto)
    {
        if (PlayerPrefsMapas.isNovaLiberacaoColetavel())
        {
            botoesCenasDto.ExclamacaoColetavel.SetActive(true);
        }
        else
        {
            botoesCenasDto.ExclamacaoColetavel.SetActive(false);
        }
    }

    private void irParaCenaPowerUp(SomMap somMap)
    {
        somMap.playSomClique();
        ContextoEstaticoUtils.loading.irParaPowerUpCena();
    }

    private void irParaCenaLoja(SomMap somMap)
    {
        somMap.playSomClique();
        ContextoEstaticoUtils.loading.irParaLojaCena();
    }

    private void irParaCenaLevel(SomMap somMap)
    {
        somMap.playSomClique();
        ContextoEstaticoUtils.loading.irParaLevelCena();
        PlayerPrefsMapas.consumidoNovaLiberacaoLevel();
    }

    private void irParaCenaColetaveis(SomMap somMap)
    {
        somMap.playSomClique();
        ContextoEstaticoUtils.loading.irParaColetaveisCena();
        PlayerPrefsMapas.consumidoNovaLiberacaoColetavel();
    }

    private void irParaCenaConfiguracao(SomMap somMap)
    {
        somMap.playSomClique();
        ContextoEstaticoUtils.loading.irParaConfiguracaoCena();
    }    
}
