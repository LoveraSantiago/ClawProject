using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private GameObject sensorDeColetado;
    [Space(5)]
    [SerializeField] private GameObject parentColetavelTubo;
    [SerializeField] private GameObject[] coletaveisParaTubo = new GameObject[3];
    [Space(5)]    
    public BoardDto boardDto;

    public GameObject SensorDeColetado { get { return sensorDeColetado; } }
    public GameObject ParentColetavelTubo { get { return parentColetavelTubo; } }
    public GameObject[] ColetaveisParaTubo { get { return coletaveisParaTubo; } }

    public BoardDto BoardDto { get { return boardDto; } }
}
