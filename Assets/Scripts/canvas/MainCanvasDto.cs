using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainCanvasDto 
{
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnBotton;

    public Button BtnBack { get { return btnBack; } }
    public Button BtnBottom { get { return btnBotton; } }

     
}
