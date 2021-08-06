using UnityEngine;

public class MovimentacaoVoltarParaMeio : MovimentacaoDaGarra
{
    private DirecaoDaGarra direcaoVoltar;

    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    public MovimentacaoVoltarParaMeio()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);
    }

    public DirecaoDaGarra getDirecaoAtual()
    {
        return direcaoVoltar;
    }

    public override void preInicio()
    {
        determinarDirecaoParaVoltarAoMeio();
    }

    public void voltarAoMeioVindoPelaEsquerda()
    {
        if (!isMenorPosHorizontal(0))
        {
            moverHorizontalmenteFreeze(-1);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            voltaFinalizada();
        }
    }

    public void voltarAoMeioVindoPelaDireita()
    {
        if (!isMaiorPosHorizontal(0))
        {
            moverHorizontalmenteFreeze(1);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            voltaFinalizada();
        }
    }

    private void determinarDirecaoParaVoltarAoMeio()
    {
        if (isMaiorPosHorizontal(0))
        {
            direcaoVoltar = DirecaoDaGarra.ESQUERDA;
            if (!animacao.isComemorando())
            {
                animacao.irParaDireita();
            }
        }
        else
        {
            direcaoVoltar = DirecaoDaGarra.DIREITA;
            if (!animacao.isComemorando())
            {
                animacao.irParaEsquerda();
            }
        }
    }

    private void voltaFinalizada()
    {
        parar();
        colocarNaPosInicial();
        direcaoVoltar = DirecaoDaGarra.CENTRALIZADA;        
    }
}
