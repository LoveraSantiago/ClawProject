using UnityEngine;

public interface AcaoBotaoPowerUp 
{
    bool isClicavel();
    bool isDraggavel();

    void acionar();
    void acionar(Vector3 posicaoAtual);

    PowerUpEntidade.NAME getName();

    Sprite getImgBotao();
}
