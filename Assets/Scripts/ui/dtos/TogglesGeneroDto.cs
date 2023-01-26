using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class TogglesGeneroDto 
{
    [SerializeField] private Toggle toggleMacho;
    [SerializeField] private Toggle toggleFemea;
    [SerializeField] private Toggle toggleRandom;

    public Toggle ToggleMacho { get { return toggleMacho; } }
    public Toggle ToggleFemea { get { return toggleFemea; } }
    public Toggle ToggleRandom { get { return toggleRandom; } }
}
