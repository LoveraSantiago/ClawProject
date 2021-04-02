using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SensoresDto 
{
    [SerializeField] private GameObject sensorDeColetado;

    public GameObject SensorDeColetado { get { return sensorDeColetado;  } }
}
