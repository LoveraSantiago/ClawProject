using UnityEngine;

public class MovimentacaoAgarrandoEmbaixo : MovimentacaoDaGarraNormal
{   
    public override void preInicio()
    {
        agarrando();
        colocarMassa(1);        
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
