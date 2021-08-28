using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649
public class PupScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
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

        configButtonBack(btnBack);

        BlocoImg blocoImg           = new BlocoImg(blocoImgDto, this);
        AllLabels allLables         = new AllLabels(labelsDto);
        ScrollBottomBarPupScene scBottomBar = new ScrollBottomBarPupScene(prefabBottomBar, this);

        new AcaoBlocoImgPUpAtual()
            .configurarProdutor(blocoImg)
            .adicionarConsumidor(allLables);

        new AcaoPupIndice()
            .configurarProdutor(scBottomBar)
            .adicionarConsumidor(blocoImg);

        blocoImg.startLaizy();
    }   

    private void configButtonBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }
}
