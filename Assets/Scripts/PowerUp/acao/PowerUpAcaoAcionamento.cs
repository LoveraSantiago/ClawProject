using UnityEngine;

public interface PowerUpAcaoAcionamento 
{
    void acionado(int indiceBtn, PowerUpEntidade powerUp);
    void acionado(int indiceBtn, PowerUpEntidade powerUp, Vector3 posicaoAtual);
}
