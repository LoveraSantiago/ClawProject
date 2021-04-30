using UnityEngine;

public class MovimentacaoVoltarParaMeio : MovimentacaoDaGarraPowerUp
{
    //TODO QUATERNIONS EM DUPLICIDADE COM MOVIMENTACAOVOLTARPARACIMA
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    private DirecaoDaGarra direcaoVoltar;

    public MovimentacaoVoltarParaMeio()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);
    }

    public override void preInicio()
    {
        determinarDirecaoParaVoltarAoMeio();
    }

    public override void fixedUpdate()
    {
        if(direcaoVoltar == DirecaoDaGarra.ESQUERDA)
        {
            voltarAoMeioVindoPelaEsquerda();
        }
        else
        {
            voltarAoMeioVindoPelaDireita();
        }
    }

    private void determinarDirecaoParaVoltarAoMeio()
    {
        if (isGarraMaiorPosHorizontal(0))
        {
            direcaoVoltar = DirecaoDaGarra.ESQUERDA;            
        }
        else
        {
            direcaoVoltar = DirecaoDaGarra.DIREITA;            
        }
    }

    private void voltarAoMeioVindoPelaEsquerda()
    {
        if (!isGarraMenorPosHorizontal(0))
        {
            moverGarraHorizontalmenteFreeze(-1);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            voltaFinalizada();
        }        
    }

    private void voltarAoMeioVindoPelaDireita()
    {        
        if (!isGarraMaiorPosHorizontal(0))
        {
            moverGarraHorizontalmenteFreeze(1);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            voltaFinalizada();
        }        
    }

    private void voltaFinalizada()
    {
        pararGarra();
        colocarGarraNaPosInicial();
        comunicadorComGerMovimentacao.trocarParaAcaoSegurando();
    }
}
