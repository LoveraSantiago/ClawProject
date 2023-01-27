using UnityEngine;

public class TogglesGenero
{
    private TogglesGeneroDto togglesGeneroDto;

    public TogglesGenero(TogglesGeneroDto togglesGeneroDto)
    {
        this.togglesGeneroDto = togglesGeneroDto;
    }

    public void configurarToggles(SomManagerConfig somManager)
    {
        togglesGeneroDto.ToggleFemea.onValueChanged.AddListener((ativo) =>
        {
            if (ativo)
            {
                somManager.playSomClique();
                PlayerPrefsGarra.saveEscolhaGarraFemea();
            }
        });

        togglesGeneroDto.ToggleMacho.onValueChanged.AddListener((ativo) =>
        {
            if (ativo)
            {
                somManager.playSomClique();
                PlayerPrefsGarra.saveEscolhaGarraMacho();
            }
        });

        togglesGeneroDto.ToggleRandom.onValueChanged.AddListener((ativo) =>
        {
            if (ativo)
            {
                somManager.playSomClique();
                PlayerPrefsGarra.saveEscolhaGarraRandom();
            }
        });
    }

    public void recuperarEstado()
    {
        int escolhaGarra = PlayerPrefsGarra.getEscolhaGarra();
        //Debug.Log("Escolha da garra " + escolhaGarra);
        if (escolhaGarra == 0)
        {
            togglesGeneroDto.ToggleRandom.isOn = true;
        }
        else if (escolhaGarra == 1)
        {
            togglesGeneroDto.ToggleMacho.isOn = true;
        }
        else if (escolhaGarra == 2)
        {
            togglesGeneroDto.ToggleFemea.isOn = true;
        }
    }  
}
