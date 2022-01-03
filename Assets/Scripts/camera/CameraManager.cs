using UnityEngine;

public class CameraManager : AcaoBotaoPUpVazio.ConsumidorEvento,
                             AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento,
                             AcaoCacaNiquel.ConsumidorEvento
{
    private static readonly float RATIO_SCREEN = 0.5625f;

    private CameraDto cameraDto;

    public CameraManager(CameraDto cameraDto)
    {
        CameraShake.configurar(cameraDto);
        this.cameraDto = cameraDto;
        cameraDto.VirtualCam1.Priority = 1;
        cameraDto.VirtualCam2.Priority = 0;
        cameraDto.VirtualCam3.Priority = 0;
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {     
        if(cameraDto.VirtualCam2.Priority == 0)
        {
            cameraDto.VirtualCam2.Priority += 2;   
        }
    }

    void AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {        
        if(cameraDto.VirtualCam2.Priority == 2)
        {
            cameraDto.VirtualCam2.Priority -= 2;
        }
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelResultadoDto evento)
    {
        if (evento.isInicio)
        {
            cameraDto.VirtualCam3.Priority += 2;
        }
        else if (evento.isFinalizado)
        {
            cameraDto.VirtualCam3.Priority -= 2;
        }
    }

    public static void forceLocalEscala(Transform transform)
    {
        //forcando escala Y pra ficar dentro da safe area
        float escalaY = Screen.safeArea.height / Screen.height;
        float escalaX = Screen.safeArea.width / Screen.width;
        transform.localScale = new Vector3(escalaX, escalaY, transform.localScale.z);
    }

    public static void forceAspectCameraAsRatio()
    {
        Camera.main.aspect = RATIO_SCREEN;
    }

}
