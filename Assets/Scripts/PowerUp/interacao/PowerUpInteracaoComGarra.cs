using UnityEngine;

public interface PowerUpInteracaoComGarra 
{
    PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra();

    float getAnguloParaGarraSegurar();    
    void iniciar();
    void parar();
    void colocarNaPosicao(Vector3 posicao);
    void ligarGravidadeZero();
    void ligarGravidadeHum();
    void fixarEixoX();
    void timeout();
}
