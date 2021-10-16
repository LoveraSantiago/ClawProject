using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class ColetaveisScene : MonoBehaviour, 
                               IPointerClickHandler     
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private BlocoImgColetaveisDto blocoImgDto;
    [SerializeField] private BlocoImgDetalheColetavelDto blocoImgDetalheDto;
    [Space(5)]
    [SerializeField] private GameObject prefabColetaveisDto;

    private BlocoImgColetaveis blocoImg;

    // Start is called before the first frame update
    void Start()
    {
        ColetavelHelper.configurar();

        PrefabDeSpriteDto prefabSpritesDto = prefabColetaveisDto.GetComponent<PrefabDeSpriteDto>();
        Dictionary<string, Sprite> dicionarioDeSprites = prefabSpritesDto.getDicionarioDeSprites();
        blocoImg = new BlocoImgColetaveis(dicionarioDeSprites, blocoImgDto);

        configBtnBack(btnBack);        
    }

    // Update is called once per frame
    void Update()
    {
                    
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        blocoImg.clicouNaImg(eventData.pointerEnter);
    }

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }
}
