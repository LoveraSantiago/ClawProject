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
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.Angulos.IdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.Angulos.IdleMin);
    }

    public DirecaoDaGarra getDirecaoAtual()
    {
        return direcaoVoltar;
    }

    public override void preInicio()
    {
        determinarDirecaoParaVoltarAoMeio();
    }

    public void voltarVindoPelaEsquerda(float velocidadeDirecao)
    {
        if (!isMenorPosHorizontal(posicaoHorizontal))
        {
            moverHorizontalmenteFreeze(velocidadeDirecao);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            voltaFinalizada();
        }
    }

    public void voltarVindoPelaDireita(float velocidadeDirecao)
    {
        if (!isMaiorPosHorizontal(posicaoHorizontal))
        {
            moverHorizontalmenteFreeze(velocidadeDirecao);
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
