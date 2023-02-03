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
            somManager.playSomClique();
            allTimersFichas.ganharFichasDeOuro(2);            
        });

        mainLojaDto.BtnPrata.onClick.AddListener(() => {
            somManager.playSomClique();            
            allTimersFichas.ganharFichasDePrata(4);            
        });

        mainLojaDto.BtnBronze.onClick.AddListener(() => {
            somManager.playSomClique();
            allTimersFichas.ganharFichasDeBronze(6);            
        });

        mainLojaDto.BtnAssinatura.onClick.AddListener(() =>
        {
            somManager.playSomClique();            
            allTimersFichas.ganharFichasDeOuro(1);
            allTimersFichas.ganharFichasDePrata(2);
            allTimersFichas.ganharFichasDeBronze(3);
        });
    }
}
