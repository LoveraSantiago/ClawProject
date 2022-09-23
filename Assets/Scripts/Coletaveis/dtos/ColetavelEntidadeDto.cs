using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetavelEntidadeDto 
{
    [SerializeField] private string nome;
    [SerializeField] private Sprite sprite;

    public string Nome { get { return nome; } }
    public Sprite Sprite { get { return sprite; } }
}
