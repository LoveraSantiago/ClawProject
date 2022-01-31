using System;

public class TimerFicha 
{
    private TimerFichaDto timerFichaDto;
    private Relogio relogio;

    public TimerFicha(TimerFichaDto timerFichaDto, Ficha ficha)
    {
        this.timerFichaDto = timerFichaDto;
        relogio = new RelogioConcluido();

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
        int qtdFichas = PlayerPrefsFichas.getQtdFichas(ficha);
        setLabelQtdDeFichas(qtdFichas);

        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        if(qtdFichas >= fichaEntidade.limiteFree)
        {
            relogio.zerarPonteiros(timerFichaDto.RelogioDto);
        }
        else
        {
            DateTime dataSalva = PlayerPrefsFichas.getDataFicha(ficha);
            atualizarTempoDesdeUltimaFicha(qtdFichas, dataSalva, fichaEntidade);

            qtdFichas = PlayerPrefsFichas.getQtdFichas(ficha);
            setLabelQtdDeFichas(qtdFichas);

            if(qtdFichas < fichaEntidade.limiteFree)
            {
                relogio = new RelogioContador(dataSalva, fichaEntidade);
            }
            else
            {
                relogio.zerarPonteiros(timerFichaDto.RelogioDto);
            }
        }
    }

    private void atualizarTempoDesdeUltimaFicha(int fichasAtuais, DateTime dataSalva, FichaEntidade fichaEntidade)
    {
        int resultado = 0;
        DateTime dataProjetada = dataSalva;

        while (fichasAtuais < fichaEntidade.limiteFree)
        {
            dataProjetada = dataProjetada.AddHours(fichaEntidade.intervaloHoras)
                                         .AddMinutes(fichaEntidade.intervaloMinutos);

            if(dataProjetada < DateTime.Now)
            {
                resultado++;
                PlayerPrefsFichas.adicionarFicha(fichaEntidade.ficha, 1);
            }
            fichasAtuais++;
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
