using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class TimerFichaDto 
{
    [SerializeField] private Sprite sprMoeda;//REMOVER
    [Space(5)]
    [SerializeField] private Image imgMoeda;
    [SerializeField] private Button btnMais;
    [SerializeField] private TextMeshProUGUI lblQdtFichas;

    public Sprite SprMoeda { get { return sprMoeda; } }
    public Image ImgMoeda { get { return imgMoeda; } }
    public Button BtnMais { get { return btnMais; } }

    public TextMeshProUGUI LblQdtFichas { get { return lblQdtFichas; } }
}
