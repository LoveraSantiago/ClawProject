using UnityEngine;

public interface PowerUpAcionamento 
{
    void acionado(PowerUpEntidade powerUp);
    void acionado(PowerUpEntidade powerUp, Vector3 posicaoAtual);
}
