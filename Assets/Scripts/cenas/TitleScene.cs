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
        ContextoEstaticoUtils.configMainMono(this);

        genero = PlayerPrefsGarra.getGarraMachoOrFemea();
        //Debug.Log("Genero " + genero.ToString());
        garraTitle = new GarraTitle(genero, mainTitleDto.Animator);
        somManager = new SomManagerTitle(mainTitleDto.AudioTitleDto);
        PrefabLoading prefabLoading = mainTitleDto.GoLoading.GetComponent<PrefabLoading>();
        prefabLoading.iniciarLoading(somManager, mainTitleDto.GosDesligar);

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
        somManager.playSomGarraAsSecundario();
        somManager.playSonsBumpsDeTexto();
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
        somManager.playSomStart();
        somManager.stopSomPrincipal();      
        ContextoEstaticoUtils.loading.irParaMapScene();        
    }
}
