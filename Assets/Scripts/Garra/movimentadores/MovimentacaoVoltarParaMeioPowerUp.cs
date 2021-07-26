using UnityEngine;

public class MovimentacaoVoltarParaMeioPowerUp : MovimentacaoDaGarraPowerUp
{
    private MovimentacaoVoltarParaMeio movVoltarParaMeio;

    public MovimentacaoVoltarParaMeioPowerUp()
    {
        movVoltarParaMeio = new MovimentacaoVoltarParaMeio();
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
            movVoltarParaMeio.voltarAoMeioVindoPelaEsquerda();
        }
        else if(direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            movVoltarParaMeio.voltarAoMeioVindoPelaDireita();
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
