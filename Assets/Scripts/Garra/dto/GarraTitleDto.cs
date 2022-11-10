using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class GarraTitleDto 
{
    [SerializeField] private Sprite sprGarraMacho;
    [SerializeField] private Sprite sprGarraFemea;
    [SerializeField] private Image imgGarra;

    public Sprite SprGarraMacho { get { return sprGarraMacho; } }
    public Sprite SprGarraFemea { get { return sprGarraFemea; } }
    public Image ImgGarra { get { return imgGarra; } }
}
