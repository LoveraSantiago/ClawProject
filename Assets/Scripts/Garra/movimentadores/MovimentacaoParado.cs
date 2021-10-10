using UnityEngine;

public class MovimentacaoParado : MovimentacaoDaGarra
{
    //TODO agrupar em um unico lugar os angulos desejados
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;
    
    public MovimentacaoParado()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -contexto.garraDto.Angulos.IdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, contexto.garraDto.Angulos.IdleMin);
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
        rotacionarPincaFDT(contexto.garraDto.Velocidades.MovAnguloFechamento, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
    }
}
