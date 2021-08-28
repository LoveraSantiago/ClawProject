using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager 
{
    public static void forceAspectCameraAsRatio()
    {
        Camera.main.aspect = Utils.RATIO_SCREEN;
    }
}
