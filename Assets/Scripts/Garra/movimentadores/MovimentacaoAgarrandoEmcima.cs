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

        acionarColliderDasPincas();

        garraInteracaoComPowerUp.iniciar();
        garraInteracaoComPowerUp.ligarGravidadeZero();
        garraInteracaoComPowerUp.colocarNaPosicao(getPosicaoCentroGarra());

    }       

    public override void fixedUpdate()
    {
        rotacionarPincaVelocidadeFechamentoFDT(anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);        
    }   
}
