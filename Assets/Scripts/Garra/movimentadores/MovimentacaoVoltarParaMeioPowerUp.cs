public class MovimentacaoVoltarParaMeioPowerUp : AbstractMovimentacaoDaGarraPowerUp
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
        if (movVoltarParaMeio.isDirecaoEsquerda)
        {
            movVoltarParaMeio.voltarVindoPelaEsquerda(getPosicaoHorizontalMeio(), -1);
        }
        else if(movVoltarParaMeio.isDirecaoDireita)
        {
            movVoltarParaMeio.voltarVindoPelaDireita(getPosicaoHorizontalMeio(), 1);
        }
        else if(movVoltarParaMeio.isDirecaoCentralizada)
        {
            if (garraInteracaoComPowerUp.getInteracaoComGarra() == TipoInteracaoGarra.MOVIMENTO)
            {
                comunicadorComGerMovimentacao.trocarParaAcaoSegurandoEmMovimento();
            }
            else if (garraInteracaoComPowerUp.getInteracaoComGarra() == TipoInteracaoGarra.PARADO)
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
