using UnityEngine;

public class AdapterDraggavelVazio : Draggavel
{
    public void prepararDraggagem(Vector3 posInicialDrag){}
    public void updateDrag(Vector2 delta){}
    public void dragFinalizado(MonoBehaviour monoBehaviour){}
    public bool isDragFinalizadoAtivouPowerUp(){ return false; }
}
