using UnityEngine;

public class MovimentacaoParado : MovimentacaoDaGarra
{
    //TODO agrupar em um unico lugar os angulos desejados
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;
    
    public MovimentacaoParado()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.Angulos.IdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.Angulos.IdleMin);
    }

    public override void preInicio()
    {
        pincas.acionarTrigger();
        if (!animacao.isComemorando())
        {
            animacao.piscar();
        }
    }

    public override void fixedUpdate()
    {
        parar();
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
    }
}
