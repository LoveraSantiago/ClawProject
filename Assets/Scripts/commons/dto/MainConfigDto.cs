using UnityEngine;
using UnityEngine.UI;


#pragma warning disable 0649
[System.Serializable]
public class MainConfigDto 
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private Toggle toggleMacho;
    [SerializeField] private Toggle toggleFemea;
    [SerializeField] private Toggle toggleRandom;

    public Button BtnBack { get { return btnBack; } }
    public Toggle ToggleMacho { get { return toggleMacho; } }
    public Toggle ToggleFemea { get { return toggleFemea; } }
    public Toggle ToggleRandom { get { return toggleRandom; } }
}
