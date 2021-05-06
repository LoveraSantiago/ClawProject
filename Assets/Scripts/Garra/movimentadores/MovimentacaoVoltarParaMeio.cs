using UnityEngine;

public class MovimentacaoVoltarParaMeio : MovimentacaoDaGarraPowerUp
{
    //TODO QUATERNIONS EM DUPLICIDADE COM MOVIMENTACAOVOLTARPARACIMA
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;
    private ContadorDeTempo contadorDeTempo;

    private DirecaoDaGarra direcaoVoltar;

    public MovimentacaoVoltarParaMeio()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);

        contadorDeTempo = new ContadorDeTempo(0.25f);
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
        else if(direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            voltarAoMeioVindoPelaDireita();
        }
        else if(direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
        {
            if (contadorDeTempo.contarTempoFDT())
            {
                if (garraInteracaoComPowerUp.garraPodeSegurar())
                {
                    comunicadorComGerMovimentacao.trocarParaAcaoSegurando();
                }
                else
                {
                    comunicadorComGerMovimentacao.trocarParaAcaoParado();
                }
            }
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
        direcaoVoltar = DirecaoDaGarra.CENTRALIZADA;
        contadorDeTempo.resetContador();
    }
}
