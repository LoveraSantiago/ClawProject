public class MovimentacaoParaCima : MovimentacaoDaGarraNormal
{
    private int contadorDeSubidas;    
    public ProdutorDeEvento<int> produtorDeEventoSubidaDaGarra { get; private set; }

    public MovimentacaoParaCima()
    {
        contadorDeSubidas = 0;
        produtorDeEventoSubidaDaGarra = new ProdutorDeEvento<int>();
    }

    public override void preInicio()
    {
        colocarMassaNaGarra(3);        

        contadorDeSubidas++;
        produtorDeEventoSubidaDaGarra.produziuEvento(contadorDeSubidas);
        //moverGarraParaCimaFreeze();
    }

    public override void update()
    {        
        if(isGarraAcimaPosInicial())
        {            
            comunicadorComGerMovimentacao.trocarParaAcaoNormal();
        }
    }

    public override void fixedUpdate()
    {
        moverGarraParaCimaFreeze();
    }
}
