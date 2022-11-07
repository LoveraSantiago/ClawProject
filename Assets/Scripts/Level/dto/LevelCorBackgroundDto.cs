using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class LevelCorBackgroundDto 
{
    [SerializeField] private Color corBackground;
    [SerializeField] private Color corContorno;
    [SerializeField] private Color cor1;
    [SerializeField] private Color cor2;
    [SerializeField] private Color cor3;
    [SerializeField] private Color cor4;
    [SerializeField] private float clareamento;
   
    public Color CorBackground { get { return corBackground; } }
    public Color CorContorno { get { return corContorno; } }
    public Color Cor1 { get { return cor1; } }
    public Color Cor2 { get { return cor2; } }
    public Color Cor3 { get { return cor3; } }
    public Color Cor4 { get { return cor4; } }
    public float Clareamento { get { return clareamento; } }
}
