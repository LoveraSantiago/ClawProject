using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateMainGameManagers 
{
    private GarraManager garraManager;
    private MaquinaManager maquinaManager;
    private PowerUpManager pupManager;
    private InputGame inputGame;

    public UpdateMainGameManagers(
        GarraManager garraManager, MaquinaManager maquinaManager, PowerUpManager pupManager, InputGame inputGame)
    {
        this.garraManager = garraManager;
        this.inputGame = inputGame;
        this.maquinaManager = maquinaManager;
        this.pupManager = pupManager;
    }

    public void update(MainGameDto mainDto)
    {
        inputGame.update(mainDto.MaquinaDto.ReferenciaChao);
        garraManager.update(mainDto.GarraDto, inputGame);
        maquinaManager.update(mainDto.MaquinaDto, inputGame);
        pupManager.update();
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

    public void onEndDrag(PointerEventData eventData, MainGameDto mainDto)
    {
        maquinaManager.onEndDragPowerUp(mainDto.MaquinaDto);
    }

    public void onDrag(PointerEventData eventData, MainGameDto mainDto)
    {
        Vector3 posicaoToque = eventData.pointerCurrentRaycast.worldPosition;
        maquinaManager.onDragPowerUp(posicaoToque, mainDto.MaquinaDto);
    }
}
