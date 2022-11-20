public class MovimentacaoAgarrandoEmbaixo : AbstractMovimentacaoDaGarraNormal
{   
    public override void preInicio()
    {
        agarrando();
        colocarMassa(getMassaMovimentacaoAgarrar());
        stopSomGarraMovimentoVertical();
    }

    public override void fixedUpdate()
    {
        parar();       

        rotacionarPincaVelocidadeFechamentoFDT();
        if (isPincaDireitaNoAnguloDeFechamento())
        {       
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
