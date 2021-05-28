using UnityEngine;

public interface GarraInteracaoComPowerUp 
{
    PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra();
    float getAnguloGarraSegurar();
    void ligar();
    void parar();
    void colocarNaPosicao(Vector3 posicao);
    void desligarGravidade();
    void ligarGravidade();
    void fixarVerticalmente();
    void timeout();
}
