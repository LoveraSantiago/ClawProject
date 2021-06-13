using UnityEngine;

public interface GarraInteracaoComPowerUp 
{
    PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra();
    float getAnguloParaGarraSegurar();    
    void iniciar();
    void parar();
    void colocarNaPosicao(Vector3 posicao);
    void ligarGravidadeZero();
    void ligarGravidadeHum();
    void fixarVerticalmente();
    void timeout();
}
