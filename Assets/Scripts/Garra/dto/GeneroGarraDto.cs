using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GeneroGarraDto 
{
    [SerializeField] private Sprite corpoBase;
    [SerializeField] private Sprite pinca;
    [SerializeField] private Sprite simbolo;

    public Sprite CorpoBase { get { return corpoBase; } }
    public Sprite Pinca { get { return pinca; } }
    public Sprite Simbolo { get { return simbolo; } }
}
