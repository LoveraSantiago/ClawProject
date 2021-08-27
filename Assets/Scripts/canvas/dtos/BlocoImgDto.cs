using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class BlocoImgDto
{
    [SerializeField] private Animator animatorBlocoImg;
    [SerializeField] private Button btnEsquerda;
    [SerializeField] private Button btnDireita;
    [SerializeField] private Image imgPowerUp;

    public Animator AnimatorBlocoImg { get { return animatorBlocoImg; } }
    public Button BtnEsquerda { get { return btnEsquerda; } }
    public Button BtnDireita { get { return btnDireita; } }
    public Image ImgPowerUp { get { return imgPowerUp; } }
}