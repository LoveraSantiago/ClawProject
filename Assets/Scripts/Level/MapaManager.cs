using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelObjetivo;


    public void showTarget()
    {        
        levelObjetivo.SetActive(true);
    }
    
}
