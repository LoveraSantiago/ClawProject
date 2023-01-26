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

        configurarSliderVolume(somManager);
        
        mainConfigDto.BtnBack.onClick.AddListener(() => {
                somManager.playSomCliqueVoltar();
                ContextoEstaticoUtils.loading.irParaMapScene();
            });
        somManager.playSomBackground();
    }       
    
    private void configurarSliderVolume(SomManagerConfig somManager)
    {
        mainConfigDto.SliderVolume.value = PlayerPrefsVolume.recuperarVolume();

        mainConfigDto.SliderVolume.onValueChanged.AddListener((valor)=> {
            PlayerPrefsVolume.salvarVolume(valor);
            somManager.trocarVolume(valor);
        });
    }
}
