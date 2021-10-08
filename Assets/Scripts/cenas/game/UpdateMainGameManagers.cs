using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateMainGameManagers 
{
    private GarraManager garraManager;
    private MaquinaManager maquinaManager;
    private InputGame inputGame;

    public UpdateMainGameManagers(
        GarraManager garraManager, MaquinaManager maquinaManager, InputGame inputGame)
    {
        this.garraManager = garraManager;
        this.inputGame = inputGame;
        this.maquinaManager = maquinaManager;
    }

    public void update(MainGameDto mainDto)
    {
        inputGame.update(mainDto.MaquinaDto.ReferenciaChao);
        garraManager.update(inputGame);
        maquinaManager.update(inputGame);
    }

    public void fixedUpdate(MainGameDto mainDto)
    {
        garraManager.fixedUpdate(mainDto.GarraDto);
        maquinaManager.fixedUpdate();
    }

    public void onBeginDrag(PointerEventData eventData, MainGameDto mainDto)
    {
        Vector3 posicaoToque = eventData.pointerCurrentRaycast.worldPosition;
        if (inputGame.aconteceuDragNaAreaInferior(posicaoToque, mainDto.MaquinaDto.ReferenciaChao))
        {
            maquinaManager.beginDragPowerUp(posicaoToque);
        }
    }

    public void onEndDrag(PointerEventData eventData)
    {
        maquinaManager.onEndDragPowerUp();
    }

    public void onDrag(PointerEventData eventData)
    {
        Vector3 posicaoToque = eventData.pointerCurrentRaycast.worldPosition;
        maquinaManager.onDragPowerUp(posicaoToque);
    }
}
