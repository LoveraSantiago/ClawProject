using UnityEngine;

public class MovimentacaoParado : AbstractMovimentacaoDaGarra
{  
    public override void preInicio()
    {
        acionarTriggerDasPincas();
        if (isNotPlayAnimacaoComemorando())
        {
            playAnimacaoPiscar();            
        }
        stopSomGarraMovimentoVertical();
    }

    public override void fixedUpdate()
    {
        parar();
        Quaternion angIdleMinEsquerda = getAnguloIdleMinEsquerda();
        Quaternion angIdleMinDireita  = getAnguloIdleMinDireita();        
        rotacionarPincaVelocidadeFechamentoFDT(angIdleMinEsquerda, angIdleMinDireita);
    }
}
