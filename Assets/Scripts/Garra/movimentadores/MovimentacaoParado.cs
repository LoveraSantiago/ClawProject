using UnityEngine;

public class MovimentacaoParado : MovimentacaoDaGarra
{   
    public MovimentacaoParado()
    { 
    }

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
        Quaternion angIdleMinEsquerda = angulosTemp.angIdleMinEsquerda;
        Quaternion angIdleMinDireita  = angulosTemp.angIdleMinDireita;
        rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloFechamento, angIdleMinEsquerda, angIdleMinDireita);
    }
}
