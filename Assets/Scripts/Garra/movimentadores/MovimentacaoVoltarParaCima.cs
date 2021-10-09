using UnityEngine;

public class MovimentacaoVoltarParaCima : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    public MovimentacaoVoltarParaCima()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.Angulos.IdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.Angulos.IdleMin);
    }

    public override void preInicio()
    {
        colocarMassa(3);
        animacao.irParaCima();
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
        pincas.rotacionarFDT(garraDto.Velocidades.MovAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
    }
}
