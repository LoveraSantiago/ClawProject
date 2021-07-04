using UnityEngine;

public class MovimentacaoVoltarParaCima : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    public MovimentacaoVoltarParaCima()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);
    }

    public override void preInicio()
    {
        animacao.irParaCima();
    }

    public override void fixedUpdate()
    {
        if (!isAcimaPosInicial())
        {
            moverParaCimaFreeze();
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            parar();
            colocarNaAlturaInicial();
            comunicadorComGerMovimentacao.trocarParaAcaoVoltarParaMeio();
        }
    }
}
