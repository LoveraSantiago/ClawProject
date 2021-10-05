using UnityEngine;

public interface AcaoBotaoPowerUp 
{
    bool isClicavel();
    bool isDraggavel();

    void acionar(int indiceBtn);
    void acionar(int indiceBtn, Vector3 posicaoAtual);

    PowerUpEnums.TIPO getTipo();

    Sprite getImgBotao();
}
