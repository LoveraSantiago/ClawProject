using System;

public class TimerFicha 
{
    private TimerFichaDto timerFichaDto;
    private Relogio relogio;

    public TimerFicha(TimerFichaDto timerFichaDto, Ficha ficha)
    {
        this.timerFichaDto = timerFichaDto;
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
            relogio = new RelogioConcluido();
            relogio.zerarPonteiros(timerFichaDto.RelogioDto);
        }
        else
        {   
            atualizarTempoDesdeUltimaFicha(qtdFichas, fichaEntidade);

            qtdFichas = PlayerPrefsFichas.getQtdFichas(ficha);
            setLabelQtdDeFichas(qtdFichas);

            if(qtdFichas < fichaEntidade.limiteFree)
            {
                DateTime dataSalva = PlayerPrefsFichas.getDataFicha(ficha);
                relogio = new RelogioContador(dataSalva, fichaEntidade);
            }
            else
            {
                relogio = new RelogioConcluido();
                relogio.zerarPonteiros(timerFichaDto.RelogioDto);
            }
        }
    }

    private void atualizarTempoDesdeUltimaFicha(int fichasAtuais, FichaEntidade fichaEntidade)
    {
        int resultado = 0;
        DateTime dataProjetada = PlayerPrefsFichas.getDataFicha(fichaEntidade.ficha);

        while (fichasAtuais < fichaEntidade.limiteFree)
        {
            dataProjetada = dataProjetada.AddHours(fichaEntidade.intervaloHoras)
                                         .AddMinutes(fichaEntidade.intervaloMinutos);

            if(dataProjetada < DateTime.Now)
            {
                resultado++;
            }
            fichasAtuais++;
        }                
        PlayerPrefsFichas.adicionarFicha(fichaEntidade.ficha, resultado);
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
