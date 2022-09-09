public class BotoesCenasMapa 
{
    public BotoesCenasMapa(BotoesCenasDto botoesCenasDto)
    {
        configurarBotoesCenas(botoesCenasDto);
    }

    private void configurarBotoesCenas(BotoesCenasDto botoesCenasDto)
    {
        if (PlayerPrefsMapas.isNovaLiberacaoLevel())
        {
            botoesCenasDto.ExclamacaoLevel.SetActive(true);
        }
        else
        {
            botoesCenasDto.ExclamacaoLevel.SetActive(false);
        }

        botoesCenasDto.BtnCards.onClick.AddListener(() => CenaUtils.irParaCenaPup());
        botoesCenasDto.BtnStore.onClick.AddListener(() => CenaUtils.irParaCenaLoja());
        botoesCenasDto.BtnScore.onClick.AddListener(() => {
            CenaUtils.irParaCenaLevels();
            PlayerPrefsMapas.consumidoNovaLiberacaoLevel();
        });
        botoesCenasDto.BtnPelucia.onClick.AddListener(() => CenaUtils.irParaCenaColetaveis());
        botoesCenasDto.BtnConfig.onClick.AddListener(() => CenaUtils.irParaCenaConfig());
    }
}
