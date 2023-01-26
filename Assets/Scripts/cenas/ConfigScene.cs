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
        Debug.Log("Escolha da garra " + escolhaGarra);
        if (escolhaGarra == 0)
        {
            mainConfigDto.ToggleRandom.isOn = true;
        }
        else if (escolhaGarra == 1)
        {
            mainConfigDto.ToggleMacho.isOn = true;
        }
        else if (escolhaGarra == 2)
        {
            mainConfigDto.ToggleFemea.isOn = true;
        }

        mainConfigDto.ToggleFemea.onValueChanged.AddListener((ativo) =>
        {
            if (ativo)
            {
                somManager.playSomClique();
                PlayerPrefsGarra.saveEscolhaGarraFemea();
            }
        });

        mainConfigDto.ToggleMacho.onValueChanged.AddListener((ativo) =>
        {
            if (ativo)
            {
                somManager.playSomClique();
                PlayerPrefsGarra.saveEscolhaGarraMacho();
            }
        });

        mainConfigDto.ToggleRandom.onValueChanged.AddListener((ativo) =>
        {
            if (ativo)
            {
                somManager.playSomClique();
                PlayerPrefsGarra.saveEscolhaGarraRandom();
            }
        });
    }
}
