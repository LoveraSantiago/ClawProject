using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplayScoreDto 
{
    [SerializeField] private SpriteRenderer placa;
    [SerializeField] private GameObject placaEfeito;

    [SerializeField] private SpriteRenderer[] fileira1 = new SpriteRenderer[7];
    [SerializeField] private SpriteRenderer[] fileira2 = new SpriteRenderer[7];
    [SerializeField] private SpriteRenderer[] fileira3 = new SpriteRenderer[7];
    [SerializeField] private SpriteRenderer[] fileira4 = new SpriteRenderer[7];
    [SerializeField] private SpriteRenderer[] fileira5 = new SpriteRenderer[7];

    public SpriteRenderer Placa { get { return placa; } }
    public GameObject PlacaEfeito { get { return placaEfeito; } }

    public SpriteRenderer[] Fileira1 { get { return fileira1;  } }
    public SpriteRenderer[] Fileira2 { get { return fileira2;  } }
    public SpriteRenderer[] Fileira3 { get { return fileira3;  } }
    public SpriteRenderer[] Fileira4 { get { return fileira4;  } }
    public SpriteRenderer[] Fileira5 { get { return fileira5;  } }
}
