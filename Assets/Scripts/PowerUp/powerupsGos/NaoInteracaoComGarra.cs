using UnityEngine;

public class NaoInteracaoComGarra : GarraInteracaoComPowerUp
{
    public PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }

    public void colocarNaPosicao(Vector3 posicao){}

    public void fixarEixoX(){}

    public float getAnguloParaGarraSegurar(){ return 0; }

    public void iniciar(){}

    public void ligarGravidadeHum(){}

    public void ligarGravidadeZero(){}

    public void parar(){}

    public void timeout(){}
}
