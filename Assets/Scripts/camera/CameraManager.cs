using UnityEngine;

public class CameraManager : AcaoBotaoPowerUpVazio.ConsumidorEvento,
                             AcaoPupFromScrollSelecao.ConsumidorEvento,
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

        //cameraDto.VirtualCam1.m_Lens.OrthographicSize = 5 + ((float)5 * Camera.main.aspect / 2.0f);
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {     
        if(cameraDto.VirtualCam2.Priority == 0)
        {
            cameraDto.VirtualCam2.Priority += 2;   
        }
    }

    void AcaoPupFromScrollSelecao.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {
        if (cameraDto.VirtualCam2.Priority == 2)
        {
            cameraDto.VirtualCam2.Priority -= 2;
        }
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelEventoDto evento)
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
        log("1");
        if (Camera.main.aspect < RATIO_SCREEN)
        {
            //Debug.Log("REDIMENSIONAMENTO DE TELA ATIVADO");
            //Camera.main.orthographicSize = 1440 / Camera.main.aspect;
            //log("2");
            //Camera.main.aspect = RATIO_SCREEN;
        }

        //Debug.Log("DEPOIS w: " + Camera.main.pixelWidth + " h: " + Camera.main.pixelHeight + " ratio: " + Camera.main.aspect);
    }

    private static void log(string incremento)
    {
        int width  = Camera.main.pixelWidth;
        int height = Camera.main.pixelHeight;
        float aspect = Camera.main.aspect;
        int mdc = maiordivisorcomum(width, height);
        int ratioWidth  = width / mdc;
        int ratioHeight = height / mdc;
        Debug.Log(incremento + " w: " + width + " h: " + height + " ratio: " + aspect + " - " + ratioWidth + ":" + ratioHeight + " mdc" + mdc);
    }

    private static int maiordivisorcomum(int width, int height)
    {
        int resultado = 0;
        int menor = (width < height) ? width : height;
        for(int contador = 1; contador < menor; contador++)
        {
            if((width % contador == 0) && (height % contador == 0))
            {
                resultado = contador;
            }
        }
        return resultado;
    }

}
