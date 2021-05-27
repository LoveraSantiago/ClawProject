public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{

    private ContadorDeTempo contadorDeFimTempo;

    private MovimentacaoDaGarra movAtual;
    private MovimentacaoDaGarra movVoltarPCima;
    private MovimentacaoDaGarra movVoltarMeio;
    private MovimentacaoAgarrandoEmcima movSegCima;
    private MovimentacaoDaGarra movSegCimaMov;
    private MovimentacaoDaGarra movSoltar;
    private MovimentacaoDaGarra movParado;

    public GerenciadorDeMovimentacaoPowerUp()
    {
        MovimentacaoDaGarraPowerUp.configurarComunicadorComGerMovimentacao(this);
        movVoltarPCima = new MovimentacaoVoltarParaCima();
        movVoltarMeio  = new MovimentacaoVoltarParaMeio();
        movSegCima     = new MovimentacaoAgarrandoEmcima();
        movSegCimaMov  = new MovimentacaoAgarrandoEmcimaEmMovimento();
        movSoltar      = new MovimentacaoSoltar();
        movParado      = new MovimentacaoParado();

        contadorDeFimTempo = new ContadorDeTempo();
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {
        MovimentacaoDaGarra.produtorEventoDirecao.produziuEvento(DirecaoDaGarra.CENTRALIZADA);
        trocarParaAcaoVoltarParaCima();
    }    

    public override void update()
    {
        if (contadorDeFimTempo.contarTempoDT())
        {
            if (isEstadoAtualSegurandoEmCimaMovimentando())
            {
                trocarParaAcaoSoltar();
            }
            else if (isEstadoAtualSegurandoParado())
            {
                movSegCima.acionarTimeout();
            }
        }
        movAtual.update();
    }

    public override void fixedUpdate()
    {
        movAtual.fixedUpdate();
    }
    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO FIM

    public void receberGarraInteracaoComPowerUp(GarraInteracaoComPowerUp garraInteracaoPowerUp, float tempoDuracao)
    {
        MovimentacaoDaGarraPowerUp.receberInteracaoComPowerUp(garraInteracaoPowerUp);                
        contadorDeFimTempo.configTempoParaAcao(tempoDuracao);
    }

    private bool isEstadoAtualSegurandoEmCimaMovimentando()
    {
        return movAtual == movSegCimaMov;        
    }

    private bool isEstadoAtualSegurandoParado()
    {
        return movAtual == movSegCima;
    }

    //IMPLEMENTANDO INTERFACE COMUNICADORCOMGERMOVPOWERUP INICIO
    public void trocarParaAcaoVoltarParaCima()
    {
        trocarMovimentador(movVoltarPCima);
    }

    public void trocarParaAcaoVoltarParaMeio()
    {
        trocarMovimentador(movVoltarMeio);
    }

    public void trocarParaAcaoSegurandoParado()
    {
        trocarMovimentador(movSegCima);
    }

    public void trocarParaAcaoSegurandoEmMovimento()
    {
        trocarMovimentador(movSegCimaMov);
    }

    public void trocarParaAcaoSoltar()
    {
        trocarMovimentador(movSoltar);
    }

    public void trocarParaAcaoParado()
    {
        trocarMovimentador(movParado);        
    }
    //IMPLEMENTANDO INTERFACE COMUNICADORCOMGERMOVPOWERUP FIM

    //TODO REFATORAR COM GERENCIADOR DE MOVIMENTACAO NORMAL
    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

}
