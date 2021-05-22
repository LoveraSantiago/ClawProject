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
        anguloDesejadoDireitaFechado = Quaternion.Euler(0, 0, garraInteracaoComPowerUp.getAnguloGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloGarraSegurar());

        pincas.acionarCollider();

        garraInteracaoComPowerUp.ligar();
        garraInteracaoComPowerUp.desligarGravidade();
        garraInteracaoComPowerUp.colocarNaPosicao(garraDto.CentroDaGarra.position);
    }   

    public override void fixedUpdate()
    {        
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);        
    }    
    
}
