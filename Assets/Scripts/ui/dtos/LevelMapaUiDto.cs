using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class LevelMapaUiDto
{
    [SerializeField] private Button[] btnLevels = new Button[10];

    public Button[] BtnLevels { get { return btnLevels; } }
}
