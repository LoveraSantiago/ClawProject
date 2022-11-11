using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class TitleScene : MonoBehaviour
{
    [SerializeField] private MainTitleDto mainTitleDto;
    [Space(5)]
    [SerializeField] private Material materialMacho;
    [SerializeField] private Material materialFemea;
    [SerializeField] private Image imgBackground;
    [Space(5)]
    [SerializeField] private Sprite btnVerde;
    [SerializeField] private Sprite btnRosa;
    [SerializeField] private Image imgBtnPlay;  

    private Genero genero;
    private InputGame inputGame;
    private GarraTitle garraTitle;

    private void Start()
    {   
        genero = GeneroUtils.getGeneroDoIndice(MathUtils.escolherDeZeroAteLimite(2));
        garraTitle = new GarraTitle(genero, mainTitleDto.Animator);

        if(GeneroUtils.isGeneroMacho(genero))
        {            
            imgBackground.material = materialMacho;
            imgBtnPlay.sprite = btnVerde;
        }
        else
        {        
            
            imgBackground.material = materialFemea;
            imgBtnPlay.sprite = btnRosa;
        }
        inputGame = new InputGameImpl();        
    }

    private void Update()
    {
        inputGame.update();
        if (inputGame.aconteceuTap())
        {
            garraTitle.playAnimacao();            
        }
    }

    public void irParaMainScene()
    {
        CenaUtils.irParaCenaMap();
    }
}
