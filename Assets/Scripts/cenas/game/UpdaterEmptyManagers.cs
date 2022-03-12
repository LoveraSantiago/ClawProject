using UnityEngine.EventSystems;

public class UpdaterEmptyManagers : UpdaterManagers
{
    public void fixedUpdate(MainGameDto mainDto){}

    public void onBeginDrag(PointerEventData eventData, MainGameDto mainDto){}

    public void onDrag(PointerEventData eventData, MainGameDto mainDto){}

    public void onEndDrag(PointerEventData eventData, MainGameDto mainDto){}

    public void update(MainGameDto mainDto){}
}
