public class MovimentacaoParaCima : MovimentacaoDaGarraNormal
{
    private int contadorDeSubidas;        

    public MovimentacaoParaCima()
    {
        contadorDeSubidas = 0;        
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
