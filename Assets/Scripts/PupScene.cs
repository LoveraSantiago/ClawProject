using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] private BottomBarDto bottomBarDto;  

    // Start is called before the first frame update
    void Start()
    {
        PowerUpEntidade.configurarDicionarioDeSpritesPup(prefabPowerUpDto);

        configButtonBack(btnBack);
        BlocoImg blocoImg = new BlocoImg(blocoImgDto, this);
        AllLabels allLables = new AllLabels(labelsDto);
        new BottomBar(bottomBarDto, this);

        new AcaoPUpEntidade()
            .configurarProdutor(blocoImg)
            .adicionarConsumidor(allLables);

        blocoImg.startLaizy();
    }   

    private void configButtonBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }
}
