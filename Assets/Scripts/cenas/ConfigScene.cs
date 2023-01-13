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

        configurarToogles(somManager);
        mainConfigDto.BtnBack.onClick.AddListener(() => {
                somManager.playSomCliqueVoltar();
                ContextoEstaticoUtils.loading.irParaMapScene();
            });
        somManager.playSomBackground();
    }   

    private void configurarToogles(SomManagerConfig somManager)
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
            somManager.playSomClique();
            PlayerPrefsGarra.saveEscolhaGarraFemea();
        });

        mainConfigDto.ToggleMacho.onValueChanged.AddListener((ativo) =>
        {
            somManager.playSomClique();
            PlayerPrefsGarra.saveEscolhaGarraMacho();
        });

        mainConfigDto.ToggleRandom.onValueChanged.AddListener((ativo) =>
        {
            somManager.playSomClique();
            PlayerPrefsGarra.saveEscolhaGarraRandom();
        });
    }
}
