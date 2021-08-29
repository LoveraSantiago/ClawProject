using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649
public class PupScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnPratica;
    [Space(5)]
    [SerializeField] private BlocoImgDto blocoImgDto;    
    [SerializeField] private GameObject prefabPowerUpDto;
    [Space(5)]
    [SerializeField] private AllLabelsDto labelsDto;
    [Space(5)]
    [SerializeField] private GameObject prefabBottomBar;    

    // Start is called before the first frame update
    void Start()
    {
        PowerUpEntidade.configurarDicionarioDeSpritesPup(prefabPowerUpDto);

        BlocoImg blocoImg           = new BlocoImg(blocoImgDto, this);
        AllLabels allLables         = new AllLabels(labelsDto);
        ScrollBottomBarPupScene scBottomBar = new ScrollBottomBarPupScene(prefabBottomBar, this);

        configBtnBack(btnBack);
        configBtnPratica(btnPratica, blocoImg);

        new AcaoBlocoImgPUpAtual()
            .configurarProdutor(blocoImg)
            .adicionarConsumidor(allLables);

        new AcaoBBarPupEscolhido<int>()
            .configurarProdutor(scBottomBar)
            .adicionarConsumidor(blocoImg);

        blocoImg.startLaizy();
    }   

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }

    private void configBtnPratica(Button btnPratica, BlocoImg blocoImg)
    {
        btnPratica.onClick.AddListener(() => {
            PlayerPrefsUtils.salvarLevel(LevelFlowManager.LEVEL.PUP);
            PlayerPrefsUtils.salvarIndicePup(blocoImg.getIndicePupAtual());
            SceneManager.LoadScene("MainGameScene");
        });
    }
}
