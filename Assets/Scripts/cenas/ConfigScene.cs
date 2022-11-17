using UnityEngine;

public class ConfigScene : MonoBehaviour
{
    [SerializeField] private MainConfigDto mainConfigDto;  

    // Start is called before the first frame update
    void Start()
    {
        int escolhaGarra = PlayerPrefsGarra.getEscolhaGarra();
        if(escolhaGarra == 0)
        {
            mainConfigDto.ToggleRandom.Select();            
        }
        else if(escolhaGarra == 1)
        {
            mainConfigDto.ToggleMacho.Select();
        }
        else if(escolhaGarra == 2)
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

        mainConfigDto.BtnBack.onClick.AddListener(() => CenaUtils.irParaCenaMap());
    }   
}
