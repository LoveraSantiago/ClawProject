using UnityEngine;

public class AdapterDraggavelVazio : Draggavel
{
    public void prepararDraggagem(Vector3 posInicialDrag){}
    public void updateDrag(Vector2 delta, BotoesPowerUpDto btnPowerUpsDto) {}
    public void dragFinalizado(MonoBehaviour monoBehaviour){}
    public bool isDragFinalizadoAtivouPowerUp(BotoesPowerUpDto btnPowerUpsDto) { return false; }
}
