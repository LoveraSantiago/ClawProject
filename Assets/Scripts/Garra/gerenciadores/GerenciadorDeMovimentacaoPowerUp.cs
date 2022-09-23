public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{
    private AbstractMovimentacaoDaGarraPowerUp movAtual;    

    public GerenciadorDeMovimentacaoPowerUp()
    {
        AbstractMovimentacaoDaGarraPowerUp.configurarComunicadorComGerMovimentacao(this);
        trocarParaAcaoParado();     
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {
        movAtual.produziuEventoDeDirecao(Direcao.CENTRALIZADA);        
        trocarParaAcaoVoltarParaCima();
    }    

    public override void update(InputGame inputGame)
    {   
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

    public void receberGarraInteracaoComPowerUp(InteracaoPowerUpComComponente interacaoPupComComponentes, float tempoDuracao)
    {        
        PowerUpInteracaoComGarra interacaoComGarra = InteracaoComponentesUtils.getAsInteracaoComGarra(interacaoPupComComponentes);
        AbstractMovimentacaoDaGarraPowerUp.receberInteracaoComPowerUp(interacaoComGarra);                
    }

    public void largarPowerUp()
    {
        if (movAtual.isEstadoSegurandoEmCimaMovimentando())
        {
            trocarParaAcaoSoltar();
        }
    }

    public void finalizarPowerUp()
    {
        movAtual.finalizarPowerUp();
    }

    //IMPLEMENTANDO INTERFACE COMUNICADORCOMGERMOVPOWERUP INICIO
    public void trocarParaAcaoVoltarParaCima()
    {
        trocarMovimentador(new MovimentacaoVoltarParaCimaPowerUp());
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

    //TODO REFATORAR COM GERENCIADOR DE MOVIMENTACAO NORMAL
    private void trocarMovimentador(AbstractMovimentacaoDaGarraPowerUp movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

    public override ProdutorDeEvento<Direcao> getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)movAtual).getProdutorDeEvento();
    }
}
