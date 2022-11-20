public class BotoesCenasMapa 
{
    public BotoesCenasMapa(BotoesCenasDto botoesCenasDto, Loading loading, SomMap somMap)
    {
        configurarBotoesCenas(botoesCenasDto, loading, somMap);
    }

    private void configurarBotoesCenas(BotoesCenasDto botoesCenasDto, Loading loading, SomMap somMap)
    {
        configurarExclamacoes(botoesCenasDto);
        botoesCenasDto.BtnCards.onClick.AddListener  (() => irParaCenaPowerUp(loading, somMap));
        botoesCenasDto.BtnStore.onClick.AddListener  (() => irParaCenaLoja(loading, somMap));
        botoesCenasDto.BtnScore.onClick.AddListener  (() => irParaCenaLevel(loading, somMap));
        botoesCenasDto.BtnPelucia.onClick.AddListener(() => irParaCenaColetaveis(loading, somMap));
        botoesCenasDto.BtnConfig.onClick.AddListener (() => irParaCenaConfiguracao(loading, somMap));
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

    private void irParaCenaPowerUp(Loading loading, SomMap somMap)
    {
        somMap.playSomClique();
        loading.irParaPowerUpCena();
    }

    private void irParaCenaLoja(Loading loading, SomMap somMap)
    {
        somMap.playSomClique();
        loading.irParaLojaCena();
    }

    private void irParaCenaLevel(Loading loading, SomMap somMap)
    {
        somMap.playSomClique();
        loading.irParaLevelCena();
        PlayerPrefsMapas.consumidoNovaLiberacaoLevel();
    }

    private void irParaCenaColetaveis(Loading loading, SomMap somMap)
    {
        somMap.playSomClique();
        loading.irParaColetaveisCena();
        PlayerPrefsMapas.consumidoNovaLiberacaoColetavel();
    }

    private void irParaCenaConfiguracao(Loading loading, SomMap somMap)
    {
        somMap.playSomClique();
        loading.irParaConfiguracaoCena();
    }    
}
