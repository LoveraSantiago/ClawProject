public class MovimentacaoAgarrandoEmbaixo : AbstractMovimentacaoDaGarraNormal
{   
    public override void preInicio()
    {
        playSomGarraAgarrando();
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
