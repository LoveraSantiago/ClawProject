using UnityEngine;

public class CameraManager : AcaoBotaoPUpVazio.ConsumidorEvento
{
    private CameraDto cameraDto;

    public CameraManager(CameraDto cameraDto)
    {
        CameraShake.configurar(cameraDto);
        this.cameraDto = cameraDto;
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        cameraDto.VirtualCam2.Priority = 2;   
    }

    public static void forceAspectCameraAsRatio()
    {
        Camera.main.aspect = Utils.RATIO_SCREEN;
    }
}
