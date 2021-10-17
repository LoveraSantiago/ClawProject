using UnityEngine;

public class MovimentacaoAgarrandoEmcima : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;    

    public MovimentacaoAgarrandoEmcima()
    {        
    }

    public override void preInicio()
    {
        fixarVerticalEHorizontal();

        anguloDesejadoDireitaFechado  = Quaternion.Euler(0, 0, garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());

        acionarColliderDasPincas();

        garraInteracaoComPowerUp.iniciar();
        garraInteracaoComPowerUp.ligarGravidadeZero();
        garraInteracaoComPowerUp.colocarNaPosicao(garra.garraDto.CentroDaGarra.position);
    }       

    public override void fixedUpdate()
    {
        rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloFechamento, anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);        
    }   
}
