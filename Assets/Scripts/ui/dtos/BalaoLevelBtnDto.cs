using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class BalaoLevelBtnDto 
{
    [SerializeField] private Button btnLevel;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject goExclamacao;

    public Button BtnLevel { get { return btnLevel; } }
    public Animator Animator { get { return animator; } }
    public GameObject GoExclamacao { get { return goExclamacao; } }
}
