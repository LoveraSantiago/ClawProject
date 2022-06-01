using UnityEngine;

public interface Draggavel 
{
    bool isDragAcionavel(Vector2 posicaoDrag);
    bool foiDragAcionado();
    void onBeginDrag(Vector3 posicao);
    void onDrag(Vector2 delta, MaquinaDto maquinaDto);
    void onEndDrag(MaquinaDto maquinaDto);
}
