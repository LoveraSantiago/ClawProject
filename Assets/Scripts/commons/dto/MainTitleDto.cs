using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainTitleDto 
{
    [SerializeField] private Animator animator;
    [Space(5)]
    [SerializeField] private Material materialMacho;
    [SerializeField] private Material materialFemea;
    [SerializeField] private Image imgBackground;
    [Space(5)]
    [SerializeField] private Sprite btnVerde;
    [SerializeField] private Sprite btnRosa;
    [SerializeField] private Image imgBtnPlay;
    [Space(5)]
    [SerializeField] private AudioTitleDto audioTitleDto;
    [Space(5)]
    [SerializeField] private GameObject goLoading;
    [SerializeField] private GameObject[] gosDesligar;

    public Animator Animator { get { return animator; } }
    public Material MaterialMacho { get { return materialMacho; } }
    public Material MaterialFemea { get { return materialFemea; } }
    public Image ImgBackground { get { return imgBackground; } }

    public Sprite BtnVerde { get { return btnVerde; } }
    public Sprite BtnRosa { get { return btnRosa; } }
    public Image ImgBtnPlay { get { return imgBtnPlay; } }

    public AudioTitleDto AudioTitleDto { get { return audioTitleDto; } }
    public GameObject GoLoading { get { return goLoading; } }
    public GameObject[] GosDesligar { get { return gosDesligar; } }
}
