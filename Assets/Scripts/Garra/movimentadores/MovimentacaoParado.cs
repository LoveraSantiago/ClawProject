using UnityEngine;

public class MovimentacaoParado : MovimentacaoDaGarraPowerUp
{
    //TODO agrupar em um unico lugar os angulos desejados
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;
    
    public MovimentacaoParado()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);
    }

    public override void preInicio()
    {
        pincas.acionarTrigger();
        animacao.piscar();
    }

    public override void fixedUpdate()
    {
        parar();
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
    }
}
