using UnityEngine;

public class MovimentacaoVoltarParaPosicao : MovimentacaoDaGarra
{
    private float posicaoHorizontal;
    private DirecaoDaGarra direcaoVoltar;   

    public MovimentacaoVoltarParaPosicao(float posicaoHorizontal)
    {
        this.posicaoHorizontal = posicaoHorizontal;                
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
            Quaternion angIdleMinDireita  = angulosTemp.angIdleMinDireita;
            Quaternion angIdleMinEsquerda = angulosTemp.angIdleMinEsquerda;
            rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloAbertura, angIdleMinEsquerda, angIdleMinDireita);
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
            Quaternion angIdleMinDireita = angulosTemp.angIdleMinDireita;
            Quaternion angIdleMinEsquerda = angulosTemp.angIdleMinEsquerda;
            rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloAbertura, angIdleMinEsquerda, angIdleMinDireita);
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
            playAnimacaoIrPDireita();
        }
        else
        {
            direcaoVoltar = DirecaoDaGarra.DIREITA;
            playAnimacaoIrPEsquerda();
        }
    }

    private void voltaFinalizada()
    {
        parar();
        colocarNaPosHorizontal(posicaoHorizontal);
        direcaoVoltar = DirecaoDaGarra.CENTRALIZADA;        
    }
}
