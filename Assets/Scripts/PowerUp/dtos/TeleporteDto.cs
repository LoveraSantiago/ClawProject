using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TeleporteDto 
{
    [SerializeField] private float velocidade;
    [SerializeField] private float delayFinal;
    [SerializeField] private Material matTeleporte;    

    public float Velocidade { get { return velocidade; } }
    public float DelayFinal { get { return delayFinal; } }
    public Material MatTeleporte { get { return matTeleporte; } }    
}
