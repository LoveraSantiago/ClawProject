using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private BlocoImgColetaveisDto blocoImgDto;    
    [Space(5)]
    [SerializeField] private GameObject prefabColetaveisDto;    

    // Start is called before the first frame update
    void Start()
    {
        ColetavelHelper.configurar();

        PrefabDeSpriteDto prefabSpritesDto = prefabColetaveisDto.GetComponent<PrefabDeSpriteDto>();
        Dictionary<string, Sprite> dicionarioDeSprites = prefabSpritesDto.getDicionarioDeSprites();
        BlocoImgColetaveis blocoImg = new BlocoImgColetaveis(dicionarioDeSprites, blocoImgDto);

        configBtnBack(btnBack);        
    }

    // Update is called once per frame
    void Update()
    {
                    
    }

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }
}
