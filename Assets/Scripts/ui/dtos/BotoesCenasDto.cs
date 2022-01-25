using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class BotoesCenasDto 
{
    [SerializeField] private Button btnCards;
    [SerializeField] private Button btnScore;
    [SerializeField] private Button btnStore;
    [SerializeField] private Button btnPelucia;
    [SerializeField] private Button btnConfig;

    public Button BtnCards { get { return btnCards; } }
    public Button BtnScore { get { return btnScore; } }
    public Button BtnStore { get { return btnStore; } }
    public Button BtnPelucia { get { return btnPelucia; } }
    public Button BtnConfig { get { return btnConfig; } }
}
