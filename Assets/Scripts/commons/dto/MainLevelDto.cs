using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainLevelDto 
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
    [SerializeField] private LevelsScrollDto levelsScrollDto;
    [Space(5)]
    [SerializeField] private Image imageMaquinaGiratoria;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;

    public Button BtnBack { get { return btnBack; } }
    public ScrollRect ScrollRect { get { return scrollRect; } }
    public LevelsScrollDto LevelsScrollDto { get { return levelsScrollDto; } }
    public Image ImageMaquinaGiratoria { get { return imageMaquinaGiratoria; } }
    public GameObject PrefabMateriais { get { return prefabMateriais; } }
}
