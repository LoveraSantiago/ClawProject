public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{
    private IntervaloDeTempo intervaloFimTempo;//PROBLEMA GRANDE CONTADOR DE TEMPO DA GARRA CONTAR TIMEOUT DE PUP!!!!!!

    private AbstractMovimentacaoDaGarraPowerUp movAtual;    

    public GerenciadorDeMovimentacaoPowerUp()
    {
        AbstractMovimentacaoDaGarraPowerUp.configurarComunicadorComGerMovimentacao(this);

        trocarParaAcaoParado();
        intervaloFimTempo = new IntervaloDeTempo();
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {
        movAtual.produziuEventoDeDirecao(DirecaoDaGarra.CENTRALIZADA);        
        trocarParaAcaoVoltarParaCima();
    }    

    public override void update(InputGame inputGame)
    {
        if (intervaloFimTempo.contarTempoDT())
        {
            if (movAtual.isEstadoSegurandoEmCimaMovimentando())
            {
                trocarParaAcaoSoltar();
            }
            else if (movAtual.isEstadoSegurandoParado())
            {
                movAtual.acionarTimeout();
                intervaloFimTempo.addTempoLongo();
            }
        }
        movAtual.update(inputGame);
    }

    public override void fixedUpdate()
    {
        movAtual.fixedUpdate();
    }

    public override void garraComemorar()
    {
        movAtual.playAnimacaoComemorar();
    }
    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO FIM

    public void receberGarraInteracaoComPowerUp(PupInteracaoComGarra garraInteracaoPowerUp, float tempoDuracao)
    {
        AbstractMovimentacaoDaGarraPowerUp.receberInteracaoComPowerUp(garraInteracaoPowerUp);                
        intervaloFimTempo.configTempoParaAcao(tempoDuracao);
    }   

    //IMPLEMENTANDO INTERFACE COMUNICADORCOMGERMOVPOWERUP INICIO
    public void trocarParaAcaoVoltarParaCima()
    {
        trocarMovimentador(new MovimentacaoVoltarParaCima());
    }

    public void trocarParaAcaoVoltarParaMeio()
    {
        trocarMovimentador(new MovimentacaoVoltarParaMeioPowerUp());
    }

    public void trocarParaAcaoSegurandoParado()
    {
        trocarMovimentador(new MovimentacaoAgarrandoEmcima());
    }

    public void trocarParaAcaoSegurandoEmMovimento()
    {
        trocarMovimentador(new MovimentacaoAgarrandoEmcimaEmMovimento());
    }

    public void trocarParaAcaoSoltar()
    {
        trocarMovimentador(new MovimentacaoSoltar());
    }

    public void trocarParaAcaoParado()
    {
        trocarMovimentador(new MovimentacaoParadoPowerUp());        
    }
    //IMPLEMENTANDO INTERFACE COMUNICADORCOMGERMOVPOWERUP FIM

    public void finalizarPowerUp()
    {
        movAtual.finalizarPowerUp();
    }

    //TODO REFATORAR COM GERENCIADOR DE MOVIMENTACAO NORMAL
    private void trocarMovimentador(AbstractMovimentacaoDaGarraPowerUp movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

    public override ProdutorDeEvento<DirecaoDaGarra> getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)movAtual).getProdutorDeEvento();
    }
}
