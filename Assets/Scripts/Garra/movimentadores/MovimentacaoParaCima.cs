public class MovimentacaoParaCima : MovimentacaoDaGarraNormal,
                                    AcaoSubidaDaGarra.ProdutorEvento

{
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

    public override void update()
    {        
        if(isAcimaPosInicial())
        {            
            comunicadorComGerMovimentacao.trocarParaAcaoNormal();
        }
    }

    public override void fixedUpdate()
    {
        moverParaCimaFreeze();
    }

    ProdutorDeEvento<ContagemSubidaGarra> AcaoSubidaDaGarra.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEventoSubidaDaGarra;
    }
}
