using UnityEngine;

public class MovimentacaoParado : MovimentacaoDaGarra
{  
    public override void preInicio()
    {
        acionarTriggerDasPincas();
        if (isNotPlayAnimacaoComemorando())
        {
            playAnimacaoPiscar();            
        }
    }

    public override void fixedUpdate()
    {
        parar();
        Quaternion angIdleMinEsquerda = getAnguloIdleMinEsquerda();
        Quaternion angIdleMinDireita  = getAnguloIdleMinDireita();        
        rotacionarPincaVelocidadeFechamentoFDT(angIdleMinEsquerda, angIdleMinDireita);
    }
}
