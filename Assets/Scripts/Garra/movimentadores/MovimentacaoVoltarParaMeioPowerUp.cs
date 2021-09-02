using UnityEngine;

public class MovimentacaoVoltarParaMeioPowerUp : MovimentacaoDaGarraPowerUp
{
    private MovimentacaoVoltarParaPosicao movVoltarParaMeio;

    public MovimentacaoVoltarParaMeioPowerUp()
    {
        movVoltarParaMeio = new MovimentacaoVoltarParaPosicao(0);
    }

    public override void preInicio()
    {
        movVoltarParaMeio.preInicio();
    }

    public override void fixedUpdate()
    {
        DirecaoDaGarra direcaoVoltar = movVoltarParaMeio.getDirecaoAtual();
        if (direcaoVoltar == DirecaoDaGarra.ESQUERDA)
        {
            movVoltarParaMeio.voltarVindoPelaEsquerda();
        }
        else if(direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            movVoltarParaMeio.voltarVindoPelaDireita();
        }
        else if(direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
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
