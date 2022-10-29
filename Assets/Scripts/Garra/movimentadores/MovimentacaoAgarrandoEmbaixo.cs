public class MovimentacaoAgarrandoEmbaixo : AbstractMovimentacaoDaGarraNormal
{   
    public override void preInicio()
    {
        agarrando();
        colocarMassa(getMassaMovimentacaoAgarrar());        
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
