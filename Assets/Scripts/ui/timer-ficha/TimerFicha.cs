using System;

public class TimerFicha : Executor
{
    private readonly Ficha ficha;

    private TimerFichaDto timerFichaDto;
    private Relogio relogio;   

    public TimerFicha(TimerFichaDto timerFichaDto, SomTimerFicha somTimerFicha, Ficha ficha)
    {
        this.ficha = ficha;
        this.timerFichaDto = timerFichaDto;

        configurarBotao(somTimerFicha);
        setupDeFichas();
    }

    public void update()
    {
        relogio.updateSegundo(timerFichaDto.RelogioDto);
    }

    public void execute()
    {
        PlayerPrefsFichas.ganharFicha(ficha, 1);
        recontarFichas();
    }

    private void setupDeFichas()
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
            recontarFichas();
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
        PlayerPrefsFichas.ganharFicha(fichaEntidade.ficha, resultado);
    }

    private void recontarFichas()
    {
        int qtdFichas = PlayerPrefsFichas.getQtdFichas(ficha);
        setLabelQtdDeFichas(qtdFichas);

        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        if (qtdFichas < fichaEntidade.limiteFree)
        {
            DateTime dataSalva = PlayerPrefsFichas.getDataFicha(ficha);
            relogio = new RelogioContador(dataSalva, fichaEntidade, this);
        }
        else
        {
            relogio = new RelogioConcluido();
            relogio.zerarPonteiros(timerFichaDto.RelogioDto);
        }
    }

    private void setLabelQtdDeFichas(int fichas)
    {
        timerFichaDto.LblQdtFichas.text = fichas.ToString();
    }   

    private void configurarBotao(SomTimerFicha somTimerFicha)
    {
        timerFichaDto.BtnMais.onClick.AddListener(() => {
                somTimerFicha.playSomCliqueIrParaLojaScene();
                ContextoEstaticoUtils.loading.irParaLojaCena();
            }
        );
    }    
}
