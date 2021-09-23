using UnityEngine;

public interface AcaoBotaoPowerUp 
{
    bool isClicavel();
    bool isDraggavel();

    void acionar();
    void acionar(Vector3 posicaoAtual);

    PowerUpEnums.TIPO getTipo();

    Sprite getImgBotao();
}
