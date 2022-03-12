using UnityEngine.EventSystems;

public interface UpdaterManagers 
{
    void update(MainGameDto mainDto);
    void fixedUpdate(MainGameDto mainDto);
    void onBeginDrag(PointerEventData eventData, MainGameDto mainDto);
    void onEndDrag(PointerEventData eventData, MainGameDto mainDto);
    void onDrag(PointerEventData eventData, MainGameDto mainDto);
}
