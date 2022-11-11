using UnityEngine;

#pragma warning disable 0649
public class TitleScene : MonoBehaviour
{
    [SerializeField] private MainTitleDto mainTitleDto;   

    private Genero genero;
    private InputGame inputGame;
    private GarraTitle garraTitle;

    private void Start()
    {   
        genero = GeneroUtils.getGeneroDoIndice(MathUtils.escolherDeZeroAteLimite(2));
        garraTitle = new GarraTitle(genero, mainTitleDto.Animator);

        if(GeneroUtils.isGeneroMacho(genero))
        {
            mainTitleDto.ImgBackground.material = mainTitleDto.MaterialMacho;
            mainTitleDto.ImgBtnPlay.sprite = mainTitleDto.BtnVerde;
        }
        else
        {   
            mainTitleDto.ImgBackground.material = mainTitleDto.MaterialFemea;
            mainTitleDto.ImgBtnPlay.sprite = mainTitleDto.BtnRosa;
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
