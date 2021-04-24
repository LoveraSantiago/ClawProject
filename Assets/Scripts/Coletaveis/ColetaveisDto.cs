using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{
    [SerializeField] private GameObject sensorDeColetado;
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject pontosModal;
    [Space(5)]
    [SerializeField] private List<Sprite> characters = new List<Sprite>();
    [Space(5)]
    [SerializeField] private TuboDto tuboDto;    
    [Space(5)]    
    [SerializeField] private BoardDto boardDto;

    public GameObject SensorDeColetado { get { return sensorDeColetado; } }    
    public GameObject Tile { get { return tile; } }
    public GameObject PontosModal { get { return pontosModal; } }

    public List<Sprite> Characters { get { return characters; } }

    public TuboDto TuboDto { get { return tuboDto; } }    

    public BoardDto BoardDto { get { return boardDto; } }
}
