using UnityEngine;

public class MovimentacaoVoltarParaPosicao : MovimentacaoDaGarra
{
    private DirecaoDaGarra direcaoVoltar;   

    public DirecaoDaGarra getDirecaoAtual()
    {
        return direcaoVoltar;
    }

    public void preInicio(float posicaoHorizontal)
    {
        determinarDirecaoParaVoltarAoMeio(posicaoHorizontal);
    }

    public void voltarVindoPelaEsquerda(float posicaoHorizontal, float velocidadeDirecao)
    {
        if (!isMenorPosHorizontal(posicaoHorizontal))
        {
            moverHorizontalmenteFreeze(velocidadeDirecao);
            Quaternion angIdleMinDireita  = getAnguloIdleMinDireita();
            Quaternion angIdleMinEsquerda = getAnguloIdleMinEsquerda();
            rotacionarPincaVelocidadeAberturaFDT(angIdleMinEsquerda, angIdleMinDireita);
        }
        else
        {
            voltaFinalizada(posicaoHorizontal);
        }
    }

    public void voltarVindoPelaDireita(float posicaoHorizontal, float velocidadeDirecao)
    {
        if (!isMaiorPosHorizontal(posicaoHorizontal))
        {
            moverHorizontalmenteFreeze(velocidadeDirecao);
            Quaternion angIdleMinDireita  = getAnguloIdleMinDireita();
            Quaternion angIdleMinEsquerda = getAnguloIdleMinEsquerda();
            rotacionarPincaVelocidadeAberturaFDT(angIdleMinEsquerda, angIdleMinDireita);
        }
        else
        {
            voltaFinalizada(posicaoHorizontal);
        }
    }

    private void determinarDirecaoParaVoltarAoMeio(float posicaoHorizontal)
    {
        if (isMaiorPosHorizontal(posicaoHorizontal))
        {
            direcaoVoltar = DirecaoDaGarra.ESQUERDA;
            playAnimacaoIrPDireita();
        }
        else
        {
            direcaoVoltar = DirecaoDaGarra.DIREITA;
            playAnimacaoIrPEsquerda();
        }
    }

    private void voltaFinalizada(float posicaoHorizontal)
    {
        parar();
        colocarNaPosHorizontal(posicaoHorizontal);
        direcaoVoltar = DirecaoDaGarra.CENTRALIZADA;        
    }
}
