using UnityEngine;

public interface PowerUpAcionamento 
{
    void acionado(PowerUp powerUp);
    void acionado(PowerUp powerUp, Vector3 posicaoAtual);
}
