using System;

public class TimerFicha : OperacaoFicha, 
                          Executor
{
    private static PlayerPrefsFichas playerPrefsFichas = new PlayerPrefsFichas();
    private readonly Ficha ficha;

    private TimerFichaDto timerFichaDto;
    private AnimacaoTimerFicha animacaoTimerFicha;
    private Relogio relogio;
    private IntervaloDeTempo intervaloDeTempo;

    public TimerFicha(TimerFichaDto timerFichaDto, SomTimerFicha somTimerFicha, Ficha ficha)
    {
        this.ficha = ficha;
        this.timerFichaDto = timerFichaDto;
        animacaoTimerFicha = new AnimacaoTimerFicha(timerFichaDto.Animator);
        intervaloDeTempo = new IntervaloDeTempo();

        configurarBotao(somTimerFicha);
        setupDeFichas();
    }

    public void update()
    {
        intervaloDeTempo.contarTempo();
        relogio.updateSegundo(timerFichaDto.RelogioDto);
    }

    public void execute()
    {
        ganharFichas(1);        
    }

    public bool ganharFichas(int qtdFichas)
    {
        if (intervaloDeTempo.contarTempo())
        {
            playerPrefsFichas.ganharFicha(ficha, qtdFichas);
            recontarFichas(qtdFichas);
            intervaloDeTempo.configTempoParaAcao(1);
            return true;
        }
        return false;
    }

    public void consumirFicha(int qtd)
    {
        playerPrefsFichas.consumirFicha(ficha, qtd);
        recontarFichas(-qtd);
    }

    private void setupDeFichas()
    {
        int qtdFichas = playerPrefsFichas.getQtdFichas(ficha);
        setLabelQtdDeFichas(qtdFichas, 0);

        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        if(qtdFichas >= fichaEntidade.limiteFree)
        {
            relogio = new RelogioConcluido();
            relogio.zerarPonteiros(timerFichaDto.RelogioDto);
        }
        else
        {   
            atualizarTempoDesdeUltimaFicha(qtdFichas, fichaEntidade);
            recontarFichas(0);
        }
    }

    private void atualizarTempoDesdeUltimaFicha(int fichasAtuais, FichaEntidade fichaEntidade)
    {
        int resultado = 0;
        DateTime dataProjetada = playerPrefsFichas.getDataFicha(fichaEntidade.ficha);

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
        playerPrefsFichas.ganharFicha(fichaEntidade.ficha, resultado);
    }

    private void recontarFichas(int fichasGanhas)
    {
        int qtdFichas = playerPrefsFichas.getQtdFichas(ficha);
        setLabelQtdDeFichas(qtdFichas, fichasGanhas);

        FichaEntidade fichaEntidade = FichaEntidade.getFichaEntidade(ficha);
        if (qtdFichas < fichaEntidade.limiteFree)
        {
            DateTime dataSalva = playerPrefsFichas.getDataFicha(ficha);
            relogio = new RelogioContador(dataSalva, fichaEntidade, this);
        }
        else
        {
            relogio = new RelogioConcluido();
            relogio.zerarPonteiros(timerFichaDto.RelogioDto);
        }
    }

    private void setLabelQtdDeFichas(int fichasAtual, int fichasGanhas)
    {
        timerFichaDto.LblQdtFichasOld.text = fichasAtual.ToString();
        if(fichasGanhas > 0)
        {
            timerFichaDto.LblQdtAcrescimo.text = String.Format("+{0}", fichasGanhas);            
            timerFichaDto.LblQdtFichasOld.text = (fichasAtual - fichasGanhas).ToString();            
            animacaoTimerFicha.playGanharFicha();            
        }
        else if(fichasGanhas < 0)
        {
            fichasGanhas = -fichasGanhas;
            timerFichaDto.LblQdtAcrescimo.text = String.Format("-{0}", fichasGanhas);            
            timerFichaDto.LblQdtFichasOld.text = (fichasAtual + fichasGanhas).ToString();             
            animacaoTimerFicha.playGastarFicha();
        }        
        timerFichaDto.LblQdtFichasAtual.text = fichasAtual.ToString();
        
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
