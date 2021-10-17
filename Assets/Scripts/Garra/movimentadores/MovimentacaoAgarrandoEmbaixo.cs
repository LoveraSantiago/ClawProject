using UnityEngine;

public class MovimentacaoAgarrandoEmbaixo : MovimentacaoDaGarraNormal
{
    public MovimentacaoAgarrandoEmbaixo()
    {     
    }
    
    public override void preInicio()
    {
        agarrando();
        colocarMassa(1);        
    }

    public override void fixedUpdate()
    {
        parar();

        Quaternion angFechamentoEsquerda = angulosTemp.angFechamentoEsquerda;
        Quaternion angFechamentoDireita  = angulosTemp.angFechamentoDireita;

        rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloFechamento, angFechamentoEsquerda, angFechamentoDireita);
        
        if (isPincaDireitaNoAngulo(angFechamentoDireita))
        {       
            comunicadorComGerMovimentacao.trocarParaAcaoSubindo();
        }        
    }    
}
