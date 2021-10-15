using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#pragma warning disable 0649
public class ColetaveisScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private Image[] grupoColetaveis = new Image[7]; 
    [Space(5)]
    [SerializeField] private GameObject prefabColetaveisDto;

    private ColetavelEntidade.FAMILIA[] familias = { ColetavelEntidade.FAMILIA.FRUTAS,
                                                     ColetavelEntidade.FAMILIA.FAKE};

    // Start is called before the first frame update
    void Start()
    {
        configBtnBack(btnBack);
        PrefabDeSpriteDto prefabSpritesDto = prefabColetaveisDto.GetComponent<PrefabDeSpriteDto>();
        Dictionary<string, Sprite> dicionarioDeSprites = prefabSpritesDto.getDicionarioDeSprites();
        ColetavelHelper.configurar();
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveis = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familias[0]);
        for(int contador = 0; contador < coletaveis.Count; contador++)
        {
            grupoColetaveis[contador].sprite = dicionarioDeSprites[coletaveis[contador].nomeSprite];
        }
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
