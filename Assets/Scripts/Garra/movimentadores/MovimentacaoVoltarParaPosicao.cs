using UnityEngine;

public class MovimentacaoVoltarParaPosicao : MovimentacaoDaGarra
{
    private float posicaoHorizontal;
    private DirecaoDaGarra direcaoVoltar;

    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    public MovimentacaoVoltarParaPosicao(float posicaoHorizontal)
    {
        this.posicaoHorizontal = posicaoHorizontal;
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

    public void voltarVindoPelaEsquerda()
    {
        if (!isMenorPosHorizontal(posicaoHorizontal))
        {
            moverHorizontalmenteFreeze(-1);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            voltaFinalizada();
        }
    }

    public void voltarVindoPelaDireita()
    {
        if (!isMaiorPosHorizontal(posicaoHorizontal))
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
        if (isMaiorPosHorizontal(posicaoHorizontal))
        {
            direcaoVoltar = DirecaoDaGarra.ESQUERDA;
            animacao.irParaDireita();            
        }
        else
        {
            direcaoVoltar = DirecaoDaGarra.DIREITA;
            animacao.irParaEsquerda();            
        }
    }

    private void voltaFinalizada()
    {
        parar();
        colocarNaPosHorizontal(posicaoHorizontal);
        direcaoVoltar = DirecaoDaGarra.CENTRALIZADA;        
    }
}
