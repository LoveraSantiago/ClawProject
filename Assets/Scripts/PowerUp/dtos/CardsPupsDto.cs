using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class CardsPupsDto
{
    [SerializeField] private Button btn;

    public Button Btn { get { return btn; } }
}
