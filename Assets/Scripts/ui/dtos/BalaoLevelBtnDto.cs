using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class BalaoLevelBtnDto 
{
    [SerializeField] private Button btnLevel;
    [SerializeField] private Animator animator;
    [Space(3)]
    [SerializeField] private GameObject goExclamacao;
    [Space(3)]
    [SerializeField] private Image[] imgsEstrelas = new Image[3];

    public Button BtnLevel { get { return btnLevel; } }
    public Animator Animator { get { return animator; } }
    public GameObject GoExclamacao { get { return goExclamacao; } }
    public Image[] ImgsEstrelas { get { return imgsEstrelas; } }
}
