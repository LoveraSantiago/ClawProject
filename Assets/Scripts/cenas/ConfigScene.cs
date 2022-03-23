using UnityEngine;
using UnityEngine.UI;

public class ConfigScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private Toggle toggleMacho;
    [SerializeField] private Toggle toggleFemea;
    [SerializeField] private Toggle toggleRandom;

    // Start is called before the first frame update
    void Start()
    {
        int escolhaGarra = PlayerPrefsGarra.getEscolhaGarra();
        if(escolhaGarra == 0)
        {   
            toggleRandom.Select();            
        }
        else if(escolhaGarra == 1)
        {
            toggleMacho.Select();
        }
        else if(escolhaGarra == 2)
        {
            toggleFemea.Select();
        }

        toggleFemea.onValueChanged.AddListener((ativo) =>
        {   
           PlayerPrefsGarra.saveEscolhaGarraFemea();
        });

        toggleMacho.onValueChanged.AddListener((ativo) =>
        {
            PlayerPrefsGarra.saveEscolhaGarraMacho();
        });

        toggleRandom.onValueChanged.AddListener((ativo) =>
        {
            PlayerPrefsGarra.saveEscolhaGarraRandom();
        });

        btnBack.onClick.AddListener(() => CenaUtils.irParaCenaMap());
    }   
}
