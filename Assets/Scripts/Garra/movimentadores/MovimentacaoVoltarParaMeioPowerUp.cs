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
            movVoltarParaMeio.voltarVindoPelaEsquerda(-1);
        }
        else if(direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            movVoltarParaMeio.voltarVindoPelaDireita(1);
        }
        else if(direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
        {
            if (garraInteracaoComPowerUp.getInteracaoComGarra() == PowerUpEnums.INTERACAOGARRA.MOVIMENTO)
            {
                comunicadorComGerMovimentacao.trocarParaAcaoSegurandoEmMovimento();
            }
            else if (garraInteracaoComPowerUp.getInteracaoComGarra() == PowerUpEnums.INTERACAOGARRA.PARADO)
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
