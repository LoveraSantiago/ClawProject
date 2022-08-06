using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class LevelScene : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]    
    [SerializeField] private LevelsScrollDto levelsScrollDto;
         
    private LevelsScroll levelsScroll;

    void Start()
    {
        Utils.configMainMono(this);
        levelsScroll = new LevelsScroll(levelsScrollDto);
        scrollRect.onValueChanged.AddListener((pos) => levelsScroll.movimentado(pos, levelsScrollDto));            
    }
    
    
}
