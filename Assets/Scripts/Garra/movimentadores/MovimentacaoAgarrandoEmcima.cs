using UnityEngine;

public class MovimentacaoAgarrandoEmcima : AbstractMovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;       

    public override void preInicio()
    {
        playSomGarraAgarrando();
        fixarVerticalEHorizontal();

        anguloDesejadoDireitaFechado  = Quaternion.Euler(0, 0,  garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());

        interagirComPup();
    }       

    public override void fixedUpdate()
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

    private void interagirComPup()
    {
        if (isInteracaoComPowerUpMovimento())
        {
            configurarAngulos();
        }

        acionarColliderDasPincas();

        garraInteracaoComPowerUp.iniciar();
        garraInteracaoComPowerUp.ligarGravidadeZero();
        garraInteracaoComPowerUp.colocarNaPosicao(getPosicaoCentroGarra());
    }

    private void configurarAngulos()
    {
        anguloDesejadoDireitaFechado = Quaternion.Euler(0, 0, garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
    }
}
