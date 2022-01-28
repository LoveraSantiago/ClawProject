using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class TimerFichaDto 
{
    [SerializeField] private Sprite sprMoeda;
    [Space(5)]
    [SerializeField] private Image imgMoeda;
    [SerializeField] private Button btnMais;

    public Sprite SprMoeda { get { return sprMoeda; } }
    public Image ImgMoeda { get { return imgMoeda; } }
    public Button BtnMais { get { return btnMais; } }
}
