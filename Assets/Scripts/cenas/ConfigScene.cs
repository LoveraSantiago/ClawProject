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

        configurarToogles();
        mainConfigDto.BtnBack.onClick.AddListener(() => ContextoEstaticoUtils.loading.irParaMapScene());
        somManager.playSomBackground();
    }   

    private void configurarToogles()
    {
        int escolhaGarra = PlayerPrefsGarra.getEscolhaGarra();
        if (escolhaGarra == 0)
        {
            mainConfigDto.ToggleRandom.Select();
        }
        else if (escolhaGarra == 1)
        {
            mainConfigDto.ToggleMacho.Select();
        }
        else if (escolhaGarra == 2)
        {
            mainConfigDto.ToggleFemea.Select();
        }

        mainConfigDto.ToggleFemea.onValueChanged.AddListener((ativo) =>
        {
            PlayerPrefsGarra.saveEscolhaGarraFemea();
        });

        mainConfigDto.ToggleMacho.onValueChanged.AddListener((ativo) =>
        {
            PlayerPrefsGarra.saveEscolhaGarraMacho();
        });

        mainConfigDto.ToggleRandom.onValueChanged.AddListener((ativo) =>
        {
            PlayerPrefsGarra.saveEscolhaGarraRandom();
        });
    }
}
