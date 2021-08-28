using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaScene : MonoBehaviour
{

    void OnEnable()
    {
        //for�ando escala Y pra ficar dentro da safe area
        float escalaY = Screen.safeArea.height / Screen.height;
        float escalaX = Screen.safeArea.width / Screen.width;
        transform.localScale = new Vector3(escalaX, escalaY, transform.localScale.z);
    }

    
    void Start()
    {
        Camera.main.aspect = Utils.RATIO_SCREEN;
    }
}
