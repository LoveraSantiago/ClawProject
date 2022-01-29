public class TimerFicha 
{
    private TimerFichaDto timerFichaDto;
    private Relogio relogio;

    public TimerFicha(TimerFichaDto timerFichaDto, Ficha ficha)
    {
        this.timerFichaDto = timerFichaDto;
        relogio = new Relogio();

        configurarImgFicha();
        configurarBotao();
        setupDeFichas(ficha);
    }

    public void update()
    {
        relogio.updateSegundo(timerFichaDto.RelogioDto);
    }

    private void setupDeFichas(Ficha ficha)
    {
        int fichas = PlayerPrefsFichas.getQtdFichas(ficha);
        setLabelQtdDeFichas(fichas);

        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        if(fichas >= fichaEntidade.limiteFree)
        {
            relogio.zerarPonteiros(timerFichaDto.RelogioDto);
        }
        else
        {

        }
    }

    private void setLabelQtdDeFichas(int fichas)
    {
        timerFichaDto.LblQdtFichas.text = fichas.ToString();
    }   

    private void configurarImgFicha()
    {
        timerFichaDto.ImgMoeda.sprite = timerFichaDto.SprMoeda;
    }

    private void configurarBotao()
    {
        timerFichaDto.BtnMais.onClick.AddListener(() => CenaUtils.irParaCenaLoja());
    }
}
