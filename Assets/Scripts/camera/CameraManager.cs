using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager 
{
    public CameraManager(CameraDto cameraDto)
    {
        AbstractShake.configurar(cameraDto);
    }

    public static void forceAspectCameraAsRatio()
    {
        Camera.main.aspect = Utils.RATIO_SCREEN;
    }
}
