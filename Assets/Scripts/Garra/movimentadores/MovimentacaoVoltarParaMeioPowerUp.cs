using UnityEngine;

public class MovimentacaoVoltarParaMeioPowerUp : MovimentacaoDaGarraPowerUp
{
    private MovimentacaoVoltarParaPosicao movVoltarParaMeio;

    public MovimentacaoVoltarParaMeioPowerUp()
    {
        movVoltarParaMeio = new MovimentacaoVoltarParaPosicao();
    }

    public override void preInicio()
    {
        movVoltarParaMeio.preInicio(getPosicaoHorizontalMeio());
    }

    public override void fixedUpdate()
    {
        DirecaoDaGarra direcaoVoltar = movVoltarParaMeio.getDirecaoAtual();
        if (direcaoVoltar == DirecaoDaGarra.ESQUERDA)
        {
            movVoltarParaMeio.voltarVindoPelaEsquerda(getPosicaoHorizontalMeio(), -1);
        }
        else if(direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            movVoltarParaMeio.voltarVindoPelaDireita(getPosicaoHorizontalMeio(), 1);
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
