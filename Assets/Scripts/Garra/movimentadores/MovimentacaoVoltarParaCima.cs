using UnityEngine;

public class MovimentacaoVoltarParaCima : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    public MovimentacaoVoltarParaCima()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -contexto.garraDto.Angulos.IdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, contexto.garraDto.Angulos.IdleMin);
    }

    public override void preInicio()
    {
        colocarMassa(3);
        playAnimacaoIrPCima();
    }

    public override void update(InputGame inputGame)
    {
        if (isAcimaPosInicial())
        {
            parar();
            colocarNaAlturaInicial();
            comunicadorComGerMovimentacao.trocarParaAcaoVoltarParaMeio();
        }
    }

    public override void fixedUpdate()
    {
        moverParaCimaFreeze();
        rotacionarPincaFDT(contexto.garraDto.Velocidades.MovAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
    }
}
