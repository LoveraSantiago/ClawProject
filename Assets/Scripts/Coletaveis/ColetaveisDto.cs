using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private GameObject sensorDeColetado;
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject pontosModal;
    [Space(5)]
    [SerializeField] private TuboDto tuboDto;    
    [Space(5)]    
    public BoardDto boardDto;

    public GameObject SensorDeColetado { get { return sensorDeColetado; } }    
    public GameObject Tile { get { return tile; } }
    public GameObject PontosModal { get { return pontosModal; } }

    public TuboDto TuboDto { get { return tuboDto; } }    

    public BoardDto BoardDto { get { return boardDto; } }
}
