using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class TitleScene : MonoBehaviour
{
    [SerializeField] private Sprite garraMacho;
    [SerializeField] private Sprite garraFemea;
    [SerializeField] private Image imgGarra;
    [Space(5)]
    [SerializeField] private Material materialMacho;
    [SerializeField] private Material materialFemea;
    [SerializeField] private Image imgBackground;
    [Space(5)]
    [SerializeField] private Sprite btnVerde;
    [SerializeField] private Sprite btnRosa;
    [SerializeField] private Image imgBtnPlay;

    

    private void Start()
    {
        int result = UtilsMath.escolherDeZeroAteLimite(2);        
        if(result == 0)
        {
            imgGarra.sprite = garraMacho;
            imgBackground.material = materialMacho;
            imgBtnPlay.sprite = btnVerde;
        }
        else
        {
            imgGarra.sprite = garraFemea;
            imgBackground.material = materialFemea;
            imgBtnPlay.sprite = btnRosa;
        }
    }

    public void irParaMainScene()
    {
        CenaUtils.irParaCenaMap();
    }
}
