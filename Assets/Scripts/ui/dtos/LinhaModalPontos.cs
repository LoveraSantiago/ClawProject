using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class LinhaModalPontos 
{
    [SerializeField] private Text lblText1;
    [SerializeField] private Image imgLinha;
    [SerializeField] private Text lblText2;
    [SerializeField] private GameObject goLinha;

    public Text LblText1 { get { return lblText1; } }
    public Image ImgLinha { get { return imgLinha; } }
    public Text LblText2 { get { return lblText2; } }
    public GameObject GoLinha { get { return goLinha; } }
}
