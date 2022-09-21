public class BotoesCenasMapa 
{
    public BotoesCenasMapa(BotoesCenasDto botoesCenasDto)
    {
        configurarBotoesCenas(botoesCenasDto);
    }

    private void configurarBotoesCenas(BotoesCenasDto botoesCenasDto)
    {
        configurarExclamacoes(botoesCenasDto);
        botoesCenasDto.BtnCards.onClick.AddListener(() => CenaUtils.irParaCenaPup());
        botoesCenasDto.BtnStore.onClick.AddListener(() => CenaUtils.irParaCenaLoja());
        botoesCenasDto.BtnScore.onClick.AddListener(() => {
            CenaUtils.irParaCenaLevels();
            PlayerPrefsMapas.consumidoNovaLiberacaoLevel();
        });
        botoesCenasDto.BtnPelucia.onClick.AddListener(() => {
            CenaUtils.irParaCenaColetaveis();
            PlayerPrefsMapas.consumidoNovaLiberacaoColetavel();
        });
        botoesCenasDto.BtnConfig.onClick.AddListener(() => CenaUtils.irParaCenaConfig());
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
