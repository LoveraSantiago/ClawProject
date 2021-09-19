using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PrefabScrollBottomBarDto : MonoBehaviour
{
    [SerializeField] private BotaoBottomBarDto btnBottomBarDto;
    [SerializeField] private ScrollBottomBarDto scrollBottomBarDto;

    public BotaoBottomBarDto BtnBottomBarDto { get { return btnBottomBarDto; } }
    public ScrollBottomBarDto ScrollBottomBarDto { get { return scrollBottomBarDto; } }
}
