using UnityEngine;

public class ConfigScene : MonoBehaviour
{
    [SerializeField] private MainConfigDto mainConfigDto;  

    // Start is called before the first frame update
    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        PrefabLoading prefabLoading = mainConfigDto.PrefabLoading.GetComponent<PrefabLoading>();
        SomManagerConfig somManager = new SomManagerConfig(mainConfigDto.AudioConfigDto);
        Loading loading = prefabLoading.getLoading(somManager);
        loading.fecharModal();

        configurarToogles();
        mainConfigDto.BtnBack.onClick.AddListener(() => loading.irParaMapScene());
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
