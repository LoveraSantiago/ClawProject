using UnityEngine;

public interface GarraInteracaoComPowerUp 
{
    bool garraPodeSegurar();
    float getAnguloGarraSegurar();
    void ligar();
    void parar();
    void colocarNaPosicao(Vector3 posicao);
    void desligarGravidade();
    void ligarGravidade();
    void fixarVerticalmente();
}
