using UnityEngine;

#pragma warning disable 0649
public class LojaScene : MonoBehaviour
{
    [SerializeField] private MainLojaDto mainLojaDto;
    private AllTimersFichas allTimersFichas;

    // Start is called before the first frame update
    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        PrefabLoading prefabLoading = mainLojaDto.PrefabLoading.GetComponent<PrefabLoading>();
        SomManagerLoja somManager = new SomManagerLoja(mainLojaDto.AudioLojaDto);
        prefabLoading.iniciarLoading(somManager, mainLojaDto.GosDesligar);
        ContextoEstaticoUtils.loading.fecharModal();
        configurarBotoes(somManager);

        allTimersFichas = new AllTimersFichas(mainLojaDto.TimerFichaDto, somManager);
        somManager.playSomBackground();
    }

    private void Update()
    {
        allTimersFichas.update();
    }

    private void configurarBotoes(SomManagerLoja somManager)
    {
        mainLojaDto.BtnVoltar.onClick.AddListener(() => {
                somManager.playSomCliqueVoltar();
                ContextoEstaticoUtils.loading.irParaMapScene();
            });

        mainLojaDto.BtnOuro.onClick.AddListener(()=> {
            bool result = allTimersFichas.ganharFichasDeOuro(2);
            if (result)
            {
                somManager.playSomClique();
            }
        });

        mainLojaDto.BtnPrata.onClick.AddListener(() => {
            bool result = allTimersFichas.ganharFichasDePrata(4);
            if (result)
            {
                somManager.playSomClique();            
            }
        });

        mainLojaDto.BtnBronze.onClick.AddListener(() => {
            bool result = allTimersFichas.ganharFichasDeBronze(6);
            if (result)
            {
                somManager.playSomClique();
            }
        });

        mainLojaDto.BtnAssinatura.onClick.AddListener(() =>
        {
            bool result = true;
            result = result && allTimersFichas.ganharFichasDeOuro(1);
            result = result && allTimersFichas.ganharFichasDePrata(2);
            result = result && allTimersFichas.ganharFichasDeBronze(3);
            if (result)
            {
                somManager.playSomClique();            
            }
        });
    }
}
