using UnityEngine;

public class MovimentacaoAgarrandoEmcima : AbstractMovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;
    private IntervaloDeTempo intervaloDeTempo;

    public override void preInicio()
    {
        playSomGarraAgarrando();
        fixarVerticalEHorizontal();

        anguloDesejadoDireitaFechado  = Quaternion.Euler(0, 0,  garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());

        intervaloDeTempo = new IntervaloDeTempo(100f);
        interagirComPup();
    }       

    public override void fixedUpdate()
    {        
        if (intervaloDeTempo.contarTempo())
        {
            if(isInteracaoComPowerUpMovimento())
            {
                comunicadorComGerMovimentacao.trocarParaAcaoSegurandoEmMovimento();
            }
            else
            {
                rotacionarPincaVelocidadeFechamentoFDT(anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);        
            }
        }
    }   

    private void interagirComPup()
    {
        if (isInteracaoComPowerUpMovimento())
        {
            configurarAngulos();
        }

        acionarColliderDasPincas();

        garraInteracaoComPowerUp.colocarNaPosicao(getPosicaoCentroGarra());
        garraInteracaoComPowerUp.ligarGravidadeZero();
        garraInteracaoComPowerUp.iniciar();

        intervaloDeTempo.configTempoParaAcao(garraInteracaoComPowerUp.getDelayInicio());
    }

    private void configurarAngulos()
    {
        anguloDesejadoDireitaFechado = Quaternion.Euler(0, 0, garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
    }
}
