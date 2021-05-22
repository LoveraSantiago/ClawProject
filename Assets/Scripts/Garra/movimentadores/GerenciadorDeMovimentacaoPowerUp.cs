public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{

    private ContadorDeTempo contadorDeFimTempo;

    private MovimentacaoDaGarra movAtual;
    private MovimentacaoDaGarra movVoltarPCima;
    private MovimentacaoDaGarra movVoltarMeio;
    private MovimentacaoDaGarra movSegCima;
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
        if (contadorDeFimTempo.contarTempoDT() && isEstadoAtualCentralizado())
        {
            trocarParaAcaoSoltar();
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

    private bool isEstadoAtualCentralizado()
    {
        return movAtual == movSegCimaMov;        
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
