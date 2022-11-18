public class BotoesCenasMapa 
{
    public BotoesCenasMapa(BotoesCenasDto botoesCenasDto, Loading loading)
    {
        configurarBotoesCenas(botoesCenasDto, loading);
    }

    private void configurarBotoesCenas(BotoesCenasDto botoesCenasDto, Loading loading)
    {
        configurarExclamacoes(botoesCenasDto);
        botoesCenasDto.BtnCards.onClick.AddListener(() => loading.irParaPowerUpCena());
        botoesCenasDto.BtnStore.onClick.AddListener(() => loading.irParaLojaCena());
        botoesCenasDto.BtnScore.onClick.AddListener(() => {
            loading.irParaLevelCena();
            PlayerPrefsMapas.consumidoNovaLiberacaoLevel();
        });
        botoesCenasDto.BtnPelucia.onClick.AddListener(() => {
            loading.irParaColetaveisCena();
            PlayerPrefsMapas.consumidoNovaLiberacaoColetavel();
        });
        botoesCenasDto.BtnConfig.onClick.AddListener(() => loading.irParaConfiguracaoCena());
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
}
