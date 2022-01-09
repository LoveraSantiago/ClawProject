public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{
    private ContadorDeTempo contadorDeFimTempo;//PROBLEMA GRANDE CONTADOR DE TEMPO DA GARRA CONTAR TIMEOUT DE PUP!!!!!!

    private AbstractMovimentacaoDaGarraPowerUp movAtual;        
    //private MovimentacaoDaGarraPowerUp movSegCima;//MANAGER ATUAL TEM IFS DEPENDENDO DESSE PROPRIEDADE (ADICIONAR RESP EM MovimentacaoDaGarraPowerUp)
    private AbstractMovimentacaoDaGarraPowerUp movSegCimaMov;//MANAGER ATUAL TEM IFS DEPENDENDO DESSE PROPRIEDADE (ADICIONAR RESP EM MovimentacaoDaGarraPowerUp)

    private AbstractMovimentacaoDaGarraPowerUp movParado;//MANAGER ATUAL TEM IFS DEPENDENDO DESSE PROPRIEDADE (ADICIONAR RESP EM MovimentacaoDaGarraPowerUp)

    public GerenciadorDeMovimentacaoPowerUp()
    {
        AbstractMovimentacaoDaGarraPowerUp.configurarComunicadorComGerMovimentacao(this);                
        movSegCima     = new MovimentacaoAgarrandoEmcima();
        movSegCimaMov  = new MovimentacaoAgarrandoEmcimaEmMovimento();        
        movParado      = new MovimentacaoParadoPowerUp();

        contadorDeFimTempo = new ContadorDeTempo();
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {        
        movParado.produziuEventoDeDirecao(DirecaoDaGarra.CENTRALIZADA);
        trocarParaAcaoVoltarParaCima();
    }    

    public override void update(InputGame inputGame)
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
                contadorDeFimTempo.addTempoLongo();
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

    public void receberGarraInteracaoComPowerUp(PowerUpInteracaoComGarra garraInteracaoPowerUp, float tempoDuracao)
    {
        AbstractMovimentacaoDaGarraPowerUp.receberInteracaoComPowerUp(garraInteracaoPowerUp);                
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
        trocarMovimentador(new MovimentacaoVoltarParaCima());
    }

    public void trocarParaAcaoVoltarParaMeio()
    {
        trocarMovimentador(new MovimentacaoVoltarParaMeioPowerUp());
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
        trocarMovimentador(new MovimentacaoSoltar());
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
