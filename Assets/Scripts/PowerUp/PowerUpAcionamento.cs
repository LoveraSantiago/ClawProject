using UnityEngine;

public interface PowerUpAcionamento 
{
    void acionado(int indiceBtn, PowerUpEntidade powerUp);
    void acionado(int indiceBtn, PowerUpEntidade powerUp, Vector3 posicaoAtual);
}
