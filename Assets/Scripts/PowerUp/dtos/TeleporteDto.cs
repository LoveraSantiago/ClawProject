using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TeleporteDto 
{
    [SerializeField] private float velocidadeTeleporte;
    [SerializeField] private float velocidadeCoringa;
    [SerializeField] private float delayFinal;
    [SerializeField] private Material matTeleporte;    

    public float VelocidadeTeleporte { get { return velocidadeTeleporte; } }
    public float VelocidadeCoringa { get { return velocidadeCoringa; } }
    public float DelayFinal { get { return delayFinal; } }
    public Material MatTeleporte { get { return matTeleporte; } }    
}
