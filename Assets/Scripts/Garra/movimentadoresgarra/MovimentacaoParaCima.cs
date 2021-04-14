public class MovimentacaoParaCima : MovimentacaoDaGarra
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
        diminuirInerciaDaGarra();

        contadorDeSubidas++;
        produtorDeEventoSubidaDaGarra.produziuEvento(contadorDeSubidas);
        moverGarraParaCima();
    }

    public override void update()
    {        
        if(isGarraAcimaPosInicial())
        {
            diminuirInerciaDaGarra();
            comunicadorComGerMovimentacao.trocarParaAcaoNormal();
        }
    }

    public override void fixedUpdate()
    {        
    }        
}
