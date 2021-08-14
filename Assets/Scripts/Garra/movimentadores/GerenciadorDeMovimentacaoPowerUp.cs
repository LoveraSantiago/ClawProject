public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{

    private ContadorDeTempo contadorDeFimTempo;

    private MovimentacaoDaGarraPowerUp movAtual;
    private MovimentacaoDaGarraPowerUp movVoltarPCima;
    private MovimentacaoDaGarraPowerUp movVoltarMeio;
    private MovimentacaoDaGarraPowerUp movSegCima;
    private MovimentacaoDaGarraPowerUp movSegCimaMov;
    private MovimentacaoDaGarraPowerUp movSoltar;
    private MovimentacaoDaGarraPowerUp movParado;

    public GerenciadorDeMovimentacaoPowerUp()
    {
        MovimentacaoDaGarraPowerUp.configurarComunicadorComGerMovimentacao(this);
        movVoltarPCima = new MovimentacaoVoltarParaCima();
        movVoltarMeio  = new MovimentacaoVoltarParaMeioPowerUp();
        movSegCima     = new MovimentacaoAgarrandoEmcima();
        movSegCimaMov  = new MovimentacaoAgarrandoEmcimaEmMovimento();
        movSoltar      = new MovimentacaoSoltar();
        movParado      = new MovimentacaoParadoPowerUp();

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
                movAtual.acionarTimeout();
            }
        }
        movAtual.update();
    }

    public override void fixedUpdate()
    {
        movAtual.fixedUpdate();
    }

    public override void garraComemorar()
    {
        movAtual.comemorar();
    }
    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO FIM

    public void receberGarraInteracaoComPowerUp(PowerUpInteracaoComGarra garraInteracaoPowerUp, float tempoDuracao)
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
        return movAtual == movSegCima || movAtual == movParado;
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

    public void finalizarPowerUp()
    {
        movAtual.finalizarPowerUp();
    }

    //TODO REFATORAR COM GERENCIADOR DE MOVIMENTACAO NORMAL
    private void trocarMovimentador(MovimentacaoDaGarraPowerUp movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }    
}
