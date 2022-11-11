using UnityEngine;

#pragma warning disable 0649
public class TitleScene : MonoBehaviour
{
    [SerializeField] private MainTitleDto mainTitleDto;   

    private Genero genero;
    private InputGame inputGame;

    private GarraTitle garraTitle;
    private SomManagerTitle somManager;

    private void Start()
    {
        int indiceGenero = MathUtils.escolherDeZeroAteLimite(2);
        genero = GeneroUtils.getGeneroDoIndice(indiceGenero);
        Debug.Log("Genero " + indiceGenero + " " + genero.ToString());
        garraTitle = new GarraTitle(genero, mainTitleDto.Animator);
        somManager = new SomManagerTitle(mainTitleDto.AudioTitleDto);

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
        somManager.playSomBotaoClicado();
        CenaUtils.irParaCenaMap(1);
    }
}
