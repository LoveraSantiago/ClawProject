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

        anguloDesejadoDireitaFechado = Quaternion.Euler(0, 0, garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());

        pincas.acionarCollider();

        garraInteracaoComPowerUp.iniciar();
        garraInteracaoComPowerUp.ligarGravidadeZero();
        garraInteracaoComPowerUp.colocarNaPosicao(garraDto.CentroDaGarra.position);
    }       

    public override void fixedUpdate()
    {        
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);        
    }   
}
