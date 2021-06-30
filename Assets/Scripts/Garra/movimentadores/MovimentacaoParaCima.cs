public class MovimentacaoParaCima : MovimentacaoDaGarraNormal
{
    private int contadorDeSubidas;        

    public MovimentacaoParaCima()
    {
        contadorDeSubidas = 0;        
    }

    public override void preInicio()
    {
        colocarMassa(3);        

        contadorDeSubidas++;
        produtorDeEventoSubidaDaGarra.produziuEvento(contadorDeSubidas);
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
}
