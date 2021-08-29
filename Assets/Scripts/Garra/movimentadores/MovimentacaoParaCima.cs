public class MovimentacaoParaCima : MovimentacaoDaGarraNormal,
                                    AcaoSubidaDaGarra.ProdutorEvento

{
    private readonly int ACAO_NORMAL  = 0;
    private readonly int ACAO_ESPERAR = 1;

    private int acaoAtual;
    private int contadorDeSubidas;
    private ProdutorDeEvento<ContagemSubidaGarra> produtorDeEventoSubidaDaGarra;

    public MovimentacaoParaCima()
    {
        contadorDeSubidas = 0;
        produtorDeEventoSubidaDaGarra = new ProdutorDeEvento<ContagemSubidaGarra>();
    }

    public override void preInicio()
    {
        colocarMassa(3);        

        contadorDeSubidas++;
        produtorDeEventoSubidaDaGarra.produziuEvento(new ContagemSubidaGarra(contadorDeSubidas));
        animacao.irParaCima();
        //moverGarraParaCimaFreeze();
    }

    public override void update(InputGame inputGame)
    {        
        if(isAcimaPosInicial())
        {
            colocarNaAlturaInicial();
            if(acaoAtual == ACAO_NORMAL)
            {
                comunicadorComGerMovimentacao.trocarParaAcaoNormal();
            }
            else
            {
                comunicadorComGerMovimentacao.trocarParaAcaoVoltarParaMeio();
            }
        }
    }

    public override void fixedUpdate()
    {
        moverParaCimaFreeze();
    }

    public void toAcaoNormal()
    {
        acaoAtual = ACAO_NORMAL;
    }

    public void toAcaoEsperar()
    {
        acaoAtual = ACAO_ESPERAR;
    }

    ProdutorDeEvento<ContagemSubidaGarra> AcaoSubidaDaGarra.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEventoSubidaDaGarra;
    }
}
