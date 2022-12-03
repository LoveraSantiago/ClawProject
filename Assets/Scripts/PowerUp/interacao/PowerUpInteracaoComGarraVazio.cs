using UnityEngine;

public class PowerUpInteracaoComGarraVazio : PowerUpInteracaoComGarra
{
    public void colocarNaPosicao(Vector3 posicao){}

    public void fixarEixoX(){}

    public float getAnguloParaGarraSegurar()
    {
        return 0;
    }

    public float getDelayInicio()
    {
        return 0;
    }

    public TipoInteracaoGarra getInteracaoComGarra()
    {
        return TipoInteracaoGarra.NAO_INTERACAO;
    }

    public void iniciar(){}

    public void ligarGravidadeHum(){}

    public void ligarGravidadeZero(){}

    public void parar(){}    
}
