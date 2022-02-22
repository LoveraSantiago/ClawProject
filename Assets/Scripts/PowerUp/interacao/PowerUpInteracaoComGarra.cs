using UnityEngine;

public interface PowerUpInteracaoComGarra : InteracaoPowerUpComComponente
{
    TipoInteracaoGarra getInteracaoComGarra();

    float getAnguloParaGarraSegurar();        
    void parar();
    void colocarNaPosicao(Vector3 posicao);
    void ligarGravidadeZero();
    void ligarGravidadeHum();
    void fixarEixoX();    
}
