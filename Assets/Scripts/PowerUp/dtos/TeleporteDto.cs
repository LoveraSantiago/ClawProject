using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TeleporteDto 
{
    [SerializeField] private float velocidade;
    [SerializeField] private float delayFinal;
    [SerializeField] private Material matTeleporteIn;
    [SerializeField] private Material matTeleporteOut;

    public float Velocidade { get { return velocidade; } }
    public float DelayFinal { get { return delayFinal; } }
    public Material MatTeleporteIn { get { return matTeleporteIn; } }
    public Material MatTeleporteOut { get { return matTeleporteOut; } }
}
