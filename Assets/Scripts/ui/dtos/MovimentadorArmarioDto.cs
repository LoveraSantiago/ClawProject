using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MovimentadorArmarioDto 
{
    [SerializeField] private float velocidadeMovimentacao;
    [SerializeField] private float velocidadeZoom;
    [SerializeField] private float escalaFinal;


    public float VelocidadeMovimentacao { get { return velocidadeMovimentacao; } }
    public float VelocidadeZoom { get { return velocidadeZoom; } }
    public float EscalaFinal { get { return escalaFinal; } }
}
