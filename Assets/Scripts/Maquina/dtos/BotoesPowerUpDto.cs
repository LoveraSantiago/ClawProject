using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotoesPowerUpDto 
{
    [SerializeField] private Sprite[] bordasBtns = new Sprite[2];    
    [Space(5)]
    [SerializeField] private Sprite[] spritesDeBotoes;
    [Space(5)]
    [SerializeField] private GameObject areaDraggavel;
    [Space(5)]
    [SerializeField] private Material materialGlowGeral;
    [SerializeField] private Material materialGlowIndividual;
    [Space(5)]
    [SerializeField] private BotaoPowerUpDto[] btnPowerUp = new BotaoPowerUpDto[4];

    public Sprite[] BordasBtns { get { return bordasBtns;  } }   

    public Sprite[] SpritesDeBotoes { get { return spritesDeBotoes; } }

    public GameObject AreaDraggavel { get { return areaDraggavel; } }

    public Material MaterialGlowGeral { get { return materialGlowGeral; } }
    public Material MaterialGlowIndividual { get { return materialGlowIndividual; } }

    public BotaoPowerUpDto[] BtnPowerUp { get { return btnPowerUp;  } }
}
