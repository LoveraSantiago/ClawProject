using UnityEngine;

public class MovimentacaoVoltarParaPosicao : AbstractMovimentacaoDaGarra
{
    private Direcao direcaoVoltar;       
    public bool isDirecaoEsquerda { get { return direcaoVoltar == Direcao.ESQUERDA; } }
    public bool isDirecaoDireita  { get { return direcaoVoltar == Direcao.DIREITA; } }
    public bool isDirecaoCentralizada { get { return direcaoVoltar == Direcao.CENTRALIZADA; } }

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
            direcaoVoltar = Direcao.ESQUERDA;
            playAnimacaoIrPDireita();
        }
        else
        {
            direcaoVoltar = Direcao.DIREITA;
            playAnimacaoIrPEsquerda();
        }
    }

    private void voltaFinalizada(float posicaoHorizontal)
    {
        parar();
        colocarNaPosHorizontal(posicaoHorizontal);
        direcaoVoltar = Direcao.CENTRALIZADA;        
    }
}
