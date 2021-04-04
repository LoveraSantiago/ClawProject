using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

#pragma warning disable 0649
[System.Serializable]
public class ColetaveisDto 
{    
    [SerializeField] private Text scoreTextField;
    [Space(5)]    
    public BoardDto boardDto;    
    
    public Text ScoreTextField { get { return scoreTextField; } }
    public BoardDto BoardDto { get { return boardDto; } }
}
