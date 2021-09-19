using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class BotaoBottomBarDto 
{
    [SerializeField] private Animator animatorBottonBar;
    [SerializeField] private Button btnBottonBar;

    public Animator AnimatorBottonBar { get { return animatorBottonBar; } }
    public Button BtnBottonBar { get { return btnBottonBar; } }
}
