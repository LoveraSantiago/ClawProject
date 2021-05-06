using UnityEngine;

public interface Draggavel 
{
    void prepararDraggagem(Vector3 posInicialDrag);
    void updateDrag(Vector2 delta);
    bool isDragFinalizadoAtivouPowerUp(MonoBehaviour monoBehaviour);
}
