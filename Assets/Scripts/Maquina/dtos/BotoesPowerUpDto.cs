using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotoesPowerUpDto 
{
    [SerializeField] private Sprite[] bordasBtns = new Sprite[2];
    [Space(3)]
    [SerializeField] private Material materialImgPup;
    [SerializeField] private Sprite tampaBtnPup;
    [SerializeField] private Sprite tampaBtnPupPressionada;
    [SerializeField] private Sprite tampaBtnPupSerrilhada;
    [Space(3)]        
    [SerializeField] private GameObject areaDraggavel;
    [Space(3)]
    [SerializeField] private GameObject efeitoHolograma;
    [Space(3)]
    [SerializeField] private BotaoPowerUpDto[] btnPowerUp = new BotaoPowerUpDto[2];
    [SerializeField] private BotaoPowerUpDtoV2[] btnPowerUpV2 = new BotaoPowerUpDtoV2[2];

    public Sprite[] BordasBtns { get { return bordasBtns;  } }

    public Material MaterialImgPup { get { return materialImgPup; } }
    public Sprite TampaBtnPup { get { return tampaBtnPup; } }
    public Sprite TampaBtnPupPressionada { get { return tampaBtnPupPressionada; } }
    public Sprite TampaBtnPupSerrilhada { get { return tampaBtnPupSerrilhada; } }

    public GameObject AreaDraggavel { get { return areaDraggavel; } }    
    public GameObject EfeitoHolograma { get { return efeitoHolograma; } }

    public BotaoPowerUpDto[] BtnPowerUp { get { return btnPowerUp;  } }
    public BotaoPowerUpDtoV2[] BtnPowerUpV2 { get { return btnPowerUpV2;  } }
}
