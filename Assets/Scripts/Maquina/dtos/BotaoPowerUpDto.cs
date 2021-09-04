using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDto 
{
    [SerializeField] private SpriteRenderer sprAreaExterna;
    [SerializeField] private SpriteRenderer sprParteDentro;    
    [SerializeField] private SpriteRenderer sprContorno;
    [SerializeField] private SpriteRenderer sprImagem;    
    [SerializeField] private SpriteRenderer sprEfeito;
    [SerializeField] private GameObject goExclamacao;

    public GameObject GoBtnPowerUp { get { return sprAreaExterna.transform.parent.gameObject; } }
    public SpriteRenderer SprAreaExterna { get { return sprAreaExterna; } }

    public GameObject GoParteDentro { get { return sprParteDentro.gameObject; } }
    public SpriteRenderer SprParteDentro { get { return sprParteDentro; } }

    public SpriteRenderer SprContorno { get { return sprContorno; } }

    public GameObject GoImagem { get { return sprImagem.gameObject;  } }
    public SpriteRenderer SprImagem { get { return sprImagem; } }

    public SpriteRenderer SprEfeito { get { return sprEfeito; } }
    public GameObject GoExclamacao { get { return goExclamacao; } }
}
