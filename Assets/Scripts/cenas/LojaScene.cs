using UnityEngine;

#pragma warning disable 0649
public class LojaScene : MonoBehaviour
{
    [SerializeField] private MainLojaDto mainLojaDto;   

    // Start is called before the first frame update
    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        PrefabLoading prefabLoading = mainLojaDto.PrefabLoading.GetComponent<PrefabLoading>();
        SomManagerLoja somManager = new SomManagerLoja(mainLojaDto.AudioLojaDto);
        Loading loading = prefabLoading.getLoading(somManager, mainLojaDto.GosDesligar);
        loading.fecharModal();
        configurarBotoes(loading);
    }    

    private void configurarBotoes(Loading loading)
    {
        mainLojaDto.BtnVoltar.onClick.AddListener(() => loading.irParaMapScene());

        mainLojaDto.LblQtdFichasOuro.text   = PlayerPrefsFichas.getQtdFichas(Ficha.OURO).ToString();
        mainLojaDto.LblQtdFichasPrata.text  = PlayerPrefsFichas.getQtdFichas(Ficha.PRATA).ToString();
        mainLojaDto.LblQtdFichasBronze.text = PlayerPrefsFichas.getQtdFichas(Ficha.BRONZE).ToString();

        mainLojaDto.BtnOuro.onClick.AddListener(()=> {
            PlayerPrefsFichas.comprarFicha(Ficha.OURO, 1);
            mainLojaDto.LblQtdFichasOuro.text = PlayerPrefsFichas.getQtdFichas(Ficha.OURO).ToString();
        });

        mainLojaDto.BtnPrata.onClick.AddListener(() => {
            PlayerPrefsFichas.comprarFicha(Ficha.PRATA, 1);
            mainLojaDto.LblQtdFichasPrata.text = PlayerPrefsFichas.getQtdFichas(Ficha.PRATA).ToString();
        });

        mainLojaDto.BtnBronze.onClick.AddListener(() => {
            PlayerPrefsFichas.comprarFicha(Ficha.BRONZE, 1);
            mainLojaDto.LblQtdFichasBronze.text = PlayerPrefsFichas.getQtdFichas(Ficha.BRONZE).ToString();
        });

        mainLojaDto.BtnAssinatura.onClick.AddListener(() =>
        {
            PlayerPrefsFichas.comprarFicha(Ficha.OURO, 10);
            mainLojaDto.LblQtdFichasOuro.text = PlayerPrefsFichas.getQtdFichas(Ficha.OURO).ToString();

            PlayerPrefsFichas.comprarFicha(Ficha.PRATA, 20);
            mainLojaDto.LblQtdFichasPrata.text = PlayerPrefsFichas.getQtdFichas(Ficha.PRATA).ToString();

            PlayerPrefsFichas.comprarFicha(Ficha.BRONZE, 30);
            mainLojaDto.LblQtdFichasBronze.text = PlayerPrefsFichas.getQtdFichas(Ficha.BRONZE).ToString();
        });
    }
}
