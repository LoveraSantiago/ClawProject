using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{    
    [SerializeField] private Text scoreTextField;
    [Space(5)]    
    public BoardManagerDto boardManagerDto;    
    
    public Text ScoreTextField { get { return scoreTextField; } }
    public BoardManagerDto BoardManagerDto { get { return boardManagerDto; } }
}
