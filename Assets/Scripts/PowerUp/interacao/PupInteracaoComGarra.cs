using UnityEngine;

public interface PupInteracaoComGarra : InteracaoPupComComponente
{
    PowerUpEnums.INTERACAOGARRA getInteracaoComGarra();

    float getAnguloParaGarraSegurar();    
    void iniciar();
    void parar();
    void colocarNaPosicao(Vector3 posicao);
    void ligarGravidadeZero();
    void ligarGravidadeHum();
    void fixarEixoX();
    //TODO garra nao deve cuidar de timeout
    void timeout();
}
