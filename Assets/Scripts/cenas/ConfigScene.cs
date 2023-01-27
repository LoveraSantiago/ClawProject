using UnityEngine;

#pragma warning disable 0649
public class ConfigScene : MonoBehaviour
{
    [SerializeField] private MainConfigDto mainConfigDto;  

    // Start is called before the first frame update
    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        PrefabLoading prefabLoading = mainConfigDto.PrefabLoading.GetComponent<PrefabLoading>();

        SomManagerConfig somManager = new SomManagerConfig(mainConfigDto.AudioConfigDto);
        prefabLoading.iniciarLoading(somManager, mainConfigDto.GosDesligar);
        ContextoEstaticoUtils.loading.fecharModal();

        TogglesGenero togglesGenero = new TogglesGenero(mainConfigDto.TogglesGeneroDto);
        togglesGenero.configurarToggles(somManager);
        togglesGenero.recuperarEstado();

        configurarBotaoReset(somManager);
        configurarSliderVolume(somManager);
        configurarBotaoVoltar(somManager);
        configurarBotaoCreditos(somManager);
        configurarBotaoSairCreditos(somManager);
        somManager.playSomBackground();
    }       

    private void configurarBotaoVoltar(SomManagerConfig somManager)
    {
        mainConfigDto.BtnBack.onClick.AddListener(() => {
                somManager.playSomCliqueVoltar();
                ContextoEstaticoUtils.loading.irParaMapScene();
            });
    }
    
    private void configurarSliderVolume(SomManagerConfig somManager)
    {
        mainConfigDto.SliderVolume.value = PlayerPrefsVolume.recuperarVolume();

        mainConfigDto.SliderVolume.onValueChanged.AddListener((valor)=> {
            PlayerPrefsVolume.salvarVolume(valor);
            somManager.trocarVolume(valor);
        });
    }

    private void configurarBotaoReset(SomManagerConfig somManager)
    {
        mainConfigDto.BtnReset.onClick.AddListener(() => 
        {
            somManager.playSomClique();
            PlayerPrefs.DeleteAll();
        });
    }

    private void configurarBotaoCreditos(SomManagerConfig somManager)
    {
        mainConfigDto.BtnCreditos.onClick.AddListener(() =>
        {
            somManager.playSomClique();
            mainConfigDto.Animator.Play("creditos-abrir");
        });
    }

    private void configurarBotaoSairCreditos(SomManagerConfig somManager)
    {
        mainConfigDto.BtnFecharCreditos.onClick.AddListener(() =>
        {
            somManager.playSomCliqueVoltar();
            mainConfigDto.Animator.Play("creditos-fechar");
        });
    }
}
