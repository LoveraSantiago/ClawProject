public class BotoesCenasMapa 
{
    public BotoesCenasMapa(BotoesCenasDto botoesCenasDto)
    {
        configurarBotoesCenas(botoesCenasDto);
    }

    private void configurarBotoesCenas(BotoesCenasDto botoesCenasDto)
    {
        botoesCenasDto.BtnCards.onClick.AddListener(() => CenaUtils.irParaCenaPup());
        botoesCenasDto.BtnStore.onClick.AddListener(() => CenaUtils.irParaCenaLoja());
        botoesCenasDto.BtnScore.onClick.AddListener(() => CenaUtils.irParaCenaLevels());
        botoesCenasDto.BtnPelucia.onClick.AddListener(() => CenaUtils.irParaCenaColetaveis());
        botoesCenasDto.BtnConfig.onClick.AddListener(() => CenaUtils.irParaCenaConfig());
    }
}
