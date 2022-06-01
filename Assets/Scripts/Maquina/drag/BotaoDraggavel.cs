using UnityEngine;

public interface BotaoDraggavel 
{
    void prepararDraggagem(Vector3 posInicialDrag);
    void updateDrag(Vector2 delta, BotoesPowerUpDto btnPowerUpsDto);
    bool isDragFinalizadoAtivouPowerUp(BotoesPowerUpDto btnPowerUpsDto);
}
