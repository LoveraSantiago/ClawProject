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
                if (garraInteracaoComPowerUp.getInteracaoComGarra() == PowerUpEntidade.INTERACAOGARRA.MOVIMENTO)
                {
                    comunicadorComGerMovimentacao.trocarParaAcaoSegurandoEmMovimento();
                }
                else if (garraInteracaoComPowerUp.getInteracaoComGarra() == PowerUpEntidade.INTERACAOGARRA.PARADO)
                {
                    comunicadorComGerMovimentacao.trocarParaAcaoSegurandoParado();
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
        if (isMaiorPosHorizontal(0))
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

    private void voltarAoMeioVindoPelaEsquerda()
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

    private void voltarAoMeioVindoPelaDireita()
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

    private void voltaFinalizada()
    {
        parar();
        colocarNaPosInicial();
        direcaoVoltar = DirecaoDaGarra.CENTRALIZADA;
        contadorDeTempo.resetContador();
    }
}
