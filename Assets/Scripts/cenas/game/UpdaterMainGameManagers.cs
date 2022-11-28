using UnityEngine;
using UnityEngine.EventSystems;

public class UpdaterMainGameManagers : UpdaterManagers
{
    private AllGameManagers allGameMangers;

    public UpdaterMainGameManagers(AllGameManagers allGameMangers)
    {
        this.allGameMangers = allGameMangers;        
    }

    public void update(MainGameDto mainDto)
    {
        allGameMangers.getInputGame()     .update(mainDto.MaquinaDto.ReferenciaChao);
        allGameMangers.getMaquinaManager().update(mainDto.MaquinaDto, allGameMangers.getInputGame());
        allGameMangers.getGarraManager()  .update(mainDto.GarraDto, allGameMangers.getInputGame());
        allGameMangers.getPowerUpManager().update();
    }

    public void fixedUpdate(MainGameDto mainDto)
    {
        allGameMangers.getGarraManager()  .fixedUpdate(mainDto.GarraDto);
        allGameMangers.getMaquinaManager().fixedUpdate();
    }

    public void onBeginDrag(PointerEventData eventData, MainGameDto mainDto)
    {
        Vector3 posicaoToque = eventData.pointerCurrentRaycast.worldPosition;       
        if (allGameMangers.getInputGame()
                .aconteceuDragNaAreaInferior(posicaoToque, mainDto.MaquinaDto.ReferenciaChao))
        {
            //Debug.Log("updatermaingamemanager begin drag");
            allGameMangers.getMaquinaManager().onBeginDrag(posicaoToque);
        }
    }

    public void onDrag(PointerEventData eventData, MainGameDto mainDto)
    {
        //Debug.Log("updatermaingamemanager on drag");
        Vector3 posicaoToque = eventData.pointerCurrentRaycast.worldPosition;
        allGameMangers.getMaquinaManager().onDragPowerUp(posicaoToque, mainDto.MaquinaDto);
    }

    public void onEndDrag(PointerEventData eventData, MainGameDto mainDto)
    {
        allGameMangers.getMaquinaManager().onEndDragPowerUp(mainDto.MaquinaDto);
    }
}
