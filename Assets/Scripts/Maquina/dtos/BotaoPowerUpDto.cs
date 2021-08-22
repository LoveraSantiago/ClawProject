using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDto 
{
    [SerializeField] private SpriteRenderer sprAreaExterna;
    [Space(2)]
    [SerializeField] private GameObject goParteDentro;
    [SerializeField] private SpriteRenderer sprParteDentro;
    [Space(2)]
    [SerializeField] private SpriteRenderer sprContorno;
    [Space(2)]
    [SerializeField] private GameObject goImagem;
    [SerializeField] private SpriteRenderer sprImagem;
    [Space(2)]
    [SerializeField] private GameObject goExclamacao;

    public SpriteRenderer SprAreaExterna { get { return sprAreaExterna; } }
    public GameObject GoParteDentro { get { return goParteDentro; } }
    public SpriteRenderer SprParteDentro { get { return sprParteDentro; } }
    public SpriteRenderer SprContorno { get { return sprContorno; } }
    public GameObject GoImagem { get { return goImagem;  } }
    public SpriteRenderer SprImagem { get { return sprImagem; } }
    public GameObject GoExclamacao { get { return goExclamacao; } }
}
